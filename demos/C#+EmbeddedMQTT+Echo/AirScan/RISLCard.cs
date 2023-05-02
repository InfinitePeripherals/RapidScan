using System.Drawing; // For Colors

namespace Airscan
{
    internal class RISLCard
    {
        //--------------------------------------------------------------------------------------------------------------------
        // Simple Class to Build RISL Cards
        //--------------------------------------------------------------------------------------------------------------------
        private string risl;
        private string forecolor = "#000000";
        private string buttonColor = "#cccccc";
        //--------------------------------------------------------------------------------------------------------------------
        public RISLCard(int width, int height)
        {
            // ^StartCard|290|140
            risl = "^StartCard|" + width + "|" + height;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public RISLCard SetBackColor(string color)
        {
            // ^CardBackColor|< backcolor>
            risl += "^CardBackColor|" + color;
            return this;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public RISLCard SetBackColor(Color color)
        {
            return SetBackColor(Color2Hex(color));
        }
        //--------------------------------------------------------------------------------------------------------------------
        public RISLCard SetForeColor(string color)
        {
            // ^CardBackColor|< backcolor>
            forecolor = color;
            return this;
        }

        //--------------------------------------------------------------------------------------------------------------------
        public RISLCard SetForeColor(Color color)
        {
            return SetForeColor(Color2Hex(color));
        }
        //--------------------------------------------------------------------------------------------------------------------
        public RISLCard SetButtonColor(Color color)
        {
            return SetButtonColor(Color2Hex(color));
        }
        //--------------------------------------------------------------------------------------------------------------------
        public RISLCard SetButtonColor(string color)
        {
            buttonColor = color;
            return this;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public RISLCard SetFont(int size, bool bold)
        {
            // ^Font|20|<forecolor>|BOLD
            risl += "^Font|" + size + "|" + forecolor;
            if (bold) risl += "|BOLD";
            return this;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public RISLCard TextCenter(int y, string text)
        {
            // ^TextC|5|<text>
            risl += "^TextC|" + y + "|" + text;
            return this;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public RISLCard TextLeft(int y, string text)
        {
            // ^TextC|5|<text>
            risl += "^TextL|" + y + "|" + text;
            return this;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public RISLCard TextRight(int y, string text)
        {
            // ^TextC|5|<text>
            risl += "^TextR|" + y + "|" + text;
            return this;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public RISLCard PlayGoodSound()
        {
            //^PlaySound|GOOD
            risl += "^PlaySound|GOOD";
            return this;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public RISLCard PlayGood2Sound()
        {
            //^PlaySound|GOOD
            risl += "^PlaySound|GOOD2";
            return this;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public RISLCard PlayBadSound()
        {
            //^PlaySound|BAD
            risl += "^PlaySound|BAD";
            return this;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public RISLCard PlayAlertSound()
        {
            //^PlaySound|BAD
            risl += "^PlaySound|Alert";
            return this;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public RISLCard Vibrate()
        {
            //^Vibrate(1-4)
            risl += "^Vibrate";
            return this;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public RISLCard Vibrate2(int intensity)
        {
            //^Vibrate(1-4)
            risl += "^Vibrate(" + intensity + ")";
            return this;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public RISLCard SaveCard(string name)
        {
            risl += "^SaveCard|" + name;
            return this;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public RISLCard LoadCard(string name)
        {
            risl += "^LoadCard|" + name;
            return this;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public RISLCard CardExists(string name)
        {
            risl += "^CardExists|" + name;
            return this;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public RISLCard Set(string key, string value)
        {
            risl += "^Set|" + key + "|" + value;
            return this;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public RISLCard Clear()
        {
            //^Vibrate
            risl += "^Clear";
            return this;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public RISLCard Button(string id, string text, int x, int y, int width, int height)
        {
            risl += "^Button|" + x + "|" + y + "|" + width + "|" + height + "|" + buttonColor + "|" + text + "|" + id;
            return this;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public string GetRISLAsJson()
        {
            // AirScan wants a JSON RISL Card like
            // {"action":"risl","command":"<risl>"}
            var jsonString = "{\"action\":\"risl\",\"command\":\"" + this.ToString() + "\"}";
            return jsonString;
        }
        //--------------------------------------------------------------------------------------------------------------------
        public override string ToString()
        {
            return risl + "^ShowCard";
        }
        //--------------------------------------------------------------------------------------------------------------------
        private static string Color2Hex(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
        //--------------------------------------------------------------------------------------------------------------------

    }
}
