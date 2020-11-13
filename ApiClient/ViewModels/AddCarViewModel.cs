using ApiClient.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ApiClient.ViewModels
{
    public class AddCarViewModel : INotifyPropertyChanged
    {
        #region Properties and Command

        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public bool ExitByOk { get; set; } = false;

        public Window ThisWindow { get; set; }

        // Command for adding new car / closing dialog.
        public ICommand AddCommand => new RelayCommand((e) =>
        {
            ExitByOk = true;
            ThisWindow?.Close();
        },
        (c) => !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Type));

        #endregion

        #region General

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
