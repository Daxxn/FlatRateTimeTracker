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
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan JobTime { get; set; }
        #endregion

        #region - Constructors
        public JobModel() { }
        #endregion

        #region - Methods

        #endregion

        #region - Properties

        #endregion
    }
}
