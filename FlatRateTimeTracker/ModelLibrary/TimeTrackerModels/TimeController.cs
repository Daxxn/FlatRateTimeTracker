using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting;
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

        public string DeleteItem(int dayIndex, int jobIndex )
        {
            try
            {
                Data.ElementAt(dayIndex).Jobs.RemoveAt(jobIndex);
				return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
		}

        public string DeleteItem( int dayIndex )
        {
            try
            {
                Data.RemoveAt(dayIndex);
				return null;
            }
            catch (Exception e)
            {
				return e.Message;
            }
        }

        public void AssignIndexes( )
        {
            for (int i = 0; i < Data.Count; i++)
            {
				Data[ i ].Index = i;
                for (int j = 0; j < Data[i].Jobs.Count; j++)
                {
					Data[ i ].Jobs[ j ].Index = j;
                }
            }
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
