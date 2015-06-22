using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionProject.Model
{
    [System.Xml.Serialization.XmlRoot("assembly")]
    public class AssemblyModel
    {
        [System.Xml.Serialization.XmlAttribute("name")]
        //Name of the assembly.
        public string Name { get; set; }
        [System.Xml.Serialization.XmlElement("namespace")]
        //Collection of namespaces in assembly.
        public ObservableCollection<NamespaceModel> Namespaces { get; set; }
        public AssemblyModel()
        {
            Namespaces = new ObservableCollection<NamespaceModel>();
            _classDictionary = new Dictionary<string, ClassModel>();
        }

        public Dictionary<string, ClassModel> _classDictionary;
        private Assembly _assembly;

        public void AnalyseAssembly(string path)
        {
            _assembly = Assembly.LoadFile(path);
            this.Name = _assembly.GetName().ToString();
            GetNamespaces();
        }
        public static bool GetVisible(Type t)
        {
            return t.IsPublic || t.IsNestedPublic || t.IsNestedFamily || t.IsNestedFamANDAssem;
        }
        public void GetNamespaces()
        {
            IEnumerable<string> namespaces = from c in _assembly.GetTypes()
                                             where GetVisible(c)
                                             select c.Namespace;
            foreach (string n in namespaces.Distinct())
            {
                NamespaceModel nmspc = new NamespaceModel() { Name = n };
                Namespaces.Add(nmspc);
                nmspc.AnalyseNamespace(_assembly, _classDictionary);
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
