using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using ViewModel;

namespace View
{
   
    public class TimeEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GetDescription(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GetEnum(value.ToString());
        }

        public List<TimeEnum> GetListEnum()
        {
            List<TimeEnum> list = Enum.GetValues(typeof(TimeEnum)).Cast<TimeEnum>().ToList();
            return list;
        }

        public TimeEnum GetEnum(string value)
        {
            List<TimeEnum> list = GetListEnum();
            TimeEnum enume = default(TimeEnum);
            foreach (TimeEnum d in list)
            {
                //ЭТОТ КОД НАПИСАЛ БОГ ДАНИИИИИЛААА!!!
                var type = typeof(TimeEnum);

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

        public string GetDescription(string value)
        {
            List<TimeEnum> list = GetListEnum();
            string description = "";
            foreach (TimeEnum d in list)
            {
                var type = typeof(TimeEnum);

                var memberInfos = type.GetMember(d.ToString());
                var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == type);

                var attributes = (DescriptionAttribute)enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();
                var desc = attributes?.Description;
                if (d.ToString() == value)
                {
                    description = desc;
                    break;

                }

            }
            return description;
        }
    }
}
