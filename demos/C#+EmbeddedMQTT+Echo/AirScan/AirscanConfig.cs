using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Airscan
{
    /* Simple class to crate an Airscan Config payload that looks something like:

        Airscan {
            "action": "config",
            "command": {
                "mqttServer": {
                    "host": "<host>",
                    "username": "<uid>",
                    "password": "<pwd>",
                    "port": 1883,
                    "topic": "<topic>"
                },
                "verbs": [
                    {
                        "name": "Echo",
                        "mode": 1
                    }
                ]
            }
        }

     */
    //------------------------------------------------------------------------------------------------------------
    public class AirscanConfig
    {
        private string action;
        private MqttServer mqttServer;
        private List<Verb> verbs;
        //------------------------------------------------------------------------------------------------------------
        public AirscanConfig()
        {
            action = "config";
            mqttServer = null;
            verbs = new List<Verb>();
        }
        //------------------------------------------------------------------------------------------------------------
        public AirscanConfig WithMQTTServer(string host, string uid, string pwd, int port, string topic)
        {
            this.mqttServer = new MqttServer { host=host, username=uid, password=pwd, port=port, topic=topic };
            return this;
        }
        //------------------------------------------------------------------------------------------------------------
        public AirscanConfig AddVerb(string verb, int mode)
        {
            verbs.Add(new Verb { name= verb, mode = mode });
            return this;
        }
        //------------------------------------------------------------------------------------------------------------
        public override string ToString()
        {
            Object jsonObj;

            // Make an Anonymouse Object
            if ( mqttServer != null) 
                jsonObj =  new { action = this.action, command = new { mqttServer = this.mqttServer, verbs = this.verbs } }; // simple anonymous type to build the json string out of objects
            else
                jsonObj = new { action = this.action, command = new {  verbs = this.verbs } }; // simple anonymous type to build the json string out of objects

            // Convert to JSON String 
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var output = "AirScan " + serializer.Serialize(jsonObj); // Got it

            return output;
        }

        //------------------------------------------------------------------------------------------------------------
        // Simple internal class to hold the MQTT Info
        private class MqttServer
        {
            public string host { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public int port { get; set; }
            public string topic { get; set; }
        }
        //------------------------------------------------------------------------------------------------------------
        // Simple internal class to hold the Verb Info
        private class Verb
        {
            public string name { get; set; }
            public int mode { get; set; }
        }
        //------------------------------------------------------------------------------------------------------------


    }
}
