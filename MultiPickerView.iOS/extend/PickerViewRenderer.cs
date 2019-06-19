using System;
using Foundation;
using MultiPickerView.extend;
using MultiPickerView.iOS.extend;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(PickerView), typeof(PickerViewRenderer))]
namespace MultiPickerView.iOS.extend
{
    public class PickerViewRenderer : PickerRenderer
    {
        public static int DisplayWidth = (int)UIScreen.MainScreen.Bounds.Width;

        private PickerView _pickerView;


        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BorderStyle = UITextBorderStyle.RoundedRect;

                _pickerView = e.NewElement as PickerView;

                //if(e.OldElement != null || e.NewElement != null)
                //SetPlaceholderColor(_pickerView);

                var _picker = new UIPickerView
                {
                    Model = new PickerSource(_pickerView)
                };

                SelectPickerValue(_picker, _pickerView);

                Control.InputView = _picker;
            }
        }


        private void SelectPickerValue(UIPickerView customModelPickerView, PickerView pickerView)
        {
            if (pickerView == null)
                return;
        }


        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null)
                return;

            if (e.PropertyName == Picker.SelectedIndexProperty.PropertyName)
            {
                var picker = (UIPickerView)Control.InputView;

                SelectPickerValue(picker, _pickerView);
            }
        }

        void SetPlaceholderColor(PickerView picker)
        {
            string placeholderColor = picker.PlaceholderColor;
            UIColor color = UIColor.FromRGB(GetRed(placeholderColor), GetGreen(placeholderColor), GetBlue(placeholderColor));

            var placeholderAttributes = new NSAttributedString(picker.Title, new UIStringAttributes()
            { ForegroundColor = color });

            if (Control != null)
                Control.AttributedPlaceholder = placeholderAttributes;
        }


        float GetRed(string color)
        {
            Color c = Color.FromHex(color);
            return (float)c.R;
        }

        float GetGreen(string color)
        {
            Color c = Color.FromHex(color);
            return (float)c.G;
        }

        float GetBlue(string color)
        {
            Color c = Color.FromHex(color);
            return (float)c.B;
        }


        public class PickerSource : UIPickerViewModel
        {
            private PickerView _pickerView { get; }

            public int SelectedIndex { get; internal set; }

            public string SelectedItem { get; internal set; }

            public PickerSource(PickerView pickerView)
            {
                _pickerView = pickerView;

                SelectedIndex = 0;
            }

            public override nint GetComponentCount(UIPickerView pickerView)
            {
                return 2;
            }

            public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
            {
                if (component == 0)
                {
                    return _pickerView.SelectedSource.Count;
                }
                else
                {
                    GroupModel p = _pickerView.SelectedSource[SelectedIndex];
                    return p.Property.Count;
                }
            }


            public override string GetTitle(UIPickerView pickerView, nint row, nint component)
            {
                if (component == 0)
                {
                    GroupModel p = _pickerView.SelectedSource[(int)row];
                    return (string)p.GroupName;
                }
                else
                {
                    GroupModel p = _pickerView.SelectedSource[SelectedIndex];
                    return p.Property[(int)row].Name;
                }
            }


            public override void Selected(UIPickerView pickerView, nint row, nint component)
            {
                if (component == 0)
                {
                    SelectedIndex = (int)pickerView.SelectedRowInComponent(0);

                    pickerView.ReloadComponent(1);
                }

                // 获取选中的group
                GroupModel p = _pickerView.SelectedSource[SelectedIndex];

                if (p.Property.Count <= 0)
                    return;

                // 获取选中的property
                int index = (int)pickerView.SelectedRowInComponent(1);
                SelectedItem = p.GroupName + "-" + p.Property[index].Name;


                if (!string.IsNullOrEmpty(SelectedItem))
                    _pickerView.OnSelectedPropertyChanged(_pickerView, SelectedItem);
            }


            public override nfloat GetComponentWidth(UIPickerView pickerView, nint component)
            {
                var screenWidth = DisplayWidth;

                if (component == 0)
                {
                    return screenWidth * 0.3f;
                }
                else
                {
                    return screenWidth * 0.6f;
                }
            }
        }
    }
}
