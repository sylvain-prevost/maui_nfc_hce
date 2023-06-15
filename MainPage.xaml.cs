using CommunityToolkit.Mvvm.Messaging;

namespace MauiNfcHceBootStrapExample;

public partial class MainPage : ContentPage
{	

	public MainPage()
	{
		InitializeComponent();

        // Register  
        WeakReferenceMessenger.Default.Register<LoggedInStrChangedMessage>(this, (r, m) =>
        {
            ExchangedData exchangedData = m.Value;

            Timings.Text = exchangedData.totalExecutionTime.ToString();

            string operation = "";
            if (exchangedData.uiMessage != null)
            {
                operation = exchangedData.uiMessage;
            }

            if (operation == "select")
            {
                TransactionLog.Text = "";
            }            

            if (operation != "Success")
            {
                TransactionLog.Text += (operation + " : " + exchangedData.commandExecutionTime.ToString() + " ms\n");
            }

            TransactionStatusLabel.Text = "Transaction status : " + operation;
        });
    }	    
}

