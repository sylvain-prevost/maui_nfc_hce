using Android.App;
using Android.Content;
using Android.Nfc.CardEmulators;
using Android.OS;
using Android.Runtime;

using System.Diagnostics;
using CommunityToolkit.Mvvm.Messaging;

namespace MauiNfcHceBootStrapExample.Platforms.Android
{        

    [
        Service(Enabled =true, Exported =true, Permission = "android.permission.BIND_NFC_SERVICE"),
        IntentFilter(new[] { global::Android.Nfc.CardEmulators.HostApduService.ServiceInterface }),
        MetaData(global::Android.Nfc.CardEmulators.HostApduService.ServiceMetaData, Resource = "@xml/apduservice")
    ]   
    
    public class HostApduService : global::Android.Nfc.CardEmulators.HostApduService
    {
        static ApduDispatcherExample ApduDispatcher;
        Stopwatch m_timer;
        bool m_initialized;        

        // serialized data
        
        public static void FirstTimeAppStartInitialization()
        {
            ApduDispatcher = new ApduDispatcherExample();
        }

        public override void OnCreate()
        {
            base.OnCreate();

            if (m_initialized == false)
            {
                Deseralize();
                m_initialized = true;
            }
        }

        private void Deseralize()
        {
            
        }

        public override void OnDeactivated([GeneratedEnum] DeactivationReason reason)
        {   
            
        }

        public override byte[] ProcessCommandApdu(byte[] commandApdu, Bundle extras)
        {
            string uiMessage = null;
            long startTime = 0;
            long endTime = 0;
            List<byte> answer = null;

            try
            {
                if (m_timer == null)
                {
                    m_timer = new Stopwatch();
                }

                m_timer.Start();
                startTime = m_timer.ElapsedMilliseconds;                    

                if ((commandApdu[0] == 0x00) && (commandApdu[1] == 0xA4) && (commandApdu[2] == 0x04))
                {
                    m_timer.Reset();
                    m_timer.Start();
                    startTime = m_timer.ElapsedMilliseconds;
                }                

                // call you own dispatcher here...
                (answer, uiMessage) = ApduDispatcherExample.Process(commandApdu);                    
            }
            finally
            {
                m_timer.Stop();
                endTime = m_timer.ElapsedMilliseconds;

                long commandExecTime = endTime - startTime;
                WeakReferenceMessenger.Default.Send(new LoggedInStrChangedMessage(commandApdu, answer.ToArray(), commandExecTime, m_timer.ElapsedMilliseconds, uiMessage));
            }                               

            return answer.ToArray();
                        
        }
    }
    
}
