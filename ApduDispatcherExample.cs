using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiNfcHceBootStrapExample
{
    enum ApplicationSW : ushort
    {
        Success = 0x9000,
        UnknownError = 0x6F00
    }

    internal class ApduDispatcherExample
    {
        static List<byte> EmptyResponseApdu = new List<byte>();

        public static (List<byte>, string) Process(byte[] input)
        {
            ushort answerSW = 0x9000;
            List<byte> answer = new List<byte>();
            string uiMessage = string.Empty;

            try
            {
                if (Util.ByteArrayToHexString(input).StartsWith("00A40400"))
                {
                    uiMessage = "Select Received..";
                }

                // analyse your cApdu here...and populate rApdu & corresponding status-word
                answer.AddRange(new byte[] {});
                answerSW = 0x9000;

                // simulate some internal work
                Thread.Sleep(500);

                uiMessage += "All ok";
            } 
            catch
            {
                answer.Clear();
                answerSW = 0x6F00;
                uiMessage = "Undiagnosed Error for cApdu : " + Util.ByteArrayToHexString(input);
            }

            // concatenate status-word
            answer.Add((byte)(answerSW >> 8));
            answer.Add((byte)(answerSW));

            return (answer, uiMessage);
        }        
    }
}
