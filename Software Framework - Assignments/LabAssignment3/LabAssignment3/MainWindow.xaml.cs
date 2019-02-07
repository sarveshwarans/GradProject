using LabAssignment3.Model;
using LabAssignment3.View;
using LabAssignment3.ViewModel;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabAssignment3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,ICloseable
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
            //this.DataContext = new UpdateViewModel();
            //var viewmodel = (UpdateViewModel)DataContext;
            //ListBox lb = listbox;
            //viewmodel.SetProperties(lb);
            //CollectionViewSource.GetDefaultView(members).Refresh();
        }

       
        void Close()
        {
            Window window = new Window();
            window.Close();
        }
        
    }
   
}
