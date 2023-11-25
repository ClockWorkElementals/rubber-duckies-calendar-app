using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Taken from CS Conference App example in class.
        private void Application_DispatcherUnhandledException(object sender,
                System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Unhanded exception", MessageBoxButton.OK, MessageBoxImage.Error);

            e.Handled = true;
        }
    }
}
