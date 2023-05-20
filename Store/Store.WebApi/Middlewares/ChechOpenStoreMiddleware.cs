using Store.Domain.SettingsDomain.Static;

namespace Store.WebApi.Middlewares
{
    public class ChechOpenStoreMiddleware
    {
        private readonly RequestDelegate _next;

        public ChechOpenStoreMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string path = context.Request.Path;
            if (path.Contains("create-order")) 
            {
                TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Iran Standard Time");
                int currentHour = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone).Hour;
                if (currentHour > AllSetting.CloseHour || currentHour < AllSetting.OpeningHour)
                {
                    throw new Exception("shop is closing");
                }
            }
            // Use the path as needed


            // Call the next middleware in the pipeline
            await _next(context);
        }
    }
}
