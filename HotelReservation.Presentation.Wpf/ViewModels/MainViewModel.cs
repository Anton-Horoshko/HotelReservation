using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace HotelReservation.Presentation.Wpf
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _selectedTab = "Rooms";
        public string SelectedTab
        {
            get => _selectedTab;
            set
            {
                if (_selectedTab != value)
                {
                    _selectedTab = value;
                    OnPropertyChanged(nameof(SelectedTab));
                    LoadItems();
                }
            }
        }

        public ObservableCollection<string> Items { get; set; } = new ObservableCollection<string>();

        public ICommand SelectTabCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        public MainViewModel()
        {
            SelectTabCommand = new RelayCommand(p => SelectedTab = p.ToString());
            AddCommand = new RelayCommand(_ => AddItem());
            DeleteCommand = new RelayCommand(_ => DeleteItem());
            LoadItems();
        }

        private void LoadItems()
        {
            Items.Clear();
            if (SelectedTab == "Rooms")
            {
                Items.Add("Room 101");
                Items.Add("Room 102");
            }
            else if (SelectedTab == "Reservations")
            {
                Items.Add("Reservation 001");
                Items.Add("Reservation 002");
            }
            else if (SelectedTab == "Guests")
            {
                Items.Add("John Doe");
                Items.Add("Jane Smith");
            }
        }

        private void AddItem()
        {
            Items.Add($"New {SelectedTab} Item");
        }

        private void DeleteItem()
        {
            if (Items.Count > 0) Items.RemoveAt(Items.Count - 1);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
