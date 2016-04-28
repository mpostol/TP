using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

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
