using System.ComponentModel.DataAnnotations;

namespace NbpBackend.Models
{
    public class CurrencyRate
    {
        [Key]
        public int Id { get; set; } // Unikalny numer w bazie
        public string Currency { get; set; } // Np. "dolar amerykański"
        public string Code { get; set; }     // Np. "USD"
        public decimal Mid { get; set; }     // Kurs średni
        public DateTime Date { get; set; }   // Data kursu
    }
}
