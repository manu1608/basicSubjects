using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace EZCode
{
	public partial class App : Application
	{
        static Database.Database appDatabase;
        public App ()
		{
			InitializeComponent();

            if (appDatabase == null)
            {
                appDatabase = new Database.Database("EZCodeDatabase.db3");
            }

            MainPage = new EZCode.MainPage();
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
