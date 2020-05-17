using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class JobController
    {
        #region - Fields
        public List<JobModel> AllJobs { get; set; }
        public JobModel CurrentJob { get; set; }
        #endregion

        #region - Constructors

        #endregion

        #region - Methods
        public void StartJob(JobType type)
        {
            if (CurrentJob != null)
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
            }
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
        #endregion
    }
}
