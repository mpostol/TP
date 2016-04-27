using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace TP.Lecture
{
    class MyViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<ITreeViewItem> HierarchicalAreas { get; set; }

        public MyViewModel()
        {
            HierarchicalAreas = new ObservableCollection<ITreeViewItem>();
        }

        private string pathVariable;
       

        public string PathVariable
        {
            get { return pathVariable; }
            set { pathVariable = value; }
        }
 

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName_)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName_));
            }
        }

        private Visibility _visibility = Visibility.Hidden;

        public Visibility ChangeControlVisibility
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
            }
        }

        public ICommand Click_Browse
        {
            get { return new DelegateCommand(Browse); }
        }

        private void Browse()
        {
            OpenFileDialog test = new OpenFileDialog();
            test.Filter = "Dynamic Library File(*.dll)| *.dll";
            test.ShowDialog();


            if(test.FileName.Length==0)
            {
                MessageBox.Show("No files selected");
            }
            else
            {
                pathVariable = test.FileName;
                _visibility = Visibility.Visible;
                RaisePropertyChanged("ChangeControlVisibility");
                RaisePropertyChanged("PathVariable");

            }
        }

        public ICommand Click_Button
        {
            get { return new DelegateCommand(LoadDLL); }
        }



        private void LoadDLL()
        {
            if( pathVariable.Substring(pathVariable.Length-4)==".dll" )
            TreeViewLoaded();
        }

        private void TreeViewLoaded()
        {
            ITreeViewItem rootItem = new ITreeViewItem { Name = pathVariable.Substring(pathVariable.LastIndexOf('\\') + 1)};   
            HierarchicalAreas.Add(rootItem);
        }
        

    }
}
