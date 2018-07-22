using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TPA.Reflection.UnitTest.Execution
{
  internal class DataSource : INotifyPropertyChanged
  {
    private int m_intField = 0;
    public int IntProperty {
      get { return m_intField; }
      set {
        m_intField = value;
        OnPropertyChanged("IntProperty");
      }
    }
  
    private string m_stringField = "";
    public string StringProperty {
      get { return m_stringField; }
      set {
        m_stringField = value;
        OnPropertyChanged("StringProperty");
      }
    }
  
    public event PropertyChangedEventHandler PropertyChanged;
  
    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
