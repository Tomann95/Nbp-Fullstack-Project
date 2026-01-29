using System.Text.Json;
using System.Text.Json.Serialization;

namespace NbpBackend.Services
{
    // Klasy pomocnicze (tylko do odczytania tego, co wyśle NBP)
    public class NbpTableWrapper
    {
        [JsonPropertyName("rates")]
        public List<NbpRateDto> Rates { get; set; }
    }

    public class NbpRateDto
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("mid")]
        public decimal Mid { get; set; }
    }

    public class NbpService
    {
        private readonly HttpClient _httpClient;

        public NbpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<NbpRateDto>> GetRatesAsync(string date)
        {
            // Poprawny adres URL do tabeli A
            var url = $"https://api.nbp.pl/api/exchangerates/tables/A/{date}/?format=json";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                // Jeśli błąd, rzucamy wyjątek z informacją
                throw new Exception($"Błąd połączenia z NBP: {response.StatusCode} dla daty {date}. Adres: {url}");
            }

            var json = await response.Content.ReadAsStringAsync();

            // NBP zwraca listę tabel, bierzemy pierwszą
            var tables = JsonSerializer.Deserialize<List<NbpTableWrapper>>(json);

            return tables?[0].Rates ?? new List<NbpRateDto>();
        }
    }
}
