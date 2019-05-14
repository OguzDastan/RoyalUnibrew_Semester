using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace ConsumerUWP
{
    public class NavigationItem
    {
        public string MenuIcon { get; set; }
        public string MenuText { get; set; }
        public Type PageLink { get; set; }
    }


    public class BoolToVisiableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var text = (string)value;
            if (text == "Page1")
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }


    public class BackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var text = (string)value;
            if (text == "Page1")
            {
                return "#FFFFC0CB";
            }
            return "#00000000";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
