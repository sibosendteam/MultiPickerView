using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MultiPickerView.extend;

namespace MultiPickerView
{
    public class MainPageViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        private ObservableCollection<string> signleSource;
        private ObservableCollection<GroupModel> twoSource;

        public MainPageViewModel()
        {
            signleSource = new ObservableCollection<string>();
            twoSource = new ObservableCollection<GroupModel>();

            InitializationData();
        }


        void InitializationData()
        {
            SingleSource.Add("Asia");
            SingleSource.Add("Europe");
            SingleSource.Add("America");
            SingleSource.Add("Africa");
            SingleSource.Add("Oceania");

            ObservableCollection<PropertyModel> enterprise = new ObservableCollection<PropertyModel>();
            enterprise.Add(new PropertyModel { Id = 1, Name = "Alibaba" });
            enterprise.Add(new PropertyModel { Id = 2, Name = "Tencent" });
            enterprise.Add(new PropertyModel { Id = 3, Name = "Baidu" });
            enterprise.Add(new PropertyModel { Id = 4, Name = "Huawei" });
            enterprise.Add(new PropertyModel { Id = 5, Name = "Wangyi" });

            ObservableCollection<PropertyModel> countries = new ObservableCollection<PropertyModel>();
            countries.Add(new PropertyModel{Id = 1, Name = "China" });
            countries.Add(new PropertyModel { Id = 2, Name = "USA" });
            countries.Add(new PropertyModel { Id = 3, Name = "Japan" });
            countries.Add(new PropertyModel { Id = 4, Name = "South Korea" });
            countries.Add(new PropertyModel { Id = 5, Name = "Russia" });
            countries.Add(new PropertyModel { Id = 6, Name = "French" });
            countries.Add(new PropertyModel { Id = 7, Name = "Germany" });

            TwoSource.Add(new GroupModel { GroupName = "enterprise", Property = enterprise });
            TwoSource.Add(new GroupModel { GroupName = "countries", Property = countries });
        }

        public ObservableCollection<string> SingleSource
        {
            get { return signleSource; }
            set { SetProperty(ref signleSource, value); }
        }

        public ObservableCollection<GroupModel> TwoSource
        {
            get { return twoSource; }
            set { SetProperty(ref twoSource, value); }
        }


        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
