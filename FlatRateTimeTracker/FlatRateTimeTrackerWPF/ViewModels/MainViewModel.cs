using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ModelLibrary;

namespace FlatRateTimeTrackerWPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region - Fields
        public JobController JobController { get; set; }
        public JobType SelectedJobType { get; set; }
        #endregion

        #region - Constructors
        public MainViewModel()
        {
            JobController = new JobController()
            {
                AllJobs = new List<JobModel>()
                {
                    new JobModel()
                    {
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now.AddHours(1),
                        Type = JobType.MinorOilChange,
                    }
                }
            };
        }

        public void StartJobClickEvent(object sender, RoutedEventArgs e)
        {
            JobController.StartJob(SelectedJobType);
        }

        public void StartJobKeyEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                JobController.StartJob(SelectedJobType);
            }
        }
        #endregion

        #region - Methods

        #endregion

        #region - Properties

        #endregion
    }
}
