using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.Application.Interfaces.Repositories;
using Store.Domain.SettingsDomain.Static;

namespace Store.Application.Features.Setting
{
    public class SettingHostService : IHostedService
    {
        private readonly ISettingRepository _settingRepository;

        public SettingHostService(IServiceScopeFactory serviceScopeFactory)
        {
            _settingRepository = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<ISettingRepository>();
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var setting = await _settingRepository.FindAsync(x=>x.IsActive == true);
            if (setting == null)
            {
                _settingRepository.tmpAddSeed();
                setting = await _settingRepository.FindAsync(x => x.IsActive == true);
            }
            AllSetting.SetSetting(setting);
            await StopAsync(new System.Threading.CancellationToken());
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
