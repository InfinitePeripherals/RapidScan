using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;

//------------------------------------------------------------------------------------------------------------------------------------------------
// This class is used by the application to connect to an MQTT Server (either internal or external) and
// 1) Stay Connected / Reconnect if necessary
// 2) Receive message from the <topic>/<serial#>/out channel (i.e. where Airscan will put scans)
// 3) Send message to TopicRouter when any scan/image is received
//------------------------------------------------------------------------------------------------------------------------------------------------
namespace Airscan.MQTT
{
    public class MQTTClient
    {
        //--------------------------------------------------------------------------------------------------------------------
        // Member Variables
        private static MQTTClient instance;
        private IMqttClient mqttClient;
        private Boolean stopService = false;
        private int msgCount = 0;

        public Action<string, string, int> TopicMessageReceivedHandler { get; set; } // The business logic will have to be pluggined in by user...  topic, payload, id
        //--------------------------------------------------------------------------------------------------------------------
        public static MQTTClient Instance
        {
            get
            {
                if (instance == null) instance = new MQTTClient();
                return instance;
            }
        }
        //--------------------------------------------------------------------------------------------------------------------
        private MQTTClient()
        {
            MQTTInit(); // Connect and Stay Connected!
        }

        //--------------------------------------------------------------------------------------------------------------------
        // Stop
        // 1) Stops the MQTTEngine for good, should just be called to shutdown or maybe not needed...
        //--------------------------------------------------------------------------------------------------------------------
        public void Stop()
        {
            stopService = true;
            if (mqttClient != null && mqttClient.IsConnected) mqttClient.DisconnectAsync();
        }

        //--------------------------------------------------------------------------------------------------------------------
        // MQTTInit
        // 1) Setup all the authentication for the MQTT Client
        // 2) Setup the Disconnect Handler so that a Disconnect will force a reconnect attempt
        // 3) Setup a Message Received Callback Handler
        // 4) Connect!
        //--------------------------------------------------------------------------------------------------------------------
        private void MQTTInit()
        {
            string server = "127.0.0.1"; // Connecting to Internal Server, but can be external too
            string uid = Settings.mqttUid;
            string pwd = Settings.mqttPwd;
            var mqttFactory = new MqttFactory();
            mqttClient = mqttFactory.CreateMqttClient();

            MqttClientOptions mqttClientOptions = new MqttClientOptionsBuilder()
                .WithTcpServer(server,Settings.mqttPort)
                //.WithWebSocketServer(server)
                .WithCredentials(uid, pwd)
                .WithCleanSession(true)
                //.WithTls()
            .Build();

            // Disconnect handler, just try and reconnect again!
            mqttClient.DisconnectedAsync += e => {
                if (stopService == true) return Task.CompletedTask;
                MQTTConnect(mqttClientOptions);
                return Task.CompletedTask;
            };

            // New Messages!
            mqttClient.ApplicationMessageReceivedAsync += e =>
            {
                var payloadText = Encoding.UTF8.GetString(e?.ApplicationMessage?.Payload ?? Array.Empty<byte>());
                var topic = e.ApplicationMessage.Topic;
                UIStats.MessageIn(e, payloadText);
                Task.Run(() => MQTTProcessIncomingMessage(topic, payloadText, ++msgCount)); // allows multiple messages from multiple clients to come in at once
                return Task.CompletedTask;
            };

            // OK now Handlers are ready, lets do the first connect...
            MQTTConnect(mqttClientOptions);
        }

        //--------------------------------------------------------------------------------------------------------------------
        // MQTTConnect
        // 1) Use Configuration Info to Connect to MQTT Server until successful (loop)
        // 2) Subscribe to topic in AppSettings
        //--------------------------------------------------------------------------------------------------------------------
        private async void MQTTConnect(MqttClientOptions opts)
        {
            if (stopService) return;

            while (!stopService && mqttClient.IsConnected == false)
            {
                var result = await mqttClient.ConnectAsync(opts);

                if (result.ResultCode == MqttClientConnectResultCode.Success)
                {
                    string topic = Settings.mqttTopic;
                    MQTTSubscribe(topic + "/+/out"); // monitor incoming messages in the out channel.  AirScan will put the scans on <topic>/<serial#>/out channel
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------
        // MQTTSubscribe
        // Simple code to subscribe to a given topic using MQTTNet
        //--------------------------------------------------------------------------------------------------------------------
        private async void MQTTSubscribe(string topic)
        {
            var factory = new MqttFactory();

            var mqttSubscribeOptions = factory.CreateSubscribeOptionsBuilder()
                .WithTopicFilter(f => { f.WithTopic(topic); })
            .Build();

            var response = await mqttClient.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);
        }

        //--------------------------------------------------------------------------------------------------------------------
        // MQTTPublish
        // Simple code to publish to a given topic using MQTTNet QOS=0
        //--------------------------------------------------------------------------------------------------------------------
        public void MQTTPublish(string topic, string msg)
        {
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(msg)
                .WithQualityOfServiceLevel(0)
                .Build();

            if (mqttClient.IsConnected) mqttClient.PublishAsync(message);
        }

        //--------------------------------------------------------------------------------------------------------------------
        // MQTTProcessIncomingMessage
        // The MQTTEngine needs to pass the incoming message to a Business Logic Layer
        // If the TopicMessageReceivedHandler has been set -> sent the payload that direction
        private void MQTTProcessIncomingMessage(string topic, string payload, int msgID)
        {
            if (TopicMessageReceivedHandler != null) TopicMessageReceivedHandler(topic, payload, msgID);
        }
        //--------------------------------------------------------------------------------------------------------------------
    }

}
