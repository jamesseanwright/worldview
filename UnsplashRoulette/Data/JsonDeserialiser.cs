using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace UnsplashRoulette.Data
{
    class JsonDeserialiser : Deserialiser
    {
        public override T DeserialiseTo<T>(Stream data)
        {
            DataContractJsonSerializer serialiser = new DataContractJsonSerializer(typeof(T));
            return (T)serialiser.ReadObject(data);
        }
    }
}
