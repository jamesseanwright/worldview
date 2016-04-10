using System.IO;
using System.Runtime.Serialization.Json;

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
