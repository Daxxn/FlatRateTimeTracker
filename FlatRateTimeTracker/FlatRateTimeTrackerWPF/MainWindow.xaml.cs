using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlatRateTimeTrackerWPF.ViewModels;
using FlatRateTimeTrackerWPF.Views;
using ModelLibrary;

namespace FlatRateTimeTrackerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            InitializeEvents(vm);
        }

        private void InitializeEvents( MainWindowViewModel vm )
        {
        }

        private void TabControl_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            if (TC.SelectedIndex == 0)
            {
                JobTrackerTab.Content = new JobTrackerView(MainWindowViewModel.Instance.JobTrackerVM);
            }
            else if (TC.SelectedIndex == 1)
            {
                TimeTrackerTab.Content = new TimeTrackerView(MainWindowViewModel.Instance.TimeTrackerVM);
            }
        }
    }
}
