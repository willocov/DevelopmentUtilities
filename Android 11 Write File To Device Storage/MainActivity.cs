using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using Android.Content.PM;
using Android.Widget;

namespace Android_11_Write_File_To_Device_Storage
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btnWriteTxt, btnWriteJson, btnWriteHtml, btnWriteJs, btnReadAll, btnDeleteAll;
        TextView txtViewOutput;

        const string txtFilename = "DevUtilitiesTest.txt";
        const string jsonFilename = "DevUtilitiesTest.json";
        const string htmlFilename = "DevUtilitiesTest.html";
        const string jsFilename = "DevUtilitiesTest.js";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            //Assign UI elemnts to class views
            btnWriteTxt = FindViewById<Button>(Resource.Id.button_writeTxt);
            btnWriteJson = FindViewById<Button>(Resource.Id.button_writeJson);
            btnWriteHtml = FindViewById<Button>(Resource.Id.button_writeHtml);
            btnWriteJs = FindViewById<Button>(Resource.Id.button_writeJs);
            btnReadAll = FindViewById<Button>(Resource.Id.button_read_all);
            btnDeleteAll = FindViewById<Button>(Resource.Id.button_delete_all);
            txtViewOutput = FindViewById<TextView>(Resource.Id.textview_readonly);

            //Set click events for buttons
            btnWriteTxt.Click += WriteTxt;
            btnWriteJson.Click += WriteJson;
            btnWriteHtml.Click += WriteHtml;
            btnWriteJs.Click += WriteJs;
            btnReadAll.Click += ReadAll;
            btnDeleteAll.Click += DeleteAll;

            RequestExternalStoragePermission();

        }

        private void WriteTxt(object sender, EventArgs eventArgs)
        {
            try
            {
                Console.WriteLine("Click WriteTxt");
                txtViewOutput.Text = "Writing txt file to device storge...\n";
                FileSystemUtilities.WritePlainTextToExternalStorage(txtFilename, "Hello from the txt file");
                txtViewOutput.Text += "Finished writing txt file. Check device storage to verify.\n";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                txtViewOutput.Text += "Error: Failed to write txt file: " + ex.Message + "\n";
            }
        }

        private void WriteJson(object sender, EventArgs eventArgs)
        {
            try
            {
                Console.WriteLine("Click WriteJson");
                txtViewOutput.Text = "Writing json file to device storge...\n";
                FileSystemUtilities.WritePlainTextToExternalStorage(jsonFilename, "Hello from the json file");
                txtViewOutput.Text += "Finished writing json file. Check device storage to verify.\n";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                txtViewOutput.Text += "Error: Failed to write json file: " + ex.Message + "\n";
            }
        }
        private void WriteHtml(object sender, EventArgs eventArgs)
        {
            try
            {
                Console.WriteLine("Click WriteHtml");
                txtViewOutput.Text = "Writing html file to device storge...\n";
                FileSystemUtilities.WritePlainTextToExternalStorage(htmlFilename, "Hello from the html file");
                txtViewOutput.Text += "Finished writing html file. Check device storage to verify.\n";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                txtViewOutput.Text += "Error: Failed to write html file: " + ex.Message + "\n";
            }
        }
        private void WriteJs(object sender, EventArgs eventArgs)
        {
            try
            {
                Console.WriteLine("Click WriteJs");
                txtViewOutput.Text = "Writing js file to device storge...\n";
                FileSystemUtilities.WritePlainTextToExternalStorage(jsFilename, "Hello from the js file");
                txtViewOutput.Text += "Finished writing js file. Check device storage to verify.\n";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                txtViewOutput.Text += "Error: Failed to write js file: " + ex.Message + "\n";
            }
        }
        private void ReadAll(object sender, EventArgs eventArgs)
        {

            Console.WriteLine("Click ReadAll");
            txtViewOutput.Text = "Reading all files from device storage\n";

            try
            {
                string txtContents = FileSystemUtilities.ReadFileFromExternalStorage(txtFilename);
                txtViewOutput.Text += "Txt File Contents: " + txtContents + "\n";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                txtViewOutput.Text += "Error: Failed to read txt file: " + ex.Message + "\n";
            }


            try
            {
                string jsonContents = FileSystemUtilities.ReadFileFromExternalStorage(jsonFilename);
                txtViewOutput.Text += "JSON File Contents: " + jsonContents + "\n";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                txtViewOutput.Text += "Error: Failed to read json file: " + ex.Message + "\n";
            }


            try
            {
                string htmlContents = FileSystemUtilities.ReadFileFromExternalStorage(htmlFilename);
                txtViewOutput.Text += "HTML File Contents: " + htmlContents + "\n";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                txtViewOutput.Text += "Error: Failed to read html file: " + ex.Message + "\n";
            }


            try
            {
                string jsContents = FileSystemUtilities.ReadFileFromExternalStorage(jsFilename);
                txtViewOutput.Text += "JS File Contents: " + jsContents + "\n";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                txtViewOutput.Text += "Error: Failed to read js file: " + ex.Message + "\n";
            }
            txtViewOutput.Text += "Finished Reading all files.\n";

        }
        private void DeleteAll(object sender, EventArgs eventArgs)
        {
            try
            {
                Console.WriteLine("Click DeleteAll");
                txtViewOutput.Text = "Deleting all files from device storage...\n";
                FileSystemUtilities.DeleteFileFromExternalStorage(txtFilename);
                FileSystemUtilities.DeleteFileFromExternalStorage(jsonFilename);
                FileSystemUtilities.DeleteFileFromExternalStorage(htmlFilename);
                FileSystemUtilities.DeleteFileFromExternalStorage(jsFilename);
                txtViewOutput.Text += "Finished deleting all files. Check device storage to verify.\n";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                txtViewOutput.Text += "Error: Failed to delete all files: " + ex.Message + "\n";
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            switch (requestCode)
            {
                case REQUEST_EXTERNAL_STORAGE:
                    // If the user granted permission, grantResults will be non-empty.
                    if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                    {
                        // Permission was granted
                        // Do nothing
                    }
                    else
                    {
                        // Permission denied
                        // Handle the error here
                        Toast.MakeText(ApplicationContext, "Permissions denied", ToastLength.Short).Show();
                    }
                    break;
            }
        }

        const int REQUEST_EXTERNAL_STORAGE = 1;
        string[] PERMISSIONS_STORAGE = { Android.Manifest.Permission.WriteExternalStorage };

        public void RequestExternalStoragePermission()
        {
            // Check if we have permission to write to external storage
            if (ContextCompat.CheckSelfPermission(Android.App.Application.Context, Android.Manifest.Permission.WriteExternalStorage)
                != Permission.Granted)
            {
                // If we don't have permission, request it from the user
                ActivityCompat.RequestPermissions(this, PERMISSIONS_STORAGE, REQUEST_EXTERNAL_STORAGE);
            }
            else
            {
                // We already have permission to write to external storage
                // Do nothing
            }
        }
    }
}
