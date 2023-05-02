using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airscan.MQTT
{
    internal class TopicRouter
    {
        //--------------------------------------------------------------------------------------------------------------------
        public TopicRouter()
        {
            // 1) The client will connect to the MQTT Server
            // 2) Whenever message is recieved will call the TopicMessageReceived Below
            // 3) The payload can be insepected to see what to do
            // 4) An appriopriate "Processor" will get the payload to do the work
            MQTTClient.Instance.TopicMessageReceivedHandler = this.TopicMessageReceived;  
        }
        //--------------------------------------------------------------------------------------------------------------------
        public void TopicMessageReceived(string topic, string payload, int msgID)
        {
            // i.e. payloads:
            // { "event":"barcode","serial":"PSDHEC","device":"Halo","bundle":"com.ipc.haloring.airscan","utcTime":"2022-06-06T16:19:22-0700","value":{ "barcode":"1115002125","type":3},"verb":"Echo"}

            try
            {
                var json = Jil.JSON.DeserializeDynamic(payload);

                // Decide who should process, Simple Echo Process
                if (json["event"] == "barcode" && json["verb"] == "Echo") Processors.EchoProcessor.TopicMessageReceived(topic, payload, msgID); // Send a simple card showing the barcode/symbology scanned
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // unexpected but igore...
            }
        }
        //--------------------------------------------------------------------------------------------------------------------
    }
}
