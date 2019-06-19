using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MultiPickerView.extend
{
    public class PickerView : Picker
    {
        public static readonly BindableProperty PlaceholderColorProperty =
            BindableProperty.Create(nameof(PlaceholderColor),
                                    typeof(string),
                                    typeof(PickerView), defaultValue: "#CCCCCC",
                                    defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty SelectedSourceProperty =
            BindableProperty.Create(nameof(SelectedSource),
                                    typeof(ObservableCollection<GroupModel>),
                                    typeof(PickerView), defaultValue: null,
                                    defaultBindingMode: BindingMode.TwoWay);


        public PickerView()
        {
            Items.Add("");
            SelectedIndex = 0;
        }

        public string PlaceholderColor
        {
            get { return (string)GetValue(PlaceholderColorProperty); }
            set { SetValue(PlaceholderColorProperty, value); }
        }

        public ObservableCollection<GroupModel> SelectedSource
        {
            get { return (ObservableCollection<GroupModel>)GetValue(SelectedSourceProperty); }
            set { SetValue(SelectedSourceProperty, value); }
        }


        public void OnSelectedPropertyChanged(BindableObject bindable, object newValue)
        {
            var picker = (PickerView)bindable;
            // Update value
            picker.Items[0] = newValue.ToString();

            picker.SelectedIndex = 0;
        }
    }
}
