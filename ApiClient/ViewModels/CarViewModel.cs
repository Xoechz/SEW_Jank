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

        /// <summary>
        /// Command for refreshing car list.
        /// </summary>
        public ICommand RefreshCommand => new RelayCommand((e) =>
        {
            Task.Run(() => LoadAllCars());
        },
        c => true);

        /// <summary>
        /// Command for opening the 'AddCarDialog'.
        /// </summary>
        public ICommand AddCarCommand => new RelayCommand((e) =>
        {
            AddCarViewModel addCarViewModel = new AddCarViewModel();
            AddCarDialog addDialog = new AddCarDialog(addCarViewModel);
            addDialog.ShowDialog(); // Blocks main window

            // Exit by ok == valid input and user clicked add
            if (addCarViewModel.ExitByOk)
            {
                DateTime now = DateTime.Now;
                Car newCar = new Car()
                {
                    Name = addCarViewModel.Name,
                    Typ = addCarViewModel.Type,
                    CreatedAt = now,
                    ModifiedAt = now
                };

                Task.Run(() => AddCar(newCar));
            }
        },
        c => !ErrorOccured);

        /// <summary>
        /// Command for deleting a car.
        /// </summary>
        public ICommand DeleteCarCommand => new RelayCommand((e) =>
        {
            // Ask for confirmation
            MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete car '{SelectedCar.Name}'?", "Confirm delete action", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
                Task.Run(() => DeleteCar(SelectedCar));
        },
        c => SelectedCar != null);

        #endregion

        #region General

        /// <summary>
        /// Creates a CarViewModel. Tries to fetch Cars from API.
        /// </summary>
        public CarViewModel()
        {
            restClient = new RestClient(Constants.API_URL_BASE);
            Task.Run(() => LoadAllCars());
        }

        /// <summary>
        /// Fetch all cars asynchronously. (GET)
        /// </summary>
        private async void LoadAllCars()
        {
            ShowLoadingAnimation = true;
            var request = new RestRequest("Cars");
            var response = await restClient.ExecuteAsync(request);
            ShowLoadingAnimation = false;

            if (ResponseValid(response))
                Cars = new ObservableCollection<Car>(new JsonDeserializer().Deserialize<IList<Car>>(response));
        }

        /// <summary>
        /// Delete a car. (DELETE)
        /// </summary>
        /// <param name="toDelete">Car model to delete</param>
        private async void DeleteCar(Car toDelete)
        {
            if (toDelete == null)
                return;

            ShowLoadingAnimation = true;
            var request = new RestRequest($"Cars/{toDelete.IdCar}", Method.DELETE);
            var response = await restClient.ExecuteAsync(request);

            if (ResponseValid(response))
                LoadAllCars();
            ShowLoadingAnimation = false;
        }

        /// <summary>
        /// Add a new car. (POST)
        /// </summary>
        /// <param name="newCar">Car model to add</param>
        private async void AddCar(Car newCar)
        {
            if (newCar == null)
                return;

            ShowLoadingAnimation = true;
            var request = new RestRequest($"Cars", Method.POST);
            request.AddParameter("application/json", JsonConvert.SerializeObject(newCar), ParameterType.RequestBody);
            var response = await restClient.ExecuteAsync(request);            

            if (ResponseValid(response, HttpStatusCode.Created))
                LoadAllCars();
            ShowLoadingAnimation = false;
        }

        /// <summary>
        /// Checks if an API response was errornous and shows according error messages.
        /// </summary>
        /// <param name="response">Response object from API request</param>
        /// <param name="expectedAnswer">Expected HttpStatusCode. If actual code of response differs from this a parameter, it will be counted as an error.</param>
        /// <returns>False, if response was errornous. Otherwise, true.</returns>
        private bool ResponseValid(IRestResponse response, HttpStatusCode expectedAnswer = HttpStatusCode.OK)
        {
            // Server down
            if (response.ContentLength == 0)
            {
                ErrorText = $"Error: API/Server not reachable!";
                return false;
            }
            // Req error
            else if (response.StatusCode != expectedAnswer)
            {
                ErrorText = $"Error: {response.StatusCode}";
                return false;
            }
            else
                return true;
        }

        // Properties get weaved by Fody
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
