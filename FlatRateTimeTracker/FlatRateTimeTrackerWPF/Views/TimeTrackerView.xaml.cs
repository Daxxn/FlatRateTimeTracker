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
            OpenFileButton.Click += vm.OpenFileEvent;
            SaveFileButton.Click += vm.SaveFileEvent;
            SaveFileTestButton.Click += vm.SaveFileTestEvent;
            AddROsButton.Click += vm.AddROsEvent;
            AddROsButton.Click += AddROsEvent;
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

        private void DelDay_Click( object sender, RoutedEventArgs e )
        {
            var vm = DataContext as TimeTrackerViewModel;
            vm.DeleteDayEvent(sender, e);
        }

        private void DelJob_Click( object sender, RoutedEventArgs e )
        {
            var vm = DataContext as TimeTrackerViewModel;
            vm.DeleteJobEvent(sender, e);
        }

        private void DayIndex_Click( object sender, RoutedEventArgs e )
        {
            var vm = DataContext as TimeTrackerViewModel;
            vm.AdjustDayIndex((sender as Button).Name);
        }

        private void JobIndex_Click( object sender, RoutedEventArgs e )
        {
            var vm = DataContext as TimeTrackerViewModel;
            vm.AdjustJobIndex((sender as Button).Name);
        }

        private void AddROsEvent( object sender, RoutedEventArgs e )
        {
            var vm = DataContext as TimeTrackerViewModel;
            var addROsWindow = new AddROsWindow(vm.AddROsVM);
            addROsWindow.Show();
        }
    }
}
