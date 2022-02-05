using MahApps.Metro.Controls;
using Office.Models;
using Office.ViewModels;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Office.Views
{
    /// <summary>
    /// Logika interakcji dla klasy AddEditEmployeeView.xaml
    /// </summary>
    public partial class AddEditEmployeeView : MetroWindow
    {
        public AddEditEmployeeView(Employee employee = null)
        {
            InitializeComponent();

            DataContext = new AddEditEmployeeViewModel(employee);
        }
    }
}
