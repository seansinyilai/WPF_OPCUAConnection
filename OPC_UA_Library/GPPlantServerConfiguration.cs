using GPPlant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OPC_UA_Library
{
    [DataContract(Namespace = Namespaces.GPPlant)]
    public class GPPlantServerConfiguration
    {
        public GPPlantServerConfiguration()
        {
            Initialize();
        }
        [OnDeserializing()]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }
        private void Initialize()
        {

        }
    }
}
