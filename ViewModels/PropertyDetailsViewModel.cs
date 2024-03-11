using CommunityToolkit.Mvvm.ComponentModel;
using RecordKeepingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordKeepingApp.ViewModels
{
    [QueryProperty(nameof(Property), "Property")]
    public partial class PropertyDetailsViewModel : BaseViewModel
    {

        public PropertyDetailsViewModel() { 
        
        }

        [ObservableProperty]
        Property property;
    }
}
