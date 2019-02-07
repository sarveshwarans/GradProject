using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System;
using LabAssignment5.View;
using System.Windows;
using LabAssignment5.Model;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace LabAssignment5.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        private ObservableCollection<CustomerModel> customer;
        private CustomerModel customers;
        private string customerId;
        private string name;
        private string address;
        private string city;
        private string state;
        private string zipcode;
        private Customer selectedcustomer;
        public bool addcustomer;

        /// <summary>
        /// Constructor for MainVeiwModel class
        /// </summary>
        public MainViewModel()
        {
            customers = new CustomerModel(CustomerId, Name, Address, State, City, Zipcode);
            AddCustomer = new RelayCommand(AddMethod);
            UpdateCommand = new RelayCommand(UpdateMethod);
            DeleteCommand = new RelayCommand(Deletemethod);
            ExitWindow = new RelayCommand<Window>(ExitMethod);
            GetCustomer = new RelayCommand(GetCustomerMethod);
            Messenger.Default.Register<Customer>(this, "add", (customer) =>
            {
                try
                {
                    selectedcustomer = customer;
                    CustomerId = selectedcustomer.CustomerID.ToString();
                    this.DisplayCustomer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }

            });
            Messenger.Default.Register<Customer>(this, "edit", (customer) =>
            {
                try
                {
                    selectedcustomer = customer;
                    selectedcustomer.State1 = (from state in MMABooksEntity.mmaBooks.States
                                               where selectedcustomer.State == state.StateCode
                                               select state).SingleOrDefault();
                    this.DisplayCustomer();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    ex.Entries.Single().Reload();
                    if (MMABooksEntity.mmaBooks.Entry(customer).State == EntityState.Detached)
                    {
                        MessageBox.Show("Another user has deleted " + "that customer.", "Concurrency Error");
                    }
                    else
                    {
                        MessageBox.Show("Another user has updated " + "that customer.", "Concurrency Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }

            });
        }

        /// <summary>
        /// This method is used to close the window
        /// </summary>
        /// <param name="obj"></param>
        private void ExitMethod(Window obj)
        {
            if (obj != null)
            {
                obj.Close();
            }
        }

        /// <summary>
        /// This methid is to delete the customer from the database.
        /// </summary>
        private void Deletemethod()
        {
            try
            {
                MMABooksEntity.mmaBooks.Customers.Remove(selectedcustomer);
                MMABooksEntity.mmaBooks.SaveChanges();
                Messenger.Default.Send(new NotificationMessage("Customer Removed"));
                this.ClearControls();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
                if (MMABooksEntity.mmaBooks.Entry(selectedcustomer).State == EntityState.Detached)
                {
                    MessageBox.Show("Another user has deleted " + "that customer.", "Concurrency Error");
                    CustomerId = "";
                    ClearControls();
                }
                else if (MMABooksEntity.mmaBooks.Entry(selectedcustomer).State == EntityState.Modified)
                {
                    MessageBox.Show("Another user has updated " + "that customer.", "Concurrency Error");
                    DisplayCustomer();
                }
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.Message, "Update Exception");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

        }

        /// <summary>
        /// This method is used to clear all the fields.
        /// </summary>
        private void ClearControls()
        {
            CustomerId = "";
            Name = "";
            Address = "";
            City = "";
            Zipcode = "";
            State = "";
        }

        /// <summary>
        /// This is used to open the update window.
        /// </summary>
        private void UpdateMethod()
        {
            if (null != selectedcustomer)
            {
                UpdateCustomer update = new UpdateCustomer(selectedcustomer);
                update.Show();
            }
            else
            {
                MessageBox.Show("Please search for a customer before you" + "attempt to delete.", "No selected customer");
            }
        }

        /// <summary>
        /// This method calls the GetCustomerDetails()
        /// </summary>
        private void GetCustomerMethod()
        {
            GetCustomerDetils(CustomerId);
        }

        /// <summary>
        /// This method is used to get the customer details from the database.
        /// </summary>
        /// <param name="customerID"></param>
        public void GetCustomerDetils(string customerID)
        {
            try
            {
                int id = Convert.ToInt32(customerID);
                selectedcustomer = (from customer in MMABooksEntity.mmaBooks.Customers
                                    where customer.CustomerID == id
                                    select customer).SingleOrDefault();
                if (selectedcustomer == null)
                {
                    MessageBox.Show("No customer found with this ID. " +
                        "Please try again.", "Customer Not Found");
                }
                else
                {
                    if (!MMABooksEntity.mmaBooks.Entry(selectedcustomer).Reference("State1").IsLoaded)
                        MMABooksEntity.mmaBooks.Entry(
                       selectedcustomer).Reference("State1").Load();
                    this.DisplayCustomer();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// This method opens the add window.
        /// </summary>
        private void AddMethod()
        {
            addcustomer = true;
            AddCustomer add = new AddCustomer();
            add.Show();

        }
        [Key]
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

        [ConcurrencyCheck]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }
        [ConcurrencyCheck]
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
        [ConcurrencyCheck]
        public string State
        {
            get
            {
                return state;
            }
            set
            {

                state = value;
                RaisePropertyChanged("State");
            }
        }
        [ConcurrencyCheck]
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
                RaisePropertyChanged("City");
            }
        }
        [ConcurrencyCheck]
        public string Zipcode
        {
            get
            {
                return zipcode;
            }
            set
            {
                zipcode = value;
                RaisePropertyChanged("Zipcode");
            }
        }
        public ICommand ExitWindow { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand AddCustomer { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand GetCustomer { get; private set; }

        public void DisplayCustomer()
        {
            Name = selectedcustomer.Name;
            Address = selectedcustomer.Address;
            City = selectedcustomer.City;
            State = selectedcustomer.State1.StateName;
            Zipcode = selectedcustomer.ZipCode;
        }
        public void PutCustomerData(Customer customer)
        {
            customer.Name = Name;
            customer.Address = Address;
            customer.City = City;
            customer.State = State;
            customer.ZipCode = Zipcode;
        }

    }
}