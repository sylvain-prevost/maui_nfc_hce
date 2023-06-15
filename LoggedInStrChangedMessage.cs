using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiNfcHceBootStrapExample
{
    public class ExchangedData
    {
        public byte[] cApdu;
        public byte[] rApdu;
        public long commandExecutionTime;
        public long totalExecutionTime;
        public string uiMessage;
    }

    public class LoggedInStrChangedMessage : ValueChangedMessage<ExchangedData>
    {
        public LoggedInStrChangedMessage(byte[] cdata, byte[] rdata, long commandExectime, long totalTransactionTime, string uiMessage) : base(new ExchangedData() { cApdu = cdata, rApdu = rdata, commandExecutionTime = commandExectime, totalExecutionTime = totalTransactionTime, uiMessage = uiMessage })
        {
        }
    }    
}
