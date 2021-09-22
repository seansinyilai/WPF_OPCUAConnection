using Newtonsoft.Json;
using Opc.Ua;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPF_OPCUAConnection.Converters
{
    public class DictionaryItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //var json = JsonConvert.SerializeObject(value);
            //var result = JsonConvert.DeserializeObject<Dictionary<string, BaseDataVariableState>>(json);
            var dict = value.GetType().GetProperties().ToDictionary(property => property.Name, property => property.GetValue(value));
            var a = dict["Key"];
            var b = dict["Value"] as BaseDataVariableState;
            var c=  b.Value;
          //  var dict = value as Dictionary<string, BaseDataVariableState>;
            if (dict != null)
            {
                return c;
            }
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
