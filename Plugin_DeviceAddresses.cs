using Newtonsoft.Json;
using Quokka.ListItems;
using Quokka.PluginArch;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;

namespace Plugin_DeviceAddresses {
  /// <summary>
  /// The DeviceAddresses plugin
  /// </summary>
  public partial class DeviceAddresses : Plugin {

    private static Settings pluginSettings = new();
    internal static Settings PluginSettings { get => pluginSettings; set => pluginSettings = value; }

    /// <summary>
    /// Creates the plugin, loading the plugins settings
    /// </summary>
    public DeviceAddresses() {
      string fileName = Environment.CurrentDirectory + "\\PlugBoard\\Plugin_DeviceAddresses\\Plugin\\settings.json";
      PluginSettings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(fileName))!;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override string PluggerName { get; set; } = "DeviceAddresses";

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="query"><inheritdoc /></param>
    /// <returns>An empty list - the only way to use this plugin is through special commands</returns>
    public override List<ListItem> OnQueryChange(string query) { return new List<ListItem>(); }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns>The commands in settings</returns>
    public override List<String> SpecialCommands() {
      return new List<String>() { PluginSettings.DeviceAddressesCommand, PluginSettings.IPaddressesCommand, PluginSettings.MACaddressesCommand };
    }

    List<string> getMACaddresses() {
      List<string> items = new();
      foreach (string address in NetworkInterface
           .GetAllNetworkInterfaces()
           .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
           .Select(nic => nic.GetPhysicalAddress().ToString())) {
        items.Add(address.ToString());
      }
      return items;
    }

    List<string> getIPaddresses() {
      string strHostName = Dns.GetHostName();
      IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
      IPAddress[] addr = ipEntry.AddressList;
      List<string> items = new();
      foreach (IPAddress item in addr) {
        items.Add(item.ToString());
      }
      return items;
    }

    /// <summary>
    /// <inheritdoc/><br />
    /// Provides the respective addresses or all of them if the query is the DeviceAddressesCommand
    /// </summary>
    /// <param name="command"><inheritdoc/></param>
    /// <returns>the respective address</returns>
    public override List<ListItem> OnSpecialCommand(string command) {
      switch (command) {
        case var value when value == PluginSettings.IPaddressesCommand: {
          List<ListItem> items = new();
          foreach (string address in getIPaddresses()) {
            items.Add(new IPaddressItem(address));
          }
          return items;
        }
        case var value when value == PluginSettings.MACaddressesCommand: {
          List<ListItem> items = new();
          foreach (string address in getMACaddresses()) {
            items.Add(new MACaddressItem(address));
          }
          return items;
        }
        default: {
          List<ListItem> items = new();
          foreach (string address in getIPaddresses()) {
            items.Add(new IPaddressItem(address));
          }
          foreach (string address in getMACaddresses()) {
            items.Add(new MACaddressItem(address));
          }
          return items;
        }
      }
    }

  }


}
