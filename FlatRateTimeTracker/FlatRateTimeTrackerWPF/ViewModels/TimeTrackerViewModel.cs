using ModelLibrary.TimeTrackerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlatRateTimeTrackerWPF.ViewModels
{
    public class TimeTrackerViewModel : ViewModelBase
	{
		#region - Fields & Properties
		private TimeController _timeController;
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

		public void TestBuildJobsEvent( object sender, RoutedEventArgs e )
		{
			TimeController.BuildJobs();
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
		#endregion
	}
}
