using GTANetworkServer;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GTANManager
{
    public partial class ManagerForm : Form
    {

        private API API;
        private List<Client> players;

        public ManagerForm(string title, API api)
        {
            InitializeComponent();

            API = api;

            players = new List<Client>();

            Text = "GTA:N Manager : " + title;

            UpdateResourceLists();

        }

        private void UpdateResourceLists()
        {
            resourceList.Items.Clear();
            resourceRunningList.Items.Clear();
            foreach (var r in API.getAllResources())
            {
                if (r != "gtanmanager")
                {
                    if (API.isResourceRunning(r))
                        resourceRunningList.Items.Add(r);
                    else
                        resourceList.Items.Add(r);
                }
            }
        }

        public void AddPlayer(Client client)
        {
            playerList.Items.Add(client.socialClubName);
            players.Add(client);
        }

        public void RemovePlayer(Client client)
        {
            if (playerList.Items.Contains(client.socialClubName))
                playerList.Items.Remove(client.socialClubName);
            if (players.Contains(client))
                players.Remove(client);
        }

        private void restartResourceButton_Click(object sender, EventArgs e)
        {
            if (resourceRunningList.SelectedIndex >= 0)
            {
                var r = resourceRunningList.SelectedItem.ToString();
                if (API.isResourceRunning(r))
                {
                    API.stopResource(r);
                    API.startResource(r);
                }
            }
            UpdateResourceLists();
        }

        private void stopResourceButton_Click(object sender, EventArgs e)
        {
            if (resourceRunningList.SelectedIndex >= 0)
            {
                var r = resourceRunningList.SelectedItem.ToString();
                if (API.isResourceRunning(r))
                    API.stopResource(r);
            }
            UpdateResourceLists();
        }

        private void startResourceButton_Click(object sender, EventArgs e)
        {
            if (resourceList.SelectedIndex >= 0)
            {
                var r = resourceList.SelectedItem.ToString();
                if (!API.isResourceRunning(r))
                    API.startResource(r);
            }
            UpdateResourceLists();
        }

        private void kickButton_Click(object sender, EventArgs e)
        {
            if (playerList.SelectedIndex >= 0)
            {
                var p = playerList.SelectedItem.ToString();
                foreach (var c in players)
                {
                    if (p == c.socialClubName)
                    {
                        var reason = Interaction.InputBox("Enter kick reason (1 space for no reason) :", "Kick reason", " ");
                        if (reason != "")
                            API.kickPlayer(c, reason);
                        break;
                    }
                }
            }
        }

        private void banButton_Click(object sender, EventArgs e)
        {
            if (playerList.SelectedIndex >= 0)
            {
                var p = playerList.SelectedItem.ToString();
                foreach (var c in players)
                {
                    if (p == c.socialClubName)
                    {
                        var reason = Interaction.InputBox("Enter ban reason (1 space for no reason) :", "Ban reason", " ");
                        if (reason != "")
                            API.banPlayer(c, reason);
                        break;
                    }
                }
            }
        }

        private void kickAll_Click(object sender, EventArgs e)
        {
            var reason = Interaction.InputBox("Enter kick reason (1 space for no reason) :", "Kick reason", " ");
            if (reason != "")
                foreach (var c in players)
                    API.kickPlayer(c, reason);
        }

    }

}
