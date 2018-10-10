using System.Windows;
using System.Configuration;
using Task2.MVVM;

namespace Task2
{
    /// <summary>
    /// ColorWindow window to pick color
    /// </summary>
    public partial class ColorWindow : Window
    {
        public ColorWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = mainViewModel;
        }
    }
}