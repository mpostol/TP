using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionProject.Model
{
    public class NamespaceModel
    {
        [System.Xml.Serialization.XmlAttribute("name")]
        //Name of the namespace.
        public string Name { get; set; }

        [System.Xml.Serialization.XmlElement("class")]
        //Collection of classes in namespace.
        public ObservableCollection<ClassModel> Classes { get; set; }

        public NamespaceModel()
        {
            Classes = new ObservableCollection<ClassModel>();
        }

        public void AnalyseNamespace(Assembly assembly, Dictionary<string, ClassModel> classDictionary)
        {
            GetClasses(assembly, classDictionary);

        }

        private void GetClasses(Assembly assembly, Dictionary<string, ClassModel> classDictionary)
        {
            IEnumerable<Type> classes = from _class in assembly.GetTypes()
                                        where _class.Namespace == Name &&
                                        _class.IsClass &&
                                        AssemblyModel.GetVisible(_class)
                                        select _class;
            foreach (Type _class in classes)
            {
                if (!classDictionary.ContainsKey(_class.Name))
                    classDictionary.Add(_class.Name, new ClassModel() { Name = _class.Name, Namespace = _class.Namespace });
                this.Classes.Add(classDictionary[_class.Name]);
                classDictionary[_class.Name].AnalyseClass(_class, classDictionary);
            }
        }
    }
}
