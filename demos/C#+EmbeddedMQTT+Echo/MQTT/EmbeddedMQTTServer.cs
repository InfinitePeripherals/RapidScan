using MQTTnet;
using MQTTnet.Server;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Airscan.MQTT
{
    // An Embedded MQTT Server
    // Obviously could be External too...
    public class EmbeddedMQTTServer
    {
        private MqttServer mqttServer = null;
        private string serverUid;
        private string serverPwd;
        private int serverPort;

        //-------------------------------------------------------------------------------------------------------------------------------------
        public EmbeddedMQTTServer(int port, string uid, string pwd )
        {
            this.serverUid = uid;
            this.serverPwd = pwd;
            this.serverPort = port;
            StartMqttServer();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        public async void StartMqttServer()
        {
            // OK Let's spin it Up!
            var mqttFactory = new MqttFactory();
            var options = mqttFactory.CreateServerOptionsBuilder().WithDefaultEndpoint().WithDefaultEndpointPort(serverPort).Build();
            mqttServer = mqttFactory.CreateMqttServer(options);

            // Setup Simple Authentication
            mqttServer.ValidatingConnectionAsync += client =>
            {
                if (client.UserName != Settings.mqttUid || client.Password != Settings.mqttPwd)
                {
                    client.ReasonCode = MQTTnet.Protocol.MqttConnectReasonCode.BadUserNameOrPassword;
                }
                //Publish(Settings.mqttTopic, "Hello" + client.ClientId);
                return System.Threading.Tasks.Task.CompletedTask;
            };

            mqttServer.ClientConnectedAsync += client =>
            {
                UIStats.UIAddClient(client);
                return System.Threading.Tasks.Task.CompletedTask;
            };

            mqttServer.ClientDisconnectedAsync += client =>
            {
                UIStats.UIRemoveClient(client);
                return System.Threading.Tasks.Task.CompletedTask;
            };

            mqttServer.InterceptingPublishAsync += client =>
            {
                UIStats.MessageOut(client);
                return System.Threading.Tasks.Task.CompletedTask;
            };

            mqttServer.ClientSubscribedTopicAsync += client =>
            {
                UIStats.ClientSubscribed(client);
                return System.Threading.Tasks.Task.CompletedTask;
            };

            // Start
            await mqttServer.StartAsync();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        public async Task Publish(string topic, string payload)
        {
            var message = new MqttApplicationMessageBuilder().WithTopic(topic).WithPayload(payload).Build();
            var inject = new InjectedMqttApplicationMessage(message);
            mqttServer.InjectApplicationMessage( inject );
        }
    }
}
