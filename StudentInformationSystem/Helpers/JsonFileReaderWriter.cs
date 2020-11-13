using Newtonsoft.Json;
using StudentInformationSystem.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StudentInformationSystem.Helpers
{
    public class JsonFileReaderWriter
    {
        // Deserialization means : convert Jsonstring into Objects
        public static Dictionary<int, Student> ReadFromJsonDeSerialization(string filePath)
        {
            string JsonContent = File.ReadAllText(filePath);

            var dicObject = JsonConvert.DeserializeObject<Dictionary<int, Student>>(JsonContent);

            return dicObject;
        }

        // Serialization means : Convert Objects into JsonString
        public static void WriteToJsonSerialization(Dictionary<int, Student> students , string filePath)
        {   
            // convert 
            string JsonContent = JsonConvert.SerializeObject(students);
            // perfrom here write operation means Save Jsoncontent into File
            File.WriteAllText(filePath, JsonContent);
        }
    }
}
