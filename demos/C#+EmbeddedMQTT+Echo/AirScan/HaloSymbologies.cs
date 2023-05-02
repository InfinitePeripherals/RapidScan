using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airscan
{
    class HaloSymbologies
    {
        private static Dictionary<int, string> symbologyToText = new Dictionary<int, string>();

        static HaloSymbologies()
        {
            symbologyToText[1] = "CODE39";
            symbologyToText[2] = "CODABAR";
            symbologyToText[3] = "CODE128";
            symbologyToText[4] = "D25";
            symbologyToText[5] = "IATA";
            symbologyToText[6] = "I25";
            symbologyToText[7] = "CODE93";
            symbologyToText[8] = "UPCA";
            symbologyToText[9] = "UPCE0";
            symbologyToText[10] = "EAN8";
            symbologyToText[11] = "EAN13";
            symbologyToText[12] = "CODE11";
            symbologyToText[13] = "CODE49";
            symbologyToText[14] = "MSI";
            symbologyToText[15] = "EAN128";
            symbologyToText[16] = "UPCE1";
            symbologyToText[17] = "PDF";
            symbologyToText[18] = "CODE16K";
            symbologyToText[19] = "CODE39_FULL_ASCII";
            symbologyToText[20] = "UPCD";
            symbologyToText[21] = "TRIOPTIC";
            symbologyToText[22] = "BOOKLAND";
            symbologyToText[23] = "COUPON";
            symbologyToText[24] = "NW_7";
            symbologyToText[25] = "ISBT_128";
            symbologyToText[26] = "MICRO_PDF";
            symbologyToText[27] = "DATAMATRIX";
            symbologyToText[28] = "QRCODE";
            symbologyToText[29] = "MICRO_PDF_CCA";
            symbologyToText[30] = "POSTNET";
            symbologyToText[31] = "PLANET";
            symbologyToText[32] = "CODE32";
            symbologyToText[33] = "ISBT_128_CON";
            symbologyToText[34] = "POSTAL_JAP";
            symbologyToText[35] = "POSTAL_AUS";
            symbologyToText[36] = "POSTAL_DUTCH";
            symbologyToText[37] = "MAXICODE";
            symbologyToText[38] = "POSTAL_CAD";
            symbologyToText[39] = "POSTAL_UK";
            symbologyToText[40] = "MACRO_PDF";
            symbologyToText[44] = "MICRO_QRCODE";
            symbologyToText[45] = "AZTEC";
            symbologyToText[48] = "GS1_DATABAR";
            symbologyToText[49] = "RSS_LIMITED";
            symbologyToText[50] = "GS1_DATABAR_EXP";
            symbologyToText[55] = "SCANLET";
            symbologyToText[72] = "UPCA+2";
            symbologyToText[73] = "UPCE0+2";
            symbologyToText[74] = "EAN8+2";
            symbologyToText[75] = "EAN13+2";
            symbologyToText[80] = "UPCE1+2";
            symbologyToText[81] = "CCA_EAN128";
            symbologyToText[82] = "CCA_EAN13";
            symbologyToText[83] = "CCA_EAN8";
            symbologyToText[84] = "CCA_RSS_EXP";
            symbologyToText[85] = "CCA_RSS_LIM";
            symbologyToText[86] = "CCA_RSS_14";
            symbologyToText[87] = "CCA_UPCA";
            symbologyToText[88] = "CCA_UPCE";
            symbologyToText[89] = "CCC_EAN128";
            symbologyToText[90] = "TLC39";
            symbologyToText[97] = "CCB_EAN128";
            symbologyToText[98] = "CCB_EAN13";
            symbologyToText[99] = "CCB_EAN8";
            symbologyToText[100] = "CCB_RSS_EXP";
            symbologyToText[101] = "CCB_RSS_LIM";
            symbologyToText[102] = "CCB_RSS_14";
            symbologyToText[103] = "CCB_UPCA";
            symbologyToText[104] = "CCB_UPCE";
            symbologyToText[105] = "SIGNATURE";
            symbologyToText[113] = "MATRIX_25";
            symbologyToText[114] = "C25";
        }

        public static string SymbologyToText(int barcodeType)
        {
            if (symbologyToText.ContainsKey(barcodeType)) return symbologyToText[barcodeType];
            return "UNKNOWN";
        }

        public static string SymbologyToText(string barcodeType)
        {
            int type;
            if (Int32.TryParse(barcodeType, out type)) return SymbologyToText(type);
            return "UNKNOWN";
        }

    }
}
