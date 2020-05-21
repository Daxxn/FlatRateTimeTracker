using Microsoft.Win32;

using ModelLibrary;
using ModelLibrary.TimeTrackerModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FlatRateTimeTrackerWPF.ViewModels
{
    public class TimeTrackerViewModel : ViewModelBase
	{
        #region - Fields & Properties
        private AddROsViewModel _addROsVM;

        private TimeController _timeController;

        private string _path;

        private int _dayIndex;
        private int _jobIndex;
        #endregion

        #region - Constructors
        public TimeTrackerViewModel( )
		{
			// TESTING
			TimeController = new TimeController();
		}
		#endregion

		#region - Methods
		public void TestBuildEvent( object sender, RoutedEventArgs e )
		{
			TimeController.TestBuild();
		}

        public void OpenFileEvent( object sender, RoutedEventArgs e )
        {
			OpenFileDialog open = new OpenFileDialog
			{
				AddExtension = false,
				CheckFileExists = true,
				InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
			};

            if (open.ShowDialog() == true)
            {
				FilePath = open.FileName;
                try
                {
                    TimeController.Data = JsonController.OpenJsonFile<ObservableCollection<DayModel>>(FilePath);
                }
                catch (Exception exe)
                {
					MessageBox.Show(exe.Message);
                }
            }
        }

        public void SaveFileEvent( object sender, RoutedEventArgs e )
        {
			SaveFileDialog save = new SaveFileDialog
			{
				AddExtension = true,
				DefaultExt = "json",
				DereferenceLinks = false,
				OverwritePrompt = true,
				InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
			};

            if (save.ShowDialog() == true)
            {
				FilePath = save.FileName;
				JsonController.SaveJsonFile(FilePath, TimeController.Data);
			}
        }

        public void SaveFileTestEvent( object sender, RoutedEventArgs e )
        {
            try
            {
                MessageBox.Show(JsonController.SaveJsonFileTest(TimeController.Data));
            }
            catch (Exception exe)
            {
				MessageBox.Show(exe.Message);
            }
        }

        public void AddROsEvent( object sender, RoutedEventArgs e )
        {
            AddROsVM = new AddROsViewModel();
        }

        public void AddDayEvent( object sender, RoutedEventArgs e )
        {
			TimeController.AddDay();
        }

        public void AddJobEvent( object sender, RoutedEventArgs e )
        {
			var source = e.Source as Button;
			var context = source.DataContext as DayModel;
			context?.Jobs.Add(new TimeModel());
        }

        public void DeleteDayEvent( object sender, EventArgs e )
        {
            TimeController.DeleteItem(DayIndex);
        }

        public void DeleteJobEvent( object sender, EventArgs e )
        {
            TimeController.DeleteItem(DayIndex, JobIndex);
        }

        public void AdjustDayIndex( string name )
        {
            if (name == "DayUp")
            {
                DayIndex = DayIndex < TimeController.Data.Count - 1 ? DayIndex + 1 : DayIndex;
                JobIndex = 0;
            }
            else if (name == "DayDown")
            {
                DayIndex = DayIndex > 0 ? DayIndex - 1 : DayIndex;
                JobIndex = 0;
            }
        }

        public void AdjustJobIndex( string name )
        {
            if (name == "JobUp")
            {
                JobIndex = JobIndex < TimeController.Data[ DayIndex ].Jobs.Count - 1 ? JobIndex + 1 : JobIndex;
            }
            else if (name == "JobDown")
            {
                JobIndex = JobIndex > 0 ? JobIndex - 1 : JobIndex;
            }
        }
        #endregion

        #region - Full Properties
        public AddROsViewModel AddROsVM
        {
            get { return _addROsVM; }
            set
            {
                _addROsVM = value;
            }
        }
		public TimeController TimeController
		{
			get { return _timeController; }
			set
			{
				_timeController = value;
				OnPropertyChanged(nameof(TimeController));
			}
		}

        public string FilePath
		{
            get { return _path; }
            set
            {
                _path = value;
				OnPropertyChanged(nameof(FilePath));
            }
        }

        public int DayIndex
        {
            get { return _dayIndex; }
            set
            {
                _dayIndex = value;
                OnPropertyChanged(nameof(DayIndex));
            }
        }

        public int JobIndex
        {
            get { return _jobIndex; }
            set
            {
                _jobIndex = value;
                OnPropertyChanged(nameof(JobIndex));
            }
        }
		#endregion
	}
}
