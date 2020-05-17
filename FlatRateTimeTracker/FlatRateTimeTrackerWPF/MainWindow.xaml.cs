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
using ModelLibrary;

namespace FlatRateTimeTrackerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            JobTypeComboBox.ItemsSource = Enum.GetNames(typeof(JobType));
            JobTypeComboBox.SelectedIndex = vm.SelectedJobIndex;
            InitializeEvents(vm);
        }

        private void InitializeEvents(MainViewModel vm)
        {
            StartJobButton.Click += vm.StartJobClickEvent;
        }

        private void StartJob_KeyUp( object sender, KeyEventArgs e)
        {
            var vm = DataContext as MainViewModel;
            vm.StartJobKeyEvent(sender, e);
        }
    }
}
