#region namespace
using Ninject;
using System;
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Navigation;
using Windows.Storage;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SQLite.Net.Platform.WindowsPhone8;
using BoikoQuiz.WP.Resources;
using BoikoQuiz.Core.DataLayer;
using BoikoQuiz.Core.BusinessLayer;
#endregion;

namespace BoikoQuiz.WP
{
    public partial class App : Application
    {
        #region Fields

        public static IKernel Kernel { get; set; }
        public static NavigationHelper HNavigation { get; set; }

        const string DBName = "boikoQuiz.sqlite";
        private static Database database;
        public static Database Database { get { return database; } }

        public static User User { get; set; }

        /// <summary>
        /// It provides quick access to the root frame of the phone applications.
        /// </summary>
        /// <returns>The root frame phone application.</returns>
        public static PhoneApplicationFrame RootFrame { get; private set; }

        #endregion

        /// <summary>
        /// Designer application object.
        /// </summary>
        public App()
        {
            // Global exception handler intercepted.
            UnhandledException += Application_UnhandledException;

            // Initialization phone
            InitializeComponent();

            // Инициализация телефона
            InitializePhoneApplication();

            // Initialization display language
            InitializeLanguage();

            // Displays information about profile charts during debugging.
            if (Debugger.IsAttached)
            {
                Application.Current.Host.Settings.EnableFrameRateCounter = true;
                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }

            Kernel = new StandardKernel();
        }

        private async void Application_Launching(object sender, LaunchingEventArgs e)
        {
            bool dbExist = true;
            try {
                StorageFile storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync(DBName);
            } catch {
                dbExist = false;
            }

            database = new Database(new SQLitePlatformWP8(), Path.Combine(ApplicationData.Current.LocalFolder.Path, DBName));
            if (! dbExist)
                database.Initialize();
        }

        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
        }

        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
        }

        private void Application_Closing(object sender, ClosingEventArgs e)
        {
        }

        // The code to execute in case of an error navigation
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // Error navigation; go to the debugger
                Debugger.Break();
            }
        }

        // Code to run on an unhandled exception
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // An unhandled exception occurred; go to the debugger
                Debugger.Break();
            }
        }

        #region Initialization phone application

        // Avoid double initialization
        private bool phoneApplicationInitialized = false;

        // Do not add additional code for this method
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;

            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;
           
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;
            RootFrame.Navigated += CheckForResetNavigation;
            phoneApplicationInitialized = true;
        }

        // Do not add additional code for this method
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Set the root visual element for imaging applications
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            // Remove this handler since it is no longer needed
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        private void CheckForResetNavigation(object sender, NavigationEventArgs e)
        {
            // If the application is received navigation "reset", check the
            // The next time you navigate to check whether you need to reset the stack
            if (e.NavigationMode == NavigationMode.Reset)
                RootFrame.Navigated += ClearBackStackAfterReset;
        }

        private void ClearBackStackAfterReset(object sender, NavigationEventArgs e)
        {
            // Cancel registration of events that it no longer causes
            RootFrame.Navigated -= ClearBackStackAfterReset;

            // Cleaning stack only "new" navigation (forward) and Navigation "upgrade"
            if (e.NavigationMode != NavigationMode.New && e.NavigationMode != NavigationMode.Refresh)
                return;

            // Cleaning the entire stack page for the consistency of the user interface
            while (RootFrame.RemoveBackEntry() != null)
            {
                ; // To do nothing
            }
        }

        #endregion

        private void InitializeLanguage()
        {
            try
            {               
                RootFrame.Language = XmlLanguage.GetLanguage(AppResources.ResourceLanguage);

                FlowDirection flow = (FlowDirection)Enum.Parse(typeof(FlowDirection), AppResources.ResourceFlowDirection);
                RootFrame.FlowDirection = flow;
            }
            catch
            {
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }

                throw;
            }
        }
    }
}