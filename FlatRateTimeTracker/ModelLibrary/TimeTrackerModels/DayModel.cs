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
        private int _Index;
        private DateTime _date;
		private ObservableCollection<TimeModel> _jobs;
        #endregion

        #region - Constructors
        public DayModel( )
        {
			Jobs = new ObservableCollection<TimeModel>();
        }
        #endregion

        #region - Methods

        #endregion

        #region - Full Properties
        public int Index
        {
            get { return _Index; }
            set
            {
                _Index = value;
				OnPropertyChanged(nameof(Index));
            }
        }
		public DateTime Date
		{
			get { return _date; }
			set
			{
				_date = value;
				OnPropertyChanged(nameof(Date));
			}
		}

		public ObservableCollection<TimeModel> Jobs
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
