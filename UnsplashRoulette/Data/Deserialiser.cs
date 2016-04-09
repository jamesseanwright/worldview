using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace UnsplashRoulette.Data
{
    abstract class Deserialiser
    {
        public abstract T DeserialiseTo<T>(Stream data) where T : class;
    }
}
