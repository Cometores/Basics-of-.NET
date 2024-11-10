namespace PortScanner.PortScan;

/// <summary>
/// Represents a service for retrieving manufacturer information based on MAC addresses.
/// </summary>
public class ManufacturerService
{
    private readonly HttpClient _httpClient = new();
    private readonly Dictionary<string, string> _cache = new();

    /// <summary>
    /// Retrieves the manufacturer name based on the provided MAC address using an external API.
    /// </summary>
    /// <param name="macAddress">The MAC address to look up the manufacturer for.</param>
    /// <returns>A string representing the manufacturer associated with the provided MAC address, or "Unknown Manufacturer" if the information is unavailable.</returns>
    public async Task<string> GetManufacturerByMacAsync(string macAddress)
    {
        if (_cache.TryGetValue(macAddress, out var manufacturer))
        {
            return manufacturer;
        }
        
        await Task.Delay(1000);
        var response = await _httpClient.GetStringAsync($"https://api.macvendors.com/{macAddress}");
        
        manufacturer = !string.IsNullOrEmpty(response) ? response : "Unknown Manufacturer";
        _cache[macAddress] = manufacturer;
        
        return manufacturer;
    }
}