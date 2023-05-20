using Store.Domain.Common;

namespace Store.Domain.SettingsDomain.Entities
{
    public class Settings : BaseEntity
    {
        public decimal FixedProfit { get; set; }
        public decimal FixedDiscount { get; set; }
        public int PercentageDiscount { get; set; }
        public decimal MinimumOrderQuantity { get; set; }
        public int OpeningHour { get; set; }
        public int CloseHour { get; set; }
        public bool IsActive { get; set; }
    }
}
