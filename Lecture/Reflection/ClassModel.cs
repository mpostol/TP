using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;

namespace TP.Lecture.Reflection
{
    public class ClassModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets the name of the class.
        /// </summary>
        /// <value>The name.</value>
        [System.Xml.Serialization.XmlAttribute("name")]
        //Name of the class.
        public string Name { get; set; }

        [System.Xml.Serialization.XmlAttribute("namespace")]
        //Name of the namespace where class is included.
        public string Namespace { get; set; }

        [System.Xml.Serialization.XmlElement("baseType")]
        //Base type of class.
        public ClassModel BaseType
        {
            get { return _baseType; }
            set
            {
                _baseType = value;
                OnPropertyChanged("BaseType");
            }
        }
        private ClassModel _baseType;

        [System.Xml.Serialization.XmlElement("interface")]
        //Implemented interfaces in class.
        public ObservableCollection<ClassModel> Interfaces { get; set; }

        [System.Xml.Serialization.XmlElement("field")]
        //Collection of fields.
        public ObservableCollection<ClassModel> Fields { get; set; }

        [System.Xml.Serialization.XmlElement("property")]
        //Collection of properties.
        public ObservableCollection<ClassModel> Properties { get; set; }

        [System.Xml.Serialization.XmlElement("method")]
        //Collection of methods.
        public ObservableCollection<MethodModel> Methods { get; set; }

        public ClassModel()
        {
            Fields = new ObservableCollection<ClassModel>();
            Methods = new ObservableCollection<MethodModel>();
            Properties = new ObservableCollection<ClassModel>();
            Interfaces = new ObservableCollection<ClassModel>();
        }

        //Method analysing Class
        public void AnalyseClass(Type type, Dictionary<string, ClassModel> classDictionary)
        {
            this.BaseType = GetBaseType(type, classDictionary);
            GetInterfaces(type, classDictionary);
            GetFields(type, classDictionary);
            GetProperties(type, classDictionary);
            GetMethods(type, classDictionary);
        }

        public ClassModel GetBaseType(Type type, Dictionary<string, ClassModel> classDictionary)
        {
            if (type.BaseType != null)
            {
                if (!classDictionary.ContainsKey(type.BaseType.Name))
                    classDictionary.Add(type.BaseType.Name, new ClassModel() { Name = type.BaseType.Name, Namespace = type.BaseType.Namespace });
                return classDictionary[type.BaseType.Name];
            }
            return null;
        }

        public void GetInterfaces(Type type, Dictionary<string, ClassModel> classDictionary)
        {
            IEnumerable<Type> interfaces = type.GetInterfaces();
            foreach (Type i in interfaces)
            {
                if (!classDictionary.ContainsKey(i.Name))
                    classDictionary.Add(i.Name, new ClassModel()
                    {
                        Name = i.Name,
                        Namespace = i.Namespace
                    });
                this.Interfaces.Add(classDictionary[i.Name]);
            }
        }

        public void GetFields(Type type, Dictionary<string, ClassModel> classDictionary)
        {
            IEnumerable<FieldInfo> fields = type.GetFields();
            foreach (FieldInfo field in fields)
            {
                if (!classDictionary.ContainsKey(field.FieldType.Name))
                    classDictionary.Add(field.FieldType.Name, new ClassModel() { Name = field.FieldType.Name });
                this.Fields.Add(classDictionary[field.FieldType.Name]);
            }
        }

        public void GetProperties(Type type, Dictionary<string, ClassModel> classDictionary)
        {
            IEnumerable<PropertyInfo> properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (!classDictionary.ContainsKey(property.PropertyType.Name))
                    classDictionary.Add(property.PropertyType.Name, new ClassModel() { Name = property.PropertyType.Name });
                this.Properties.Add(classDictionary[property.PropertyType.Name]);
            }
        }

        public void GetMethods(Type type, Dictionary<string, ClassModel> classDictionary)
        {
            IEnumerable<MethodInfo> methods = type.GetMethods();
            foreach (MethodInfo method in methods)
            {
                MethodModel temp = new MethodModel() { Name = method.Name };
                this.Methods.Add(temp);
                temp.AnalyseMethod(method, classDictionary);
            }
        }

        //Must be implemented because of BaseType property.
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
