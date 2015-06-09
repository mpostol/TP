using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace TP.Lecture.Reflection
{
  [System.Xml.Serialization.XmlRoot("assembly")]
  public class AssemblyModel
  {
    [System.Xml.Serialization.XmlAttribute("name")]
    public string Name { get; set; }
    [System.Xml.Serialization.XmlElement("namespace")]
    public ObservableCollection<NamespaceModel> Namespaces { get; set; }
    public AssemblyModel()
    {
      Namespaces = new ObservableCollection<NamespaceModel>();
      _classDictionary = new Dictionary<string, ClassModel>();
    }

    private Dictionary<string, ClassModel> _classDictionary;
    private Assembly _assembly;

    public void AnalyzeAssembly(string path)
    {
      _assembly = Assembly.LoadFile(path);
      this.Name = _assembly.GetName().ToString();
      GetNamespaces();
      foreach (NamespaceModel n in Namespaces)
      {
        IEnumerable<Type> classes = from c in _assembly.GetTypes()
                                    where c.Namespace == n.Name && c.IsClass && GetVisible(c)
                                    select c;
        foreach (Type c in classes)
        {
          if (!_classDictionary.ContainsKey(c.Name))
            _classDictionary.Add(c.Name, new ClassModel() { Name = c.Name, Namespace = c.Namespace });
          n.Classes.Add(_classDictionary[c.Name]);

          foreach (ClassModel cls in n.Classes)
          {
            if (!_classDictionary.ContainsKey(c.BaseType.Name))
              _classDictionary.Add(c.BaseType.Name, new ClassModel() { Name = c.BaseType.Name, Namespace = c.BaseType.Namespace });
            cls.BaseType = _classDictionary[c.BaseType.Name];


            IEnumerable<Type> interfaces = c.GetInterfaces();
            foreach (Type i in interfaces)
            {
              if (!_classDictionary.ContainsKey(i.Name))
                _classDictionary.Add(i.Name, new ClassModel()
                {
                  Name = i.Name,
                  Namespace = i.Namespace
                });
              cls.Interfaces.Add(_classDictionary[i.Name]);

            }

            IEnumerable<FieldInfo> fields = c.GetFields();
            foreach (FieldInfo f in fields)
            {
              if (!_classDictionary.ContainsKey(f.FieldType.Name))
                _classDictionary.Add(f.FieldType.Name, new ClassModel() { Name = f.FieldType.Name });
              cls.Fields.Add(_classDictionary[f.FieldType.Name]);
            }

            IEnumerable<PropertyInfo> props = c.GetProperties();
            foreach (PropertyInfo p in props)
            {
              if (!_classDictionary.ContainsKey(p.PropertyType.Name))
                _classDictionary.Add(p.PropertyType.Name, new ClassModel() { Name = p.PropertyType.Name });
              cls.Properties.Add(_classDictionary[p.PropertyType.Name]);
            }

            IEnumerable<MethodInfo> methods = c.GetMethods();
            foreach (MethodInfo m in methods)
            {
              cls.Methods.Add(new MethodModel() { Name = m.Name });

              foreach (MethodModel meth in cls.Methods)
              {
                if (!_classDictionary.ContainsKey(m.ReturnType.Name))
                  _classDictionary.Add(m.ReturnType.Name, new ClassModel() { Name = m.ReturnType.Name, Namespace = m.ReturnType.Namespace });
                meth.ReturnType = _classDictionary[m.ReturnType.Name];

                IEnumerable<ParameterInfo> pars = m.GetParameters();
                foreach (ParameterInfo p in pars)
                {
                  if (!_classDictionary.ContainsKey(p.ParameterType.Name))
                    _classDictionary.Add(p.ParameterType.Name, new ClassModel() { Name = p.ParameterType.Name, Namespace = p.ParameterType.Namespace });
                  meth.ParameterList.Add(_classDictionary[p.ParameterType.Name]);
                }
              }
            }
          }

        }
      }

    }
    private bool GetVisible(Type t)
    {
      return t.IsPublic || t.IsNestedPublic || t.IsNestedFamily || t.IsNestedFamANDAssem;
    }
    private void GetNamespaces()
    {
      IEnumerable<string> namespaces = from c in _assembly.GetTypes()
                                       where GetVisible(c)
                                       select c.Namespace;
      foreach (string n in namespaces.Distinct())
      {
        Namespaces.Add(new NamespaceModel() { Name = n });
      }
    }
  }
}
