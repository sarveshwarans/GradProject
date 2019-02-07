using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabAssignment7A.Model
{
    public class FlickerImage:ObservableObject
    {
        private string title;
        private string url;
        
        //Getters and Setters
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                RaisePropertyChanged("Title");
            }
        }
        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
                RaisePropertyChanged("Url");
            }
        }
    }
}
