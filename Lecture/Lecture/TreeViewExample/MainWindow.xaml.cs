using System.Windows;

namespace TP.Lecture.TreeViewExample
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MyViewModel();
        }
       
    }
}
