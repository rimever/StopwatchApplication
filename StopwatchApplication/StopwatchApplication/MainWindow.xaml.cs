#region

using System.Windows;

#endregion

namespace StopwatchApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new StopwatchViewModel();
        }
    }
}