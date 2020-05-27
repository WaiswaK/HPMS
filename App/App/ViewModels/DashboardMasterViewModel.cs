using App.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace App.ViewModels
{
    class DashboardMasterViewModel : INotifyPropertyChanged
    {
        private string _userfullname;
        public string UserFullName
        {
            get => Userfullname; set => Userfullname = value;
        }
        public ObservableCollection<DashboardMenuItem> MenuItems { get; }
        public string Userfullname { get => _userfullname; set => _userfullname = value; }

        public DashboardMasterViewModel()
        {
            //UserFullName = Entities.Database.UserDetails(Entities.Database.GetActiveUser()).User_name;
            MenuItems = new ObservableCollection<DashboardMenuItem>(new[]
            {
               new DashboardMenuItem { Id = 0, Title = "Home", IconSource = "home.png", TargetType = typeof(DashboardDetail) },
               new DashboardMenuItem { Id = 1, Title = "Weight", IconSource = "weight.png", TargetType = typeof(Graph) },
               new DashboardMenuItem { Id = 2, Title = "MUAC Score", IconSource = "score.png", TargetType = typeof(Graph)  },
               new DashboardMenuItem { Id = 3, Title = "Blood Sugar", IconSource = "blood.png", TargetType = typeof(Graph) },
               new DashboardMenuItem { Id = 5, Title = "HIV viral load", IconSource = "load.png", TargetType = typeof(Graph)  },
               new DashboardMenuItem { Id = 6, Title = "Settings", IconSource = "settings.png", TargetType = typeof(Graph) }
            });
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
