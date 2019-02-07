using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

namespace LabAssignment2
{
    /// <summary>
    /// Broker related information are handled in this StockBroker class.
    /// Constructor initializes the broker name.
    /// Whenever a new stock is added, it is added to the stock list of the broker and it starts to listen to the events for that stock.
    /// </summary>
    class StockBroker
    {
        string BrokerName;
        List<Stock> StocksList = new List<Stock>();
        string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private const int NumberOfRetries = 3;
        Dictionary<string, int> stockInitialValueHash = new Dictionary<string, int>();
        private readonly static object _object = new object();

        /// <summary>
        /// Constructor - Initializes the broker name.
        /// </summary>
        /// <param name="brokerName"></param>
        public StockBroker(string brokerName)
        {
            BrokerName = brokerName;
        }

        /// <summary>
        /// AddStock method adds the stock to the brokers stock list.
        /// It starts to listen to the events related to that stock.
        /// </summary>
        /// <param name="newStock"></param>
        public void AddStock(Stock newStock)
        {
            StocksList.Add(newStock);
            stockInitialValueHash.Add(newStock.Name, newStock.InitialValue);
            newStock.stockEvent += Stock_EventHandler;
        }

        /// <summary>
        /// Stock_EvenHandler handles the event whenever there is a event sent to its listeners.
        /// Two main functions are
        ///     - Print the information to the console.
        ///     - Write the information to the file by calling OutputToFile().
        /// </summary>
        /// <param name="stockName"></param>
        /// <param name="currentValue"></param>
        /// <param name="numberChanges"></param>
        public void Stock_EventHandler(string stockName, int currentValue, int numberChanges)
        {
            if (Program.firstTimeExecConsole)
            {
                Console.WriteLine(String.Format("{0,-10}\t{1,-10}\t{2,-10}\t{3,-10}", "Broker", "Stock", "Value", "Changes"));
                Program.firstTimeExecConsole = false;
            }
            Console.WriteLine(String.Format("{0,-10}\t{1,-10}\t{2,-10}\t{3,-10}", BrokerName, stockName, currentValue, numberChanges));
            DateTime dt = DateTime.Now;
            String stockDetailedInfo = String.Format("{0,-10}\t\t\t{1,-10}\t\t{2,-10}\t{3,-10}",
                dt.ToString(new CultureInfo("en-US")), stockName, stockInitialValueHash[stockName], currentValue);
            OutputToFile(stockDetailedInfo);
        }

        /// <summary>
        /// OutputToFile method saves the information to a file.
        /// </summary>
        /// <param name="stockDetailedInfo"></param>
        private void OutputToFile(string stockDetailedInfo)
        {
            if(Program.firstTimeExecFile)
            {
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(mydocpath, "Stock_Information.txt"), true))
                {
                    outputFile.WriteLine(String.Format("{0,-10}\t\t\t{1,-10}\t\t{2,-10}\t{3,-10}", "Date and Time", "Stock Name", "Initial Value", "Current Value"));
                    Program.firstTimeExecFile = false;
                }
            }
            for (int i = 1; i <= NumberOfRetries; ++i)
            {
                try
                {
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(mydocpath, "Stock_Information.txt"), true))
                    {
                        outputFile.WriteLine(stockDetailedInfo);
                        break;
                    }
                }
                catch (IOException) when (i <= NumberOfRetries)
                {
                    Console.WriteLine("Exception while saving this entry: {0}", stockDetailedInfo);
                }
            }
        }
    }
}
