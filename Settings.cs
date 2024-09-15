/// <summary>
/// All plugin specific settings
/// </summary>
public class Settings {

  /// <summary>
  /// The special command used to view all device addresses (defaults to "DeviceAddresses")<br />
  /// The only way to use the plugin is via special commands, as to not clutter search results
  /// </summary>
  public string DeviceAddressesCommand { get; set; } = "DeviceAddresses";

  /// <summary>
  /// The special command used to view all device IP addresses (defaults to "IPaddresses")<br />
  /// The only way to use the plugin is via special commands, as to not clutter search results
  /// </summary>
  public string IPaddressesCommand { get; set; } = "IPaddresses";

  /// <summary>
  /// The special command used to view all device MAC addresses (defaults to "MACaddresses")<br />
  /// The only way to use the plugin is via special commands, as to not clutter search results
  /// </summary>
  public string MACaddressesCommand { get; set; } = "MACaddresses";

}
