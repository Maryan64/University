using System.Windows;

namespace Task2.MVVM
{
    public partial class ColorsWindow : Window
    {
        public ColorsWindow(MainViewModel mainViewModel)
        {
			InitializeComponent();
			DataContext = mainViewModel;
		}
	}
}
