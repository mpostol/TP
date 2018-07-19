using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TPA.Reflection.UnitTest.Execution
{
    internal class DataSource : INotifyPropertyChanged
    {
        private int _intField = 0;
        public int IntProperty {
            get { return _intField; }
            set {
                _intField = value;
                OnPropertyChanged("IntProperty");
            }
        }

        private string _stringField = "";
        public string StringProperty {
            get { return _stringField; }
            set {
                _stringField = value;
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
