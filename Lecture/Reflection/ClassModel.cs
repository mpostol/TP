using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionProject.Model
{
    public class ClassModel
    {
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }

        [System.Xml.Serialization.XmlAttribute("namespace")]
        public string Namespace { get; set; }

        [System.Xml.Serialization.XmlElement("baseType")]
        public ClassModel BaseType { get; set; }

        [System.Xml.Serialization.XmlElement("interface")]
        public ObservableCollection<ClassModel> Interfaces { get; set; }

        [System.Xml.Serialization.XmlElement("field")]
        public ObservableCollection<ClassModel> Fields { get; set; }

        [System.Xml.Serialization.XmlElement("property")]
        public ObservableCollection<Model.ClassModel> Properties { get; set; }

        [System.Xml.Serialization.XmlElement("method")]
        public ObservableCollection<Model.MethodModel> Methods { get; set; }

        

        public ClassModel()
        {
            Fields = new ObservableCollection<ClassModel>();
            Methods = new ObservableCollection<MethodModel>();
            Properties = new ObservableCollection<ClassModel>();
            Interfaces = new ObservableCollection<ClassModel>();
        }
       
    }
}
