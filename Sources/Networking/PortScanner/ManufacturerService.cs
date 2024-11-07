namespace PortScanner;

public class ManufacturerService
{
    private readonly HttpClient _httpClient = new();
    private readonly Dictionary<string, string> _cache = new();

    public async Task<string> GetManufacturerByMacAsync(string macAddress)
    {
        await Task.Delay(1000);
        var response = await _httpClient.GetStringAsync($"https://api.macvendors.com/{macAddress}");
        string manufacturer = !string.IsNullOrEmpty(response) ? response : "Unknown Manufacturer";
        _cache[macAddress] = manufacturer;
        return manufacturer;
    }
}