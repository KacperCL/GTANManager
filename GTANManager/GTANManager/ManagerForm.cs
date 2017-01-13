using GTANetworkServer;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace GTANManager
{
    public partial class ManagerForm : Form
    {

        private API API;
        private List<Client> players;

        private int sortColumn = -1;

        private XmlDocument banDoc;

        public ManagerForm(API api)
        {
            InitializeComponent();

            API = api;

            players = new List<Client>();

            UpdateTitle();

            UpdateResourceLists();

            UpdateBanList();
        }

        private void UpdateTitle()
        {
            Text = "GTA:N Manager : " + API.getServerName() + " [" + players.Count + "]";
        }

        private void UpdateBanList()
        {
            bannedPlayerList.Items.Clear();
            if (File.Exists("bans.xml"))
            {
                banDoc = new XmlDocument();
                banDoc.Load("bans.xml");
                foreach (XmlNode node in banDoc.DocumentElement.ChildNodes)
                    bannedPlayerList.Items.Add(node.Attributes["schandle"].Value);
            }
        }

        private void UpdateResourceLists()
        {
            resourceList.Items.Clear();
            foreach (var r in API.getAllResources())
            {
                if (r != "gtanmanager")
                {
                    ListViewItem item = new ListViewItem(r);
                    item.SubItems.Add(API.isResourceRunning(r).ToString());
                    resourceList.Items.Add(item);
                }
            }
            resourceListSort(1, SortOrder.Descending);
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
            if (resourceList.SelectedItems.Count > 0)
            {
                for (var i = 0; i < resourceList.SelectedItems.Count; i++)
                {
                    var r = resourceList.SelectedItems[i].SubItems[0].Text;
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
            if (resourceList.SelectedItems.Count > 0)
            {
                for (var i = 0; i < resourceList.SelectedItems.Count; i++)
                {
                    var r = resourceList.SelectedItems[i].SubItems[0].Text;
                    if (API.isResourceRunning(r))
                        API.stopResource(r);
                }
            }
            UpdateResourceLists();
        }

        private void startResourceButton_Click(object sender, EventArgs e)
        {
            if (resourceList.SelectedItems.Count > 0)
            {
                for (var i = 0; i < resourceList.SelectedItems.Count; i++)
                {
                    var r = resourceList.SelectedItems[i].SubItems[0].Text;
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
            UpdateBanList();
        }

        private void kickAll_Click(object sender, EventArgs e)
        {
            var reason = Interaction.InputBox("Enter kick reason (1 space for no reason) :", "Kick reason", " ");
            if (reason != "")
                foreach (var c in players)
                    API.kickPlayer(c, reason);
        }

        private void resourceListSort(int col, SortOrder order)
        {
            if (col != sortColumn)
                sortColumn = col;

            resourceList.Sorting = order;

            resourceList.Sort();

            resourceList.ListViewItemSorter = new ListViewItemComparer(col, resourceList.Sorting);
        }

        private void resourceList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (resourceList.Sorting == SortOrder.Ascending)
                resourceListSort(e.Column, SortOrder.Descending);
            else
                resourceListSort(e.Column, SortOrder.Ascending);
        }

        private void refreshResourceListButton_Click(object sender, EventArgs e)
        {
            UpdateResourceLists();
        }

        private void unbanButton_Click(object sender, EventArgs e)
        {
            if (bannedPlayerList.SelectedIndex >= 0)
            {
                foreach (var i in bannedPlayerList.SelectedItems)
                {
                    var p = i.ToString();
                    foreach (XmlNode node in banDoc.DocumentElement.ChildNodes)
                    {
                        if (node.Attributes["schandle"].Value == p)
                        {
                            banDoc.DocumentElement.RemoveChild(node);
                            break;
                        }
                    }
                }
            }
            banDoc.Save("bans.xml");
            UpdateBanList();
        }

        private void buttonRefreshBan_Click(object sender, EventArgs e)
        {
            UpdateBanList();
        }

        private void addBanButton_Click(object sender, EventArgs e)
        {
            var username = Interaction.InputBox("Enter Social Club username :", "Name", "");
            if (username != "")
            {
                var ip = Interaction.InputBox("Enter player IP (1 space for no IP) :", "IP Address", " ");
                if (ip != "")
                {
                    var reason = Interaction.InputBox("Enter reason (1 space for no reason) :", "Ban reason", " ");
                    if (reason != "")
                    {
                        XmlNode node = banDoc.CreateElement("ban");
                        XmlAttribute userAttribute = banDoc.CreateAttribute("schandle");
                        userAttribute.Value = username;
                        node.Attributes.Append(userAttribute);
                        XmlAttribute ipAttribute = banDoc.CreateAttribute("ip");
                        ipAttribute.Value = ip;
                        node.Attributes.Append(ipAttribute);
                        XmlAttribute reasonAttribute = banDoc.CreateAttribute("reason");
                        reasonAttribute.Value = reason;
                        node.Attributes.Append(reasonAttribute);
                        banDoc.DocumentElement.AppendChild(node);
                    }
                }
            }
            banDoc.Save("bans.xml");
            UpdateBanList();
        }
    }

    public class ListViewItemComparer : IComparer
    {

        private int col;
        private SortOrder order;
        public ListViewItemComparer()
        {
            col = 0;
            order = SortOrder.Ascending;
        }
        public ListViewItemComparer(int column, SortOrder order)
        {
            col = column;
            this.order = order;
        }
        public int Compare(object x, object y)
        {
            int returnVal = -1;
            returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                            ((ListViewItem)y).SubItems[col].Text);
            if (order == SortOrder.Descending)
                returnVal *= -1;
            return returnVal;
        }

    }
}
