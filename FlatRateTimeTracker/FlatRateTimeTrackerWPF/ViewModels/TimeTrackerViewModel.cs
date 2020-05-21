using ModelLibrary.TimeTrackerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FlatRateTimeTrackerWPF.ViewModels
{
    public class TimeTrackerViewModel : ViewModelBase
	{
		#region - Fields & Properties
		private TimeController _timeController;

        private string _openPath;
        #endregion

        #region - Constructors
        public TimeTrackerViewModel( )
		{
			// TESTING
			TimeController = new TimeController();
		}
		#endregion

		#region - Methods
		public void TestBuildEvent( object sender, RoutedEventArgs e )
		{
			TimeController.TestBuild();
		}

        public void OpenFileEvent( object sender, RoutedEventArgs e )
        {

        }

        public void AddDayEvent( object sender, RoutedEventArgs e )
        {
			TimeController.AddDay();
        }

        public void AddJobEvent( object sender, RoutedEventArgs e )
        {
			var source = e.Source as Button;
			var context = source.DataContext as DayModel;
			context?.Jobs.Add(new TimeModel());
        }
		#endregion

		#region - Full Properties
		public TimeController TimeController
		{
			get { return _timeController; }
			set
			{
				_timeController = value;
				OnPropertyChanged(nameof(TimeController));
			}
		}

        public string OpenPath
		{
            get { return _openPath; }
            set
            {
                _openPath = value;
				OnPropertyChanged(nameof(OpenPath));
            }
        }
		#endregion
	}
}
