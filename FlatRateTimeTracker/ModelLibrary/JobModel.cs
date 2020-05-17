using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class JobModel /*: ModelBase*/
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

        #endregion

        #region - Properties
        public TimeSpan JobTime
        {
            get
            {
                return StartTime - EndTime;
            }
        }

        public JobType Type
        {
            get { return _type; }
            set
            {
                _type = value;
                //OnPropertyChanged(nameof(Type));
            }
        }

        public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                //OnPropertyChanged(nameof(StartTime));
            }
        }

        public DateTime EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                //OnPropertyChanged(nameof(EndTime));
            }
        }
        #endregion
    }
}
