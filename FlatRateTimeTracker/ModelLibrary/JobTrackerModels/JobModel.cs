using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class JobModel : ModelBase
    {
        #region - Fields
        public JobType _type;
        public DateTime _startTime;
        public DateTime _endTime;
        #endregion

        #region - Constructors
        public JobModel() { }
        #endregion

        #region - Methods
        private string TimeToString( TimeSpan time )
        {
            return $"{time.Hours}:{time.Minutes}:{time.Seconds}";
        }

        private string TimeToString( DateTime time )
        {
            return $"{time.Month}/{time.Day}/{time.Year} {(time.Hour > 12 ? time.Hour - 12 : time.Hour)}:{time.Minute}:{time.Second}";
        }
        #endregion

        #region - Properties
        public TimeSpan JobTime
        {
            get
            {
                return EndTime - StartTime;
            }
        }

        public string JobTimeDisplay
        {
            get
            {
                return TimeToString(JobTime);
            }
        }

        public JobType Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged(nameof(StartTime));
            }
        }

        public string StartTimeDisplay
        {
            get 
            {
                return TimeToString(StartTime);
            }
        }

        public DateTime EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                OnPropertyChanged(nameof(EndTime));
            }
        }

        public string EndTimeDisplay
        {
            get
            {
                return TimeToString(EndTime);
            }
        }
        #endregion
    }
}
