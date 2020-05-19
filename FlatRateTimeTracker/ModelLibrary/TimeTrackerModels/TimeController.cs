using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.TimeTrackerModels
{
    public class TimeController : ModelBase
	{
		#region - Fields & Properties
		public ObservableCollection<DayModel> _data;
		#endregion

		#region - Constructors
		public TimeController( )
		{
		}
		#endregion

		#region - Methods
		public void TestBuild( )
		{
			// TESTING
			Data = new ObservableCollection<DayModel>()
			{
				new DayModel()
			};
		}

		public void BuildJobs( )
		{
			Data[ 0 ].Jobs = new List<TimeModel>()
			{
				new TimeModel
				{
					OutTime = new DateTime(2020, 5, 15, 8, 30, 0),
					Type = JobType.MinorOilChange,
					FlaggedHours = 0.5m,
					RONumber = 441602,
				},
				new TimeModel
				{
					OutTime = new DateTime(2020, 5, 15, 8, 30, 0),
					Type = JobType.MinorOilChange,
					FlaggedHours = 0.5m,
					RONumber = 441610,
				},
				new TimeModel
				{
					OutTime = new DateTime(2020, 5, 15, 9, 0, 0),
					Type = JobType.MinorOilChange,
					FlaggedHours = 0.5m,
					RONumber = 441612,
				}
			};
		}
		#endregion

		#region - Full Properties
		public ObservableCollection<DayModel> Data
		{
			get { return _data; }
			set
			{
				_data = value;
				OnPropertyChanged(nameof(Data));
			}
		}
		#endregion
	}
}
