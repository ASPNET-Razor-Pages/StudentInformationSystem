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
            Dictionary<int, Student> dictObjects = null;
            try
            {
                string JsonContent = File.ReadAllText(filePath);
                dictObjects = JsonConvert.DeserializeObject<Dictionary<int, Student>>(JsonContent);
                return dictObjects;
            }
            catch(Exception ex)
            {

            }
            return dictObjects;
        }

        // Serialization means : Convert Objects into JsonString
        public static void WriteToJsonSerialization(Dictionary<int, Student> students , string filePath)
        {
            try
            {
                // convert 
                string JsonContent = JsonConvert.SerializeObject(students);
                // perfrom here write operation means Save Jsoncontent into File
                File.WriteAllText(filePath, JsonContent);
            }
            catch(Exception ex)
            {

            }            
        }
    }
}
