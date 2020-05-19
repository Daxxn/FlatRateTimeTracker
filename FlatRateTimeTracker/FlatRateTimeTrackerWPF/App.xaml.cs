﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FlatRateTimeTrackerWPF.ViewModels;

namespace FlatRateTimeTrackerWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow main = new MainWindow(MainWindowViewModel.Instance);
            base.OnStartup(e);
            main.Show();
        }
    }
}
