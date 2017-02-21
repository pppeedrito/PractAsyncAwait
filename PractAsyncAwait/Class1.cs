using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PractAsyncAwait
{
    class Class1
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string gander { get; set; }
        public string company { get; set; }
        public string email { get; set; }
        public string country { get; set; }

        public static List<Class1> LeerJsonPropiedades()
        {
            var Json = File.ReadAllText("people.json");
            var c1 = JsonConvert.DeserializeObject<List<Class1>>(Json);
            return c1;
        }

    }
}
