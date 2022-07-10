using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using ViewModel;

namespace View
{
    public class DistanceEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return default(DistanceEnum);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GetEnum(value.ToString());
        }

        public List<DistanceEnum> GetListEnum()
        {
            List<DistanceEnum> list = Enum.GetValues(typeof(DistanceEnum)).Cast<DistanceEnum>().ToList();
            return list;
        }

        public DistanceEnum GetEnum(string value)
        {
            List<DistanceEnum> list = GetListEnum();
            DistanceEnum enume = default(DistanceEnum);
            foreach (DistanceEnum d in list)
            {
                
                var type = typeof(DistanceEnum);

                var memberInfos = type.GetMember(d.ToString());
                var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == type);

                var attributes = (DescriptionAttribute)enumValueMemberInfo.
                    GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();
                var desc = attributes?.Description;
                if (desc == value)
                {
                    enume = d;
                    break;
                }
            }
            return enume;
        }
    }
}
