using System;
using System.Configuration;

namespace Airscan
{
	internal static class Settings
	{
		// Simple Settings to Create our Own MQTT Server on this machine
		// Obviously could be MQTT Server anywhere...
		public static string mqttUid = ConfigurationManager.AppSettings["MQTTuid"];
		public static string mqttPwd = ConfigurationManager.AppSettings["MQTTpwd"];
		public static int mqttPort = Int32.Parse(ConfigurationManager.AppSettings["MQTTport"]);
		public static string mqttTopic = ConfigurationManager.AppSettings["MQTTTopic"];
	}
}