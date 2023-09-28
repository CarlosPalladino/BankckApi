namespace BankckApi.Dtos
{
    public class ExhchangeRateDto
    {
        public int Id { get; set; }
        public int SourceCurrencyId { get; set; }
        public int TargetCurrencyId { get; set; }
        public decimal Rate { get; set; }
    }
}
