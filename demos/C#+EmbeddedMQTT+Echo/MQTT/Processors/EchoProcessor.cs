using System;
using System.Drawing;

namespace Airscan.MQTT.Processors
{
    class EchoProcessor
    {
        // Trivial Echo Server
        public static void TopicMessageReceived(string topic, string payload, int msgID)
        {
            //Sample: payload "{\"event\":\"barcode\",\"serial\":\"TVE25I\",\"device\":\"Halo\",\"bundle\":\"com.ipc.haloring.airscan\",\"utcTime\":\"2022-06-16T15:05:43+0800\",\"value\":{\"barcode\":\"@\\n\\u001e\\rANSI ...",\"type\":17},\"verb\":\"AAMVA\"}" string
            string outTopic = topic.Replace("/out", "/in");
            try
            {
                // 1) Parse the Barcode
                var json = Jil.JSON.DeserializeDynamic(payload);

                // 2) Get the Info
                int symbology = Int32.Parse((string)json["value"]["type"]);   // json from Airscan has barcode type  at value.type
                string barcode = json["value"]["barcode"]; // json from Airscan has barcode text at value.barcode
                string symbologyText = HaloSymbologies.SymbologyToText(symbology);  // i.e. 1=CODE39 etc.

                // 3) Construct simple card
                RISLCard answer = GetEchoCard(symbologyText, barcode, "Type:" + symbology);

                // Return it!
                MQTTClient.Instance.MQTTPublish(outTopic, answer.GetRISLAsJson());
            }
            catch (Exception ex)
            {
                // If Error just send back a RED Error Card
                RISLCard errorCard = GetErrorCard("Unexpected Error:" + ex.Message);
                Console.WriteLine(ex.Message); // unexpected but igore...
                MQTTClient.Instance.MQTTPublish(outTopic, errorCard.GetRISLAsJson());
            }
        }
        //--------------------------------------------------------------------------------------------------------------------
        private static RISLCard GetEchoCard(string symbologyText, string barcode, string symbology)
        {
            RISLCard response = new RISLCard(290, 220).Clear().SetBackColor(Color.Blue);
            response.SetForeColor(Color.White).SetFont(44, false).TextCenter(2, symbologyText); // Show Header
            response.SetFont(44, false).TextCenter(50, symbology); // Show the Birthday (medium Font0
            response.SetForeColor(Color.Cyan).SetFont(30, true).TextCenter(130, barcode);     // Show the Route

            response.PlayGoodSound();
            return response;
        }
        //--------------------------------------------------------------------------------------------------------------------
        static public RISLCard GetErrorCard(string msg)
        {
            RISLCard errorCard = new RISLCard(290, 240).SetBackColor(Color.Red);
            errorCard.SetForeColor(Color.White);
            errorCard.SetFont(32, false).TextCenter(3, "Error");
            errorCard.SetFont(44, true).TextCenter(55, msg);
            errorCard.PlayBadSound().Vibrate();
            return errorCard;
        }
        //--------------------------------------------------------------------------------------------------------------------

    }

}
