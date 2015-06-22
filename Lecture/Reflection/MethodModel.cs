using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionProject.Model
{
    public class MethodModel : INotifyPropertyChanged
    {
        [System.Xml.Serialization.XmlAttribute("name")]
        //Name of the method.
        public string Name { get; set; }

        [System.Xml.Serialization.XmlElement("returnParameter")]
        //Type of returning parameter.
        public ClassModel ReturnType
        {
            get { return _returnType; }
            set
            {
                _returnType = value;
                OnPropertyChanged("ReturnType");
            }
        }
        private ClassModel _returnType;

        [System.Xml.Serialization.XmlElement("parameter")]
        //Collection of parameters.
        public ObservableCollection<ClassModel> ParameterList { get; set; }


        public MethodModel()
        {
            ParameterList = new ObservableCollection<ClassModel>();
        }

        public void AnalyseMethod(MethodInfo method, Dictionary<string, ClassModel> classDictionary)
        {
            this.Name = method.Name;
            this.ReturnType = GetReturnType(method, classDictionary);
            GetParameterList(method, classDictionary);
        }

        public ClassModel GetReturnType(MethodInfo method, Dictionary<string, ClassModel> classDictionary)
        {
            Type retType = method.ReturnType;
            if (!classDictionary.ContainsKey(retType.Name))
                classDictionary.Add(retType.Name, new ClassModel() { Name = retType.Name, Namespace = retType.Namespace });
            return classDictionary[retType.Name];
        }

        public void GetParameterList(MethodInfo method, Dictionary<string, ClassModel> classDictionary)
        {
            IEnumerable<ParameterInfo> parameters = method.GetParameters();
            foreach (ParameterInfo parameter in parameters)
            {
                if (!classDictionary.ContainsKey(parameter.ParameterType.Name))
                    classDictionary.Add(parameter.ParameterType.Name, new ClassModel() { Name = parameter.ParameterType.Name, Namespace = parameter.ParameterType.Namespace });
                this.ParameterList.Add(classDictionary[parameter.ParameterType.Name]);
            }
        }



        //Must be implemented because of ReturnType property.
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged = null;
        virtual protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        #endregion
    }
}
