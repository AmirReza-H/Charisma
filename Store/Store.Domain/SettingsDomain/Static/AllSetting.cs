using Store.Domain.SettingsDomain.Entities;

namespace Store.Domain.SettingsDomain.Static
{
    public static class AllSetting
    {
        public static decimal FixedProfit { get; private set; }
        public static decimal FixedDiscount { get; private set; }
        public static int PercentageDiscount { get; private set; }
        public static decimal MinimumOrderQuantity { get; private set; }
        public static int OpeningHour { get; private set; }
        public static int CloseHour { get; private set; }

        public static void SetSetting(Settings settings)
        {
            FixedProfit = settings.FixedProfit;
            FixedDiscount = settings.FixedDiscount;
            PercentageDiscount = settings.PercentageDiscount;
            MinimumOrderQuantity = settings.MinimumOrderQuantity;
            OpeningHour = settings.OpeningHour;
            CloseHour = settings.CloseHour;

        }
    }
}
