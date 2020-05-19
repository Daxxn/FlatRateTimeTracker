using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRateTimeTrackerWPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
	{
		#region - Fields & Properties
		private static MainWindowViewModel _instance;

		private JobTrackerViewModel _jobTrackerVM = new JobTrackerViewModel();
		private TimeTrackerViewModel _timeTrackerVM = new TimeTrackerViewModel();
		#endregion

		#region - Constructors
		public MainWindowViewModel( ) { }
		#endregion

		#region - Methods

		#endregion

		#region - Full Properties
		public static MainWindowViewModel Instance
		{
			get 
			{
				if (_instance is null)
				{
					_instance = new MainWindowViewModel();
				}
				return _instance; 
			}
		}

		public JobTrackerViewModel JobTrackerVM
		{
			get { return _jobTrackerVM; }
			set
			{
				_jobTrackerVM = value;
			}
		}

		public TimeTrackerViewModel TimeTrackerVM
		{
			get { return _timeTrackerVM; }
			set
			{
				_timeTrackerVM = value;
			}
		}
		#endregion
	}
}
