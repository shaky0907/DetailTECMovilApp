using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace DetailTECMovilApp
{
    public partial class App : Application
    {

        private static SQLiteHelper db;
        public static SQLiteHelper MyDataBase
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Detail.db3"));
                }
                return db;
            }

        }

        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new LoginUI();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
