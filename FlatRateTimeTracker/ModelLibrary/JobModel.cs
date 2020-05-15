using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class JobModel
    {
        #region - Fields
        public JobType Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
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
        #endregion
    }
}
