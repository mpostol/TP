
using System.Collections.ObjectModel;

namespace TP.Lecture.Reflection
{
  public class MethodModel
  {
    [System.Xml.Serialization.XmlAttribute("name")]
    public string Name { get; set; }

    [System.Xml.Serialization.XmlElement("returnParameter")]
    public ClassModel ReturnType { get; set; }

    [System.Xml.Serialization.XmlElement("parameter")]
    public ObservableCollection<ClassModel> ParameterList { get; set; }

    public MethodModel()
    {
      ParameterList = new ObservableCollection<ClassModel>();
    }
  }
}
