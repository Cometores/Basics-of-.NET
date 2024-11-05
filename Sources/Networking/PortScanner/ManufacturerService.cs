namespace PortScanner;

public class ManufacturerService
{
    private readonly HttpClient _httpClient = new();

    public async Task<string> GetManufacturerByMacAsync(string macAddress)
    {
        await Task.Delay(1000);
        var response = await _httpClient.GetStringAsync($"https://api.macvendors.com/{macAddress}");
        return !string.IsNullOrEmpty(response) ? response : "Unknown Manufacturer";
    }
}