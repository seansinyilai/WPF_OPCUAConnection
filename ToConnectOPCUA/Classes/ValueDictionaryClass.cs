using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToConnectOPCUA.Classes
{
    public class ValueDictionaryClass
    {
        public string Identifier { get; set; }
        public string FieldsName { get; set; }
        public object FieldsValue { get; set; }
        public ValueDictionaryClass()
        {

        }
    }
}
