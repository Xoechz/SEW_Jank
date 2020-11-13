using ApiClient.ViewModels;
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

namespace ApiClient.Views
{
    public partial class AddCarDialog : Window
    {
        public AddCarDialog(AddCarViewModel viewModel)
        {
            viewModel.ThisWindow = this;
            DataContext = viewModel;

            InitializeComponent();
        }
    }
}
