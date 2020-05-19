using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.TimeTrackerModels
{
    public class TimeModel
	{
		#region - Fields & Properties
		public JobType Type { get; set; }
		public int RONumber { get; set; }
		public decimal FlaggedHours { get; set; }
		public TimeSpan CompletionTime { get; set; }
		public DateTime OutTime { get; set; }
		#endregion

		#region - Constructors
		public TimeModel( ) { }
		#endregion

		#region - Methods

		#endregion

		#region - Full Properties

		#endregion
	}
}
