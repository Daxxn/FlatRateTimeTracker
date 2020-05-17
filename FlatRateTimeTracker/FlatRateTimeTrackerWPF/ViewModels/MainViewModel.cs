using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using ModelLibrary;

namespace FlatRateTimeTrackerWPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region - Fields
        private Timer Timer { get; set; }
        private TimeSpan _jobTimer;
        private JobController _jobController;
        private int _selectedJobType;
        #endregion

        #region - Constructors
        public MainViewModel()
        {
            JobController = new JobController();
            BuildTimer();
        }
        #endregion

        #region - Methods
        public void StartJobClickEvent(object sender, RoutedEventArgs e)
        {
            StartTimer();
            JobController.StartJob(SelectedJobType);
        }

        public void StartJobKeyEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var now = StartTimer();
                JobController.StartJob(SelectedJobType);
            }
        }

        private void BuildTimer( int interval = 1000 )
        {
            Timer = new Timer(interval)
            {
                AutoReset = true
            };
            Timer.Elapsed += Timer_Elapsed;
        }

        public DateTime StartTimer( )
        {
            Timer.Start();
            return DateTime.Now;
        }

        private void Timer_Elapsed( object sender, ElapsedEventArgs e )
        {
            JobTimer = JobTimer.Add(new TimeSpan(0, 0, 1));
        }
        #endregion

        #region - Properties
        public TimeSpan JobTimer
        {
            get { return _jobTimer; }
            set
            {
                _jobTimer = value;
                OnPropertyChanged(nameof(JobTimer));
            }
        }

        public string JobTimerDisplay
        {
            get { return JobTimer.ToString("c");  }
        }

        public JobController JobController
        {
            get { return _jobController; }
            set
            {
                _jobController = value;
                OnPropertyChanged(nameof(JobController));
            }
        }

        public int SelectedJobIndex
        {
            get { return _selectedJobType; }
            set
            {
                _selectedJobType = value;
                OnPropertyChanged(nameof(SelectedJobIndex));
            }
        }

        public JobType SelectedJobType
        {
            get
            {
                return (JobType)SelectedJobIndex;
            }
        }
        #endregion
    }
}
