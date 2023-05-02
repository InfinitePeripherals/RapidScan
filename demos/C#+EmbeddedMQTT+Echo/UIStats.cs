using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MQTTnet.Client;
using MQTTnet.Server;

// Simple class for keeping the connected clients in the ListView
namespace Airscan
{
    internal class UIStats
    {
        private static ListView UI;
        private static PictureBox Logo;
        private static Dictionary<string, UIClient> clients = new Dictionary<string, UIClient>();
        //-------------------------------------------------------------------------------------------------------------------------------------
        public static void SetListView(ListView lv)
        {
            UI = lv;

            // Set it up
            Action update = delegate
            {
                lv.Columns.Add("ID");
                lv.Columns.Add("IP");
                lv.Columns.Add("Topics");
                lv.Columns.Add("Msgs");
                lv.Columns.Add("Last Message");
            };
            lv.Invoke(update);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        public static void SetLogo(PictureBox pb)
        {
            Logo = pb;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        public static void UIAddClient(ClientConnectedEventArgs c)
        {
            if (UI == null) return;
            var client = new UIClient { clientID = c.ClientId, clientIP = c.Endpoint, msgs = 0  };
            ListViewItem lvItem = new ListViewItem(c.ClientId);
            lvItem.SubItems.Add(c.Endpoint);
            lvItem.SubItems.Add(""); // Topic
            lvItem.SubItems.Add("0"); // Count
            lvItem.SubItems.Add(""); // Message
            client.lvItem = lvItem;
            Action update = delegate {
                UI.Items.Add(lvItem);
                UI.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                UI.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            };
            UI.Invoke(update);
            clients[c.ClientId] = client;
            return;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        public static void UIRemoveClient(ClientDisconnectedEventArgs c)
        {
            if (UI == null) return;
            var client = clients[c.ClientId];

            Action update = delegate {
                UI.Items.Remove(client.lvItem);
                clients.Remove(c.ClientId);
            };
            UI.Invoke(update);

            return;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        public static void MessageOut(InterceptingPublishEventArgs c)
        {
            if (UI == null) return;

            UIClient client = clients[c.ClientId];
            client.msgs++;
            string payload = DateTime.Now.ToString("hh:mm:ss") + " - " + System.Text.Encoding.UTF8.GetString(c.ApplicationMessage.Payload);
            client.lastMessage = payload;
            UIUpdate(c.ClientId);
            return;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        public async static void MessageIn(MqttApplicationMessageReceivedEventArgs msg, string payload)
        {
            if (UI == null) return;

            UIClient client = clients[msg.ClientId];
            client.msgs++;
            client.lastMessage = payload;
            //client.lastMessage = DateTime.Now.ToString("hh:mm:ss") + " - " + message;

            new System.Threading.Thread(e =>
                {
                    DisplayLogoWithLightning();
                    UIUpdate(msg.ClientId);
                    System.Threading.Thread.Sleep(100);
                    DisplayLogoWithoutLightning();
                }
            ).Start();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        public static void DisplayLogoWithLightning()
        {
            Action animate = delegate
            {
                Logo.Image = global::AirscanMQTTDemo.Properties.Resources.AirScanLogoFinalOn;
                Logo.Refresh();
            };
            UI.Invoke(animate);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        public static void DisplayLogoWithoutLightning()
        {
            Action animate = delegate
            {
                Logo.Image = global::AirscanMQTTDemo.Properties.Resources.AirScanLogoFinalOff;
                Logo.Refresh();
            };
            UI.Invoke(animate);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        public static void ClientSubscribed(ClientSubscribedTopicEventArgs client)
        {
            // Append the Topic to the list of Topics they've already subscribed too
            Action update = delegate
            {
                var topic = client.TopicFilter.Topic;
                var index = UI.FindItemWithText(client.ClientId);
                int len = index.SubItems[2].Text.Length;
                if (index.SubItems[2].Text.Length > 0) index.SubItems[2].Text += ";";
                index.SubItems[2].Text +=  topic;
                UIUpdate(client.ClientId);
            };
            UI.Invoke(update);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        public static void UIUpdate(string clientID)
        {
            if (UI == null) return;

            // Ok this client is in the list, lets update it!
            UIClient client = clients[clientID];
            Action update = delegate
            {
                var index = UI.FindItemWithText(clientID);
                index.SubItems[3].Text = "" + client.msgs;
                index.SubItems[4].Text = client.lastMessage;                
            };
            UI.Invoke(update);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        private class UIClient
        {
            public string clientID { get; set; }
            public string clientIP { get; set; }
            public string topic { get; set; }
            public int msgs { get; set; }
            public string lastMessage { get; set; }
            public ListViewItem lvItem { get; set; }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------

    }
}
