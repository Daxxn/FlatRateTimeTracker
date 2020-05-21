using FlatRateTimeTrackerWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace FlatRateTimeTrackerWPF.Views
{
    /// <summary>
    /// Interaction logic for TimeTrackerView.xaml
    /// </summary>
    public partial class TimeTrackerView : UserControl
    {
        public TimeTrackerView( TimeTrackerViewModel vm )
        {
            InitializeComponent();
            DataContext = vm;
            InitializeEvents(vm);
        }

        private void InitializeEvents( TimeTrackerViewModel vm )
        {
            TestBuildTree.Click += vm.TestBuildEvent;
            //AddDayButton.Click += vm.AddDayEvent;
            //AddJobButton.Click += vm.AddJobEvent;

        }

        private void AddJob_Click( object sender, RoutedEventArgs e )
        {
            var vm = DataContext as TimeTrackerViewModel;
            vm.AddJobEvent(sender, e);
        }

        private void AddDay_Click( object sender, RoutedEventArgs e )
        {
            var vm = DataContext as TimeTrackerViewModel;
            vm.AddDayEvent(sender, e);
        }
    }
}
