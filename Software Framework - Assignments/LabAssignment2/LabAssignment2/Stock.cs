using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LabAssignment2
{
    /// <summary>
    /// This class contains the Stock related information. The Construtor initializes all its object properties, creates a thread and starts it.
    /// Activate method makes use of lock to keep the thread in sync and update the stock value accordingly in ChangeStockValue method.
    /// Events are generated using delegates.
    /// </summary>
    public class Stock
    {
        public string Name;
        public int InitialValue;
        int MaxChange;
        int Threshold;
        int currentValue;
        int notificationThreshold;
        int numberChanges;
        private readonly static object _object = new object();

        /// <summary>
        /// Constructor - All the parameters are initialized to the object. 
        /// Thread is created and started.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="startingValue"></param>
        /// <param name="maxChange"></param>
        /// <param name="threshold"></param>
        public Stock(string name, int startingValue, int maxChange, int threshold)
        {
            this.Name = name;
            this.InitialValue = startingValue;
            this.MaxChange = maxChange;
            this.Threshold = threshold;
            currentValue = InitialValue;
            notificationThreshold = threshold;
            var thread = new Thread(Activate);
            thread.Start();

        }
        
        /// <summary>
        /// Activate method updates the value of the stock using ChangeStockValue() for every half second.
        /// Lock is implemented here so that the threads are in sync.
        /// </summary>
        public void Activate()
        {
            for (int i = 0; i < 10; i++)
            {
                lock (_object)
                {
                    if(Program.detaliedLogOutput)
                        Console.WriteLine("Lock Started for Stock : {0}, Initial Value : {1}", this.Name, this.InitialValue);
                    ChangeStockValue();
                    Thread.Sleep(500);
                    if(Program.detaliedLogOutput)
                        Console.WriteLine("Lock Released for Stock : {0}, Initial Value : {1}", this.Name, this.InitialValue);
                }
            }
        }

        /// <summary>
        /// ChangeStockValue method updates the value of the stock.
        /// If the threshold of the stock is reached, an event is created and OnThresholdReached() is called.
        /// </summary>
        public void ChangeStockValue()
        {
            Random randomNum = new Random();
            this.currentValue += randomNum.Next(1, MaxChange);
            this.numberChanges++;
            if (Math.Abs(currentValue - InitialValue) > notificationThreshold)
            {
                if (Program.detaliedLogOutput)
                    Console.WriteLine("Threshold reached for Stock : {0}, Initial Value : {1}", this.Name, this.InitialValue);
                StockNotificationEventArgs stockEvent = new StockNotificationEventArgs();
                stockEvent.Name = Name;
                stockEvent.CurrentValue = currentValue;
                stockEvent.NumberChanges = numberChanges;
                OnThresholdReached(stockEvent);
            }
            else
            {
                if (Program.detaliedLogOutput)
                    Console.WriteLine("Threshold not reached for Stock : {0}, Initial Value : {1}", this.Name, this.InitialValue);
            }
        }

        /// <summary>
        /// OnThresholdReached method invokes the event and informs all the listener about this event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnThresholdReached(StockNotificationEventArgs e)
        {
            stockEvent?.Invoke(Name,currentValue,numberChanges);
        }

        public Action<String, int, int> stockEvent;
    }

    /// <summary>
    /// Getters and Setters are initialized in the StockNotificationEventArgs class
    /// </summary>
    public class StockNotificationEventArgs
    {
        public string Name
        {
            get; set;
        }
        public int CurrentValue
        {
            get; set;
        }
        public int NumberChanges
        {
            get; set;
        }
    }
}
