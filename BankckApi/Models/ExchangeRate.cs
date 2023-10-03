namespace BankckApi.Models
{
    public class ExchangeRate
    {
        public int Id { get; set; }
        public int SourceCurrencyId { get; set; }
        public int TargetCurrencyId { get; set; }
        public decimal Rate { get; set; }
        public Currency SourceCurrency { get; set; }
        public Currency TargetCurrency { get; set; }
    }
}
