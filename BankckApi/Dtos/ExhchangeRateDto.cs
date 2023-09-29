namespace BankckApi.Dtos
{
    public class ExchangeRateDto
    {
        public int Id { get; set; }
        public int SourceCurrencyId { get; set; }
        public int TargetCurrencyId { get; set; }
        public decimal Rate { get; set; }
    }
}
