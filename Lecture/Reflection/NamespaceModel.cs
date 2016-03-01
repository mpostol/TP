
using System.Collections.ObjectModel;

namespace TP.Lecture.Reflection
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
