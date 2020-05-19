using FlatRateTimeTrackerWPF.ViewModels;
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

namespace FlatRateTimeTrackerWPF.Views
{
    /// <summary>
    /// Interaction logic for JobTrackerView.xaml
    /// </summary>
    public partial class JobTrackerView : UserControl
    {
        public JobTrackerView( JobTrackerViewModel vm )
        {
            InitializeComponent();
            DataContext = vm;
            InitializeEvents(vm);
        }

        private void InitializeEvents( JobTrackerViewModel vm )
        {
            StartJobButton.Click += vm.StartJobClickEvent;
            KeyUp += vm.StartJobKeyEvent;
        }
    }
}
