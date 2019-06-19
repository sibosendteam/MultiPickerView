## MultiPickerView

Multi-column linkage pickerView based on c# (xamarin.forms)

The project only realized the iOS pickerview linkage effect

## Effect
![Multiple pickerview]("screenshot/pickerview.gif")

## Usage

This linkage effect refers to ios implementation, there are only three methods, they are **Groupmodel.cs、  Pickerview.cs、Pickerviewrenderer. cs**, which are very simple to use.

It contains all the properties of the native pickerView control.

```
<?xml version="1.0" encoding="utf-8"?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" 
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:MultiPickerView" 
             xmlns:pickerView="clr-namespace:MultiPickerView.extend;assembly=MultiPickerView"
             x:Class="MultiPickerView.MainPage">
    <StackLayout>
        <pickerView:PickerView
            Margin="15"
            Title="two columns"
            HorizontalOptions="FillAndExpand" 
            SelectedSource="{Binding TwoSource}">
        </pickerView:PickerView>
    </StackLayout>
</ContentPage>
```

## License
Copyright 2019-2025 Sibosend

This file is part of MultiPickerView.

MultiPickerView is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

MultiPickerView is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with MultiPickerView.  If not, see <http://www.gnu.org/licenses/>.