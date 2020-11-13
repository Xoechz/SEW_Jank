using ApiClient.ViewModels.Commands;
using ApiClient.Views;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ApiClient.Models;

namespace ApiClient.ViewModels
{
    public class CarViewModel : INotifyPropertyChanged
    {
        #region Properties

        public ObservableCollection<Car> Cars { get; set; }
        public Car SelectedCar { get; set; }

        public string ErrorText { get; set; } = string.Empty;
        public bool ErrorOccured => !string.IsNullOrEmpty(ErrorText);
        public bool ShowLoadingAnimation { get; set; } = true;

        private RestClient restClient;

        #endregion

        #region Commands

        
        public ICommand RefreshCommand => new RelayCommand((e) =>
        {
            Task.Run(() => LoadAllCars());
        },
        c => true);

        
        public ICommand AddCarCommand => new RelayCommand((e) =>
        {
            AddCarViewModel addCarViewModel = new AddCarViewModel();
            AddCarDialog addDialog = new AddCarDialog(addCarViewModel);
            addDialog.ShowDialog();

            if (addCarViewModel.ExitByOk)
            {
                DateTime now = DateTime.Now;
                Car newCar = new Car()
                {
                    Name = addCarViewModel.Name,
                    Typ = addCarViewModel.Typ,
                    CreatedAt = now,
                    ModifiedAt = now
                };

                Task.Run(() => AddCar(newCar));
            }
        },
        c => !ErrorOccured);

        
        public ICommand DeleteCarCommand => new RelayCommand((e) =>
        {
            MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete car '{SelectedCar.Name}'?", "Confirm delete action", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
                Task.Run(() => DeleteCar(SelectedCar));
        },
        c => SelectedCar != null);

        #endregion

        #region General

        public CarViewModel()
        {
            restClient = new RestClient(Constants.API_URL_BASE);
            Task.Run(() => LoadAllCars());
        }

        private async void LoadAllCars()
        {
            ShowLoadingAnimation = true;
            var request = new RestRequest("CarModels");
            var response = await restClient.ExecuteAsync(request);
            ShowLoadingAnimation = false;

            if (ResponseValid(response))
                Cars = new ObservableCollection<Car>(new JsonDeserializer().Deserialize<IList<Car>>(response));
        }

        private async void DeleteCar(Car toDelete)
        {
            if (toDelete == null)
                return;

            ShowLoadingAnimation = true;
            var request = new RestRequest($"CarModels/{toDelete.IdCar}", Method.DELETE);
            var response = await restClient.ExecuteAsync(request);

            if (ResponseValid(response))
                LoadAllCars();
            ShowLoadingAnimation = false;
        }

        private async void AddCar(Car newCar)
        {
            if (newCar == null)
                return;

            ShowLoadingAnimation = true;
            var request = new RestRequest($"CarModels", Method.POST);
            request.AddParameter("application/json", JsonConvert.SerializeObject(newCar), ParameterType.RequestBody);
            var response = await restClient.ExecuteAsync(request);            

            if (ResponseValid(response, HttpStatusCode.Created))
                LoadAllCars();
            ShowLoadingAnimation = false;
        }

        private bool ResponseValid(IRestResponse response, HttpStatusCode expectedAnswer = HttpStatusCode.OK)
        {
            if (response.ContentLength == 0)
            {
                ErrorText = $"Error: API/Server not reachable!";
                return false;
            }
            else if (response.StatusCode != expectedAnswer)
            {
                ErrorText = $"Error: {response.StatusCode}";
                return false;
            }
            else
                return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
