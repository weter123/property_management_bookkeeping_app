using RecordKeepingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordKeepingApp
{
    public static class ErrorHandler
    {
        public static void HandleException(Exception ex)
        {
            Debug.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
