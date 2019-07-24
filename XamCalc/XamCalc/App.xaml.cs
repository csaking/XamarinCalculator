using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamCalc.Data;
using System.IO;

namespace XamCalc
{
    public partial class App : Application
    {
        static CalcDatabase database;

        public static CalcDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new CalcDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Calculations.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
