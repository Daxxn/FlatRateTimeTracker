using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.TimeTrackerModels
{
    public class DayModel : ModelBase
	{
		#region - Fields & Properties
		private DateTime _date;
		private List<TimeModel> _jobs;
		#endregion

		#region - Constructors
		public DayModel( ) { }
		#endregion

		#region - Methods

		#endregion

		#region - Full Properties
		public DateTime Date
		{
			get { return _date; }
			set
			{
				_date = value;
				OnPropertyChanged(nameof(Date));
			}
		}

		public List<TimeModel> Jobs
		{
			get { return _jobs; }
			set
			{
				_jobs = value;
				OnPropertyChanged(nameof(Jobs));
			}
		}
		#endregion
	}
}
