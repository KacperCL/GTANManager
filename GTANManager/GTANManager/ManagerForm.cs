﻿using GTANetworkServer;
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

        public ManagerForm(API api)
        {
            InitializeComponent();

            API = api;

            players = new List<Client>();

            UpdateTitle();

            UpdateResourceLists();

        }

        private void UpdateTitle()
        {
            Text = "GTA:N Manager : " + API.getServerName() + " [" + players.Count + "]";
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
            UpdateTitle();
        }

        public void RemovePlayer(Client client)
        {
            if (playerList.Items.Contains(client.socialClubName))
                playerList.Items.Remove(client.socialClubName);
            if (players.Contains(client))
                players.Remove(client);
            UpdateTitle();
        }

        private void restartResourceButton_Click(object sender, EventArgs e)
        {
            if (resourceRunningList.SelectedIndex >= 0)
            {
                foreach (var i in resourceRunningList.SelectedItems)
                {
                    var r = i.ToString();
                    if (API.isResourceRunning(r))
                    {
                        API.stopResource(r);
                        API.startResource(r);
                    }
                }
            }
            UpdateResourceLists();
        }

        private void stopResourceButton_Click(object sender, EventArgs e)
        {
            if (resourceRunningList.SelectedIndex >= 0)
            {
                foreach (var i in resourceRunningList.SelectedItems)
                {
                    var r = i.ToString();
                    if (API.isResourceRunning(r))
                        API.stopResource(r);
                }
            }
            UpdateResourceLists();
        }

        private void startResourceButton_Click(object sender, EventArgs e)
        {
            if (resourceList.SelectedIndex >= 0)
            {
                foreach (var i in resourceList.SelectedItems)
                {
                    var r = i.ToString();
                    if (!API.isResourceRunning(r))
                        API.startResource(r);
                }
            }
            UpdateResourceLists();
        }

        private void kickButton_Click(object sender, EventArgs e)
        {
            if (playerList.SelectedIndex >= 0)
            {
                var reason = Interaction.InputBox("Enter kick reason (1 space for no reason) :", "Kick reason", " ");
                if (reason != "")
                {
                    foreach (var i in playerList.SelectedItems)
                    {
                        var p = i.ToString();

                        foreach (var c in players)
                        {
                            if (p == c.socialClubName)
                            {
                                API.kickPlayer(c, reason);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void banButton_Click(object sender, EventArgs e)
        {
            if (playerList.SelectedIndex >= 0)
            {
                var reason = Interaction.InputBox("Enter ban reason (1 space for no reason) :", "Ban reason", " ");
                if (reason != "")
                {
                    foreach (var i in playerList.SelectedItems)
                    {
                        var p = i.ToString();
                        foreach (var c in players)
                        {
                            if (p == c.socialClubName)
                            {
                                API.banPlayer(c, reason);
                                break;
                            }
                        }
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
