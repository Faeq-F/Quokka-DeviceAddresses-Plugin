using Quokka;
using Quokka.ListItems;
using Quokka.PluginArch;

namespace PluginDeviceAddresses
{
  class IPaddressItem : ListItem
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
      System.Windows.Clipboard.SetText(Name);
      App.Current.MainWindow.Close();
    }
  }

  class MACaddressItem : ListItem
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
      System.Windows.Clipboard.SetText(Name);
      App.Current.MainWindow.Close();
    }
  }
}
