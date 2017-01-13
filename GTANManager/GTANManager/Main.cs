using GTANetworkServer;
using System.Threading;
using System.Windows.Forms;

namespace GTANManager
{
    public class Main : Script
    {

        private ManagerForm manager = null;

        public Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            

            new Thread(() =>
            {
                while (true)
                {
                    manager = new ManagerForm(API);
                    Application.Run(manager);
                }

            }).Start();



            API.onPlayerConnected += API_onPlayerConnected;
            API.onPlayerDisconnected += API_onPlayerDisconnected;
        }

        private void API_onPlayerDisconnected(Client player, string reason)
        {
            if (manager != null)
                manager.RemovePlayer(player);
        }

        private void API_onPlayerConnected(Client player)
        {
            if (manager != null)
                manager.AddPlayer(player);
        }

    }
}
