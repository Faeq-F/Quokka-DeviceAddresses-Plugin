using Quokka;
using Quokka.ListItems;
using Quokka.PluginArch;
using System.Windows.Media.Imaging;

namespace Plugin_DeviceAddresses {
  class IPaddressItem : ListItem {

    public IPaddressItem(string address) {
      Name = address;
      Description = "Your machine's IP address";
      UiDispatcher.BeginInvoke(() => {
        Icon = new BitmapImage(new Uri(
            Environment.CurrentDirectory + "\\PlugBoard\\Plugin_DeviceAddresses\\Plugin\\ip.png"));
      });
    }

    public override void Execute() {
      System.Windows.Clipboard.SetText(Name);
      App.Current.MainWindow.Close();
    }
  }

  class MACaddressItem : ListItem {

    public MACaddressItem(string address) {
      Name = address;
      Description = "Your machine's MAC address";
      UiDispatcher.BeginInvoke(() => {
        Icon = new BitmapImage(new Uri(
            Environment.CurrentDirectory + "\\PlugBoard\\Plugin_DeviceAddresses\\Plugin\\mac.png"));
      });
    }

    public override void Execute() {
      System.Windows.Clipboard.SetText(Name);
      App.Current.MainWindow.Close();
    }
  }
}
