using Quokka.ListItems;
using Quokka.PluginArch;
using System.Windows;

namespace PluginDeviceAddresses
{
  internal sealed class IPaddressItem : ListItem
  {

    public IPaddressItem(string address)
    {
      Name = address;
      Description = "Your machine's IP address";
      Icon = IconCache.GetOrAdd(
        Environment.CurrentDirectory + "\\PlugBoard\\PluginDeviceAddresses\\Plugin\\ip.png"
      );
    }

    public override void Execute()
    {
      Clipboard.SetText(Name);
      Application.Current.MainWindow.Close();
    }
  }

  internal sealed class MACaddressItem : ListItem
  {

    public MACaddressItem(string address)
    {
      Name = address;
      Description = "Your machine's MAC address";
      Icon = IconCache.GetOrAdd(
        Environment.CurrentDirectory + "\\PlugBoard\\PluginDeviceAddresses\\Plugin\\mac.png"
      );
    }

    public override void Execute()
    {
      Clipboard.SetText(Name);
      Application.Current.MainWindow.Close();
    }
  }
}
