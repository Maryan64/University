using System.Windows;
using System.Configuration;
using Task2.MVVM;

namespace Task2
{
    public partial class ColorWindow : Window
    {
        public ColorWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = mainViewModel;
        }
    }
}