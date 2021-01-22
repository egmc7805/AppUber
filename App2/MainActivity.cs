using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Firebase;
using Firebase.Database;


namespace App2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        FirebaseDatabase database;
        Button btntestConnection;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            btntestConnection = (Button)FindViewById(Resource.Id.mybutton);
            btntestConnection.Click += BtntestConnection_Click;
        }
        private void BtntestConnection_Click(object sender, System.EventArgs e) 
        {
            Initializedatabase();
        }

        void Initializedatabase() {
            var app = FirebaseApp.InitializeApp(this);
            if (app == null)
            {
                var options = new FirebaseOptions.Builder()
           
                .SetApplicationId("clon-de-uber")
                .SetApiKey("AIzaSyDqI-di4CM_LTsvyI4meED2aFmrpu-TRFw")
                .SetDatabaseUrl("https://clon-de-uber-default-rtdb.firebaseio.com")
                .SetStorageBucket("clon-de-uber.appspot.com")
                .Build();
                app = FirebaseApp.InitializeApp(this, options);
                database = FirebaseDatabase.GetInstance(app);
            }
            else
            {
                database = FirebaseDatabase.GetInstance(app);
            }
            DatabaseReference dbref = database.GetReference("userSupport");
            dbref.SetValue("Ticket1");
            Toast.MakeText(this, "Prueba", ToastLength.Short).Show();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}