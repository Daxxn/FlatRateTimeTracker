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
			Data = new ObservableCollection<DayModel>();
		}
		#endregion

		#region - Methods
		/// <summary>
		/// ONLY FOR TESTING! Needs to be removed when the actual data construction 
		/// is completed.
		/// </summary>
		public void TestBuild( )
		{
			// TESTING
			Data = new ObservableCollection<DayModel>()
			{
				new DayModel()
                {
					Date = DateTime.Now,
					Jobs = new ObservableCollection<TimeModel>()
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
					}
				}
			};
		}

        public void AddDay( )
        {
			Data.Add(new DayModel());
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
