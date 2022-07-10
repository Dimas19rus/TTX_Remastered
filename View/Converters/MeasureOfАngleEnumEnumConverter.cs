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
    public class MeasureOfАngleEnumEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return default(MeasureOfАngleEnumEnumConverter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GetEnum(value.ToString());
        }

        public List<MeasureOfАngleEnumEnumConverter> GetListEnum()
        {
            List<MeasureOfАngleEnumEnumConverter> list = Enum.GetValues(typeof(MeasureOfАngleEnumEnumConverter)).Cast<MeasureOfАngleEnumEnumConverter>().ToList();
            return list;
        }

        public MeasureOfАngleEnumEnumConverter GetEnum(string value)
        {
            List<MeasureOfАngleEnumEnumConverter> list = GetListEnum();
            MeasureOfАngleEnumEnumConverter enume = default(MeasureOfАngleEnumEnumConverter);
            foreach (MeasureOfАngleEnumEnumConverter d in list)
            {
                //ЭТОТ КОД НАПИСАЛ БОГ ДАНИИИИИЛААА!!!
                var type = typeof(MeasureOfАngleEnumEnumConverter);

                var memberInfos = type.GetMember(d.ToString());
                var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == type);

                var attributes = (DescriptionAttribute)enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();
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
