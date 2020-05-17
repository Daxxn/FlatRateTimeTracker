using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ModelLibrary
{
    public class JobController : ModelBase
    {
        #region - Fields
        private List<JobModel> _allJobs;
        private JobModel _currentJob;
        #endregion

        #region - Constructors
        public JobController( )
        {
            AllJobs = new List<JobModel>();
        }
        #endregion

        #region - Methods
        public void StartJob(JobType type)
        {
            if (CurrentJob is null)
            {
                CurrentJob = new JobModel()
                {
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now,
                    Type = type,
                };
            }
            else
            {
                EndJob();
                StartJob(type);
            }
        }

        public void StartJob( JobType type, DateTime startTime )
        {
            CurrentJob = new JobModel()
            {
                StartTime = startTime,
                EndTime = DateTime.Now,
                Type = type
            };
        }

        public void EndJob()
        {
            CurrentJob.EndTime = DateTime.Now;
            AllJobs.Add(CurrentJob);
            CurrentJob = null;
        }
        #endregion

        #region - Properties
        public int TotalJobCount
        {
            get
            {
                return AllJobs.Count;
            }
        }

        public Dictionary<JobType, int> JobCountDict
        {
            get
            {
                Dictionary<JobType, int> output = new Dictionary<JobType, int>();
                foreach (var job in AllJobs)
                {
                    if (!output.Keys.Contains(job.Type))
                    {
                        output.Add(job.Type, 1);
                    }
                    else
                    {
                        output[job.Type]++;
                    }
                }
                return output;
            }
        }

        public List<JobModel> AllJobs
        {
            get { return _allJobs; }
            set
            {
                _allJobs = value;
                OnPropertyChanged(nameof(AllJobs));
            }
        }

        public JobModel CurrentJob
        {
            get { return _currentJob; }
            set
            {
                _currentJob = value;
                OnPropertyChanged(nameof(CurrentJob));
            }
        }
        #endregion
    }
}
