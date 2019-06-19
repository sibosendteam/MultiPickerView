using System;
using System.Collections.ObjectModel;

namespace MultiPickerView.extend
{
    public class GroupModel
    {
        public object GroupName { get; set; }

        public ObservableCollection<PropertyModel> Property { get; set; }
    }



    public class PropertyModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("[PropertyModel: Id={0}, Name={1}]", Id, Name);
        }
    }
}
