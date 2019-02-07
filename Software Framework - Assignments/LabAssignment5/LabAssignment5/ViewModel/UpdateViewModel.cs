using LabAssignment5.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LabAssignment5.ViewModel
{
    class UpdateViewModel : ViewModelBase
    {
        private string customerId;
        private string name;
        private string address;
        private string state;
        private string city;
        private string zipcode;
        Customer customer;
        public Customer selectedcustomer;
        CustomerModel customermodel;
        private ObservableCollection<State> statelist = new ObservableCollection<State>();
        private State selectedstate;

        /// <summary>
        /// Constructor for UpdateViewModel class.
        /// </summary>
        /// <param name="selectedcustomer"></param>
        public UpdateViewModel(Customer selectedcustomer)
        {
            customermodel = new CustomerModel(CustomerId, Name, Address, City, State, Zipcode);
            LoadComboxMethod();
            this.selectedcustomer = selectedcustomer;
            UpdateCustomer = new RelayCommand<Window>(DoUpdate);
            ExitWindow = new RelayCommand<Window>(CloseWindow); 
            this.DisplayCustomer();
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
        /// This method is used to update the customer fields in the database.
        /// </summary>
        /// <param name="obj"></param>
        private void DoUpdate(Window obj)
        {
            Customer customer = MMABooksEntity.mmaBooks.Customers.SingleOrDefault
            (b => b.CustomerID == selectedcustomer.CustomerID);
            try
            {
               
                this.PutCustomerData(customer);
                MMABooksEntity.mmaBooks.SaveChanges();
                obj.Close();
                Messenger.Default.Send(new NotificationMessage("Customer Updated!"));
                Messenger.Default.Send(customer, "edit");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
                if (MMABooksEntity.mmaBooks.Entry(customer).State == EntityState.Detached)
                {

                    Window window = new Window();
                    MessageBox.Show("Another user has deleted " + "that customer.", "Concurrency Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else
                {
                    MainViewModel mv = new MainViewModel();
                    var entry = ex.Entries.Single();
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                    Window window = new Window();
                    MessageBox.Show("Another user has updated " + "that customer.", "Concurrency Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    obj.Close();
                    Messenger.Default.Send(customer, "edit");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

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
        /// This method is used to load the combo box for the state.
        /// </summary>
        public void LoadComboxMethod()
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

        public void PutCustomerData(Customer customer)
        {
            customer.Name = Name;
            customer.Address = Address;
            customer.City = City;
            customer.State = Selectedstate.StateCode;
            customer.ZipCode = Zipcode;
        }
        public void DisplayCustomer()
        {
            Name = selectedcustomer.Name;
            Address = selectedcustomer.Address;
            City = selectedcustomer.City;
            Selectedstate = (from state in MMABooksEntity.mmaBooks.States
                             where selectedcustomer.State == state.StateCode
                             select state).SingleOrDefault();
            Zipcode = selectedcustomer.ZipCode;

        }
        public ICommand UpdateCustomer { get; private set; }
        public ICommand ExitWindow { get; private set; }

        /// <summary>
        /// Getter and Setter for CustomerId.
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
        /// Getter and Setter for Name.
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
                    name = value;
                    RaisePropertyChanged("Name");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Enter Valid Name", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Getter and Setter for Address.
        /// </summary>
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                try
                {
                    address = value;
                    RaisePropertyChanged("Address");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Enter Valid Address", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Getter and Setter for State.
        /// </summary>
        public string State
        {
            get
            {
                return state;
            }
            set
            {
                try
                {
                    state = value;
                    RaisePropertyChanged("State");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Getter and Setter for City.
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
                    city = value;
                    RaisePropertyChanged("City");
                }
                catch(Exception ex)
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
                    zipcode = value;
                    RaisePropertyChanged("Zipcode");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Enter Valid Zipcode", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
