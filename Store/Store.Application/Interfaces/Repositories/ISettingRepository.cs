using Store.Domain.SettingsDomain.Entities;

namespace Store.Application.Interfaces.Repositories
{
    public interface ISettingRepository : IRepository<Settings>{

        void tmpAddSeed();
    }
}
