using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace WomenConsulting.Class
{
    public class ValuesTable
    {
        public List<int> MinMass { get; set; }
        public List<int> MaxMass { get; set; }
        public List<int> MinBPR { get; set; }
        public List<int> MaxBPR { get; set; }
        public List<int> MinDB { get; set; }
        public List<int> MaxDB { get; set; }
        public List<int> MinOZh { get; set; }
        public List<int> MaxOZh { get; set; }
        public List<int> MinDGK { get; set; }
        public List<int> MaxDGK { get; set; }
        public double MassConst1 { get; set; }
        public double MassConst2 { get; set; }
        public ValuesTable()
        {

        }
        [JsonIgnore]
        public static readonly string Path = "ValuesTable.json";
        public static void Save(ValuesTable vt)
        {
            var content = JsonConvert.SerializeObject(vt);
            File.WriteAllText(Path, content);
        }
        public static void Load(ValuesTable vt)
        {
            if (File.Exists(Path))
            {
                var content = File.ReadAllText(Path);
                vt = JsonConvert.DeserializeObject<ValuesTable>(content);
            }
        }
    }
}
