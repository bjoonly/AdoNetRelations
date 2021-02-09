using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AdoNetRelationships
{
    class ViewModel: INotifyPropertyChanged
    {
        AirlinesDbContext ctx;
        private DateTime date;
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                if (date != value)
                {
                    date = value;
                    OnPropertyChanged();
                }

            }
        } 
        private City selectedDepartureCity;
        public  City  SelectedDepartureCity
        {
            get { return selectedDepartureCity; }
            set
            {
                if (value != selectedDepartureCity)
                {
                    selectedDepartureCity = value;
                    OnPropertyChanged();
                }
            }
        }
        private readonly ICollection<City> departureCities  = new ObservableCollection<City>();
        public IEnumerable<City> DepartureCities => departureCities;




        private readonly ICollection<Flight> searchFlights = new ObservableCollection<Flight>();
        public IEnumerable<Flight> SearchFlights => searchFlights;

       
        
        private Command selectCommand;
        public ICommand SelectCommand => selectCommand;


        public void FillCities()
        {
            var query = ctx.Flights.Include(nameof(Flight.Airplane)).Include(nameof(Flight.CityTo)).Select(f => f.CityFrom).Distinct();
            foreach (var item in query)
            {
                departureCities.Add(item);

            }
        }
        public ViewModel()
        {
            ctx = new AirlinesDbContext();    
            date = DateTime.Now;
            FillCities();
            selectCommand = new DelegateCommand(Search, () => selectedDepartureCity!=null && date.Date>=DateTime.Now.Date);
           
            PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(SelectedDepartureCity))
                {
                   selectCommand.RaiseCanExecuteChanged();
                }
            };
            PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(Date))
                {
                    selectCommand.RaiseCanExecuteChanged();
                }
            };
          
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public void Search()
        {
            searchFlights.Clear();

            var query = ctx.Flights.Where(f => f.CityFrom.Name == selectedDepartureCity.Name && f.DepartureTime.Year == date.Year && f.DepartureTime.Month==date.Month && f.DepartureTime.Day==date.Day);

            foreach (var item in query)
            {
                searchFlights.Add(item);

            }
        }
    }
}
