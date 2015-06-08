using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionProject.Model
{
    public class NamespaceModel
    {
        [System.Xml.Serialization.XmlAttribute("name")]
        public string Name { get; set; }
        
        [System.Xml.Serialization.XmlElement("class")]
        public ObservableCollection<ClassModel> Classes { get; set; }

        public NamespaceModel()
        {
            Classes = new ObservableCollection<ClassModel>();
        }
    }
}
