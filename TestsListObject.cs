using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PDFWpfLIbrary
{
    public static class TestsListObject
    {
        static string _filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Test.dat";


        public static void Clear()
        {
            if (File.Exists(_filePath))
                File.Delete(_filePath);
            Value = null;
        }

        public static void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(_filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Value);
            }
        }
        public static Dictionary<string, bool> Tests
        {
            get
            {
                if (File.Exists(_filePath))
                {
                    if (Value != null)
                        return Value;
                    BinaryFormatter formatter = new BinaryFormatter();
                    Dictionary<string,bool> newPerson;
                    using (FileStream fs = new FileStream(_filePath, FileMode.OpenOrCreate))
                    {
                        newPerson = (Dictionary<string, bool>)formatter.Deserialize(fs);
                    }
                    Value = newPerson;
                    return newPerson;
                }
                else
                {
                    Value = _defaut;
                    Save();
                    return _defaut;
                }
            }
        }

        public static Dictionary<string, bool> Value = null;
        
        private static Dictionary<string, bool> _defaut
        {
            get
            {
                var g = new Dictionary<string, bool>();
                g.Add($"test1", true);
                for (int i = 0; i < 24; i++)
                {
                    g.Add($"test{2 + i}", false);
                }
                return g;
            }
        }
    }
}
