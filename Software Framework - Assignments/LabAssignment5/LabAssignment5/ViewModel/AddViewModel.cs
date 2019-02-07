using LabAssignment5.Model;
using LabAssignment5.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace LabAssignment5.ViewModel
{
    /// <summary>
    /// AddViewModel Class is the View Model for the Add window.
    /// </summary>
    class AddViewModel : ViewModelBase
    {
        private string customerId, name, address, city, zipcode;
        private Customer customer;
        private ObservableCollection<State> statelist = new ObservableCollection<State>();
        private State selectedstate;
        
        /// <summary>
        /// AddViewModel() is the constructor for AddViewModel class.
        /// </summary>
        public AddViewModel()
        {
            MainViewModel mv = new MainViewModel();
            LoadComboBoxMethod();
            SaveCustomer = new RelayCommand<Window>(AcceptCustomer);
            ExitWindow = new RelayCommand<Window>(CloseWindow);
        }

        /// <summary>
        /// LoadComboBoxMethod() loads the combo box for the state menu.
        /// </summary>
        public void LoadComboBoxMethod()
        {
            try
            {
                var states = (from state in MMABooksEntity.mmaBooks.States
                              orderby state.StateName
                              select state).ToList();
                Statelist = new ObservableCollection<LabAssignment5.State>(states);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// This method is used to close the window.
        /// </summary>
        /// <param name="obj"></param>
        private void CloseWindow(Window obj)
        {

            if (obj != null)
            {
                obj.Close();
            }
        }

        /// <summary>
        /// This method is called when the accept button is clicked.
        /// </summary>
        /// <param name="obj"></param>
        private void AcceptCustomer(Window obj)
        {
            if (Name != null && City != null && Zipcode != null)
            {

                customer = new Customer();
                this.PutCustomerData(customer);
                MMABooksEntity.mmaBooks.Customers.Add(customer);
                MMABooksEntity.mmaBooks.SaveChanges();

                obj.Close();
                Messenger.Default.Send(new NotificationMessage("Customer Added!"));
                Messenger.Default.Send(customer, "add");
            }
            else
            {
                MessageBox.Show("Data Fields cannot be empty");
            }
        }

        /// <summary>
        /// This method is used to assign the values to the customer object.
        /// </summary>
        /// <param name="customer"></param>
        public void PutCustomerData(Customer customer)
        {
            customer.Name = Name;
            customer.Address = Address;
            customer.City = City;
            customer.State = Selectedstate.StateCode;
            customer.ZipCode = Zipcode;

        }
        public ICommand SaveCustomer { get; private set; }
        public ICommand ExitWindow { get; private set; }
        
        /// <summary>
        /// Getter and Setter for Statelist object.
        /// </summary>
        public ObservableCollection<State> Statelist
        {
            get
            {
                return statelist;
            }
            set
            {
                statelist = value;
                RaisePropertyChanged("Statelist");
            }
        }

        /// <summary>
        /// Getter and Setter for Customer
        /// </summary>
        public Customer Customer
        {
            get
            {
                return customer;
            }
            set
            {
                customer = value;
                RaisePropertyChanged("Customer");
            }
        }

        /// <summary>
        /// Getter and Setter for Selectedstate
        /// </summary>
        public State Selectedstate
        {
            get
            {
                return selectedstate;
            }
            set
            {
                selectedstate = value;
                RaisePropertyChanged("Selectedstate");
            }
        }

        /// <summary>
        /// Getter and Setter for CustomerId
        /// </summary>
        public string CustomerId
        {
            get
            {
                return customerId;
            }
            set
            {
                customerId = value;
                RaisePropertyChanged("CustomerId");
            }
        }

        /// <summary>
        /// Getter and Setter for Name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                try
                {
                    string input = value.ToString();
                    bool rt = Regex.IsMatch(input, "[a-zA-Z]+$");
                    if (value.Length == 0)
                    {
                        throw new NullReferenceException("Invalid Entry");
                    }
                    if (!rt)
                    {
                        throw new Exception("Enter Valid Name");
                    }
                    name = value;
                    RaisePropertyChanged("Name");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Enter Valid Name", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        /// <summary>
        /// Getter and Setter for Address
        /// </summary>
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                RaisePropertyChanged("Address");
            }
        }

        /// <summary>
        /// Getter and Setter for City
        /// </summary>
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                try
                {
                    string input = value.ToString();
                    bool rt = Regex.IsMatch(input, "[a-zA-Z]+$");
                    if (value.Length == 0)
                    {
                        throw new NullReferenceException("Invalid Entry");
                    }
                    if (!rt)
                    {
                        throw new Exception("Enter Valid City Name");
                    }
                    city = value;
                    RaisePropertyChanged("City");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Enter Valid City Name", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Getter and Setter for Zipcode
        /// </summary>
        public string Zipcode
        {
            get
            {
                return zipcode;
            }
            set
            {
                try
                {
                    string input = value.ToString();
                    bool rt = Regex.IsMatch(input, "[0-9]+$");
                    if (value.Length == 0)
                    {
                        throw new NullReferenceException("Invalid Entry");
                    }
                    if (!rt)
                    {
                        throw new Exception("Enter Valid Zipcode");
                    }
                    zipcode = value;
                    RaisePropertyChanged("Zipcode");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Enter Valid Zipcode", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
