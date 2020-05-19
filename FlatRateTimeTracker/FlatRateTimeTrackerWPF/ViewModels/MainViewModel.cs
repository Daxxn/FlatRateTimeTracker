using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ModelLibrary;

namespace FlatRateTimeTrackerWPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region - Fields
        private Timer Timer { get; set; }
        private TimeSpan _jobTimer;
        public bool timerState { get; set; }
        private JobController _jobController;
        private JobType _selectedJobType;
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

        public void JobTypeSelectionEvent( object sender, SelectionChangedEventArgs e )
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                bool success = Enum.TryParse(e.AddedItems[ 0 ].ToString(), out JobType tempType);

                if (success)
                {
                    SelectedJobType = tempType;
                }
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
            if (timerState)
            {
                Timer.Stop();
            }
            else
            {
                Timer.Start();
            }
            timerState = !timerState;
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

        public JobController JobController
        {
            get { return _jobController; }
            set
            {
                _jobController = value;
                OnPropertyChanged(nameof(JobController));
            }
        }

        public JobType SelectedJobType
        {
            get { return _selectedJobType; }
            set
            {
                _selectedJobType = value;
            }
        }
        #endregion
    }
}
