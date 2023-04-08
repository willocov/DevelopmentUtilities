using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;

namespace Android_11_Write_File_To_Device_Storage
{
    public static class FileSystemUtilities
    {
        //This method is used for writing plain text to a text file.
        //This method should be leveraged by other methods within this class and not accessed directly
        public static void WritePlainTextToExternalStorage(string fileName, string fileContents)
        {
            try
            {
                // Get the root directory of the app's external storage
                Java.IO.File externalFilesDir = Application.Context.GetExternalFilesDir(null);

                // Create a new file in the directory
                Java.IO.File file = new Java.IO.File(externalFilesDir, fileName);

                // Open a stream for writing to the file
                using (var stream = new FileOutputStream(file))
                {
                    // Write the contents to the file
                    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(fileContents);
                    stream.Write(bytes);
                }

                // Notify the system that a new file has been created and needs to be added to media store
                ContentValues values = new ContentValues();
                values.Put(MediaStore.IMediaColumns.DisplayName, fileName);
                values.Put(MediaStore.IMediaColumns.MimeType, "text/plain");
                values.Put(MediaStore.IMediaColumns.RelativePath, Android.OS.Environment.DirectoryDocuments);
                Android.Net.Uri uri = Application.Context.ContentResolver.Insert(MediaStore.Files.GetContentUri(MediaStore.VolumeExternalPrimary), values);
            }
            catch (Exception ex)
            {
                string errorMessage = "Error: Failed to write plain text to file: Filename = " + fileName + ": " + ex.Message;
                System.Console.WriteLine(errorMessage);
                throw new Exception(errorMessage);
            }
        }

        //This method is used for writing serialized json to a json file
        //This method should be utilized by other methods within this class and not accessed directly
        public static void WriteJSONToExternalStorage(string fileName, string fileContents, bool isAppendingFile = false)
        {
            try
            {
                // Get the root directory of the app's external storage
                Java.IO.File externalFilesDir = Application.Context.GetExternalFilesDir(null);

                // Create a new file in the directory
                Java.IO.File file = new Java.IO.File(externalFilesDir, fileName);

                // Open a stream for writing to the file
                using (var stream = new FileOutputStream(file, isAppendingFile))
                {
                    // Write the contents to the file
                    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(fileContents);
                    stream.Write(bytes);
                }

                // Notify the system that a new file has been created and needs to be added to media store
                ContentValues values = new ContentValues();
                values.Put(MediaStore.IMediaColumns.DisplayName, fileName);
                values.Put(MediaStore.IMediaColumns.MimeType, "application/json");
                values.Put(MediaStore.IMediaColumns.RelativePath, Android.OS.Environment.DirectoryDocuments);
                Android.Net.Uri uri = Application.Context.ContentResolver.Insert(MediaStore.Files.GetContentUri(MediaStore.VolumeExternalPrimary), values);
            }
            catch (Exception ex)
            {
                string errorMessage = "Error: Failed to write JSON to file: Filename = " + fileName + ": " + ex.Message;
                System.Console.WriteLine(errorMessage);
                throw new Exception(errorMessage);
            }
        }

        public static void WriteJavaScriptToExternalStorage(string fileName, string fileContents, bool isAppendingFile = false)
        {
            try
            {
                // Get the root directory of the app's external storage
                Java.IO.File externalFilesDir = Application.Context.GetExternalFilesDir(null);

                // Create a new file in the directory
                Java.IO.File file = new Java.IO.File(externalFilesDir, fileName);

                // Open a stream for writing to the file
                using (var stream = new FileOutputStream(file, isAppendingFile))
                {
                    // Write the contents to the file
                    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(fileContents);
                    stream.Write(bytes);
                }

                // Notify the system that a new file has been created and needs to be added to media store
                ContentValues values = new ContentValues();
                values.Put(MediaStore.IMediaColumns.DisplayName, fileName);
                values.Put(MediaStore.IMediaColumns.MimeType, "application/javascript");
                values.Put(MediaStore.IMediaColumns.RelativePath, Android.OS.Environment.DirectoryDocuments);
                Android.Net.Uri uri = Application.Context.ContentResolver.Insert(MediaStore.Files.GetContentUri(MediaStore.VolumeExternalPrimary), values);
            }
            catch (Exception ex)
            {
                string errorMessage = "Error: Failed to write Javascript to file: Filename = " + fileName + ": " + ex.Message;
                System.Console.WriteLine(errorMessage);
                throw new Exception(errorMessage);
            }
        }

        public static void WriteHTMLToExternalStorage(string fileName, string fileContents)
        {
            try
            {
                //Get the latest context
                Java.IO.File externalFilesDir = Application.Context.GetExternalFilesDir(null);

                // Create a new file in the directory
                Java.IO.File file = new Java.IO.File(externalFilesDir, fileName);

                // Open a stream for writing to the file
                using (var stream = new FileOutputStream(file))
                {
                    // Write the contents to the file
                    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(fileContents);
                    stream.Write(bytes);
                }

                // Notify the system that a new file has been created and needs to be added to media store
                ContentValues values = new ContentValues();
                values.Put(MediaStore.IMediaColumns.DisplayName, fileName);
                values.Put(MediaStore.IMediaColumns.MimeType, "text/html");
                values.Put(MediaStore.IMediaColumns.RelativePath, Android.OS.Environment.DirectoryDocuments);
                Android.Net.Uri uri = Application.Context.ContentResolver.Insert(MediaStore.Files.GetContentUri(MediaStore.VolumeExternalPrimary), values);
            }
            catch (Exception ex)
            {
                string errorMessage = "Error: Failed to write html file to device: Filename = " + fileName + ": " + ex.Message;
                System.Console.WriteLine(errorMessage);
                throw new Exception(errorMessage);
            }
        }

        //This method is used to read a file and return the contents as a string
        //This method should be utilized by other methods within this class and not access directly
        public static string ReadFileFromExternalStorage(string fileName)
        {
            string fileContent = null;
            try
            {
                // Get the root directory of the app's external storage
                Java.IO.File externalFilesDir = Application.Context.GetExternalFilesDir(null);

                // Create a new file object in the directory
                Java.IO.File file = new Java.IO.File(externalFilesDir, fileName);

                // Open a stream for reading the file
                using (var stream = new FileInputStream(file))
                {
                    // Read the contents of the file
                    byte[] bytes = new byte[stream.Available()];
                    stream.Read(bytes);
                    fileContent = System.Text.Encoding.UTF8.GetString(bytes);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Failed to read file: Filename = " + fileName + ": " + ex.Message;
                System.Console.WriteLine(errorMessage);
                throw new Exception(errorMessage);
            }

            return fileContent;
        }

        //This method is used to delete the file cache specified in the parameter
        //This method should be utilized by other methods within this class and not accessed directly
        public static void DeleteFileFromExternalStorage(string fileName)
        {
            try
            {
                // Get the root directory of the app's external storage
                Java.IO.File externalFilesDir = Application.Context.GetExternalFilesDir(null);

                // Create a new file object with the given filename in the directory
                Java.IO.File file = new Java.IO.File(externalFilesDir, fileName);

                // Check if the file exists
                if (file.Exists())
                {
                    // Delete the file
                    file.Delete();

                    // Notify the system that a file has been deleted and needs to be removed from media store
                    Android.Net.Uri uri = MediaStore.Files.GetContentUri(MediaStore.VolumeExternalPrimary);
                    Application.Context.ContentResolver.Delete(uri, MediaStore.IMediaColumns.Data + "=?", new string[] { file.Path });
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Error: Failed to delete file: Filename = " + fileName + ": " + ex.Message;
                System.Console.WriteLine(errorMessage);
                throw new Exception(errorMessage);
            }
        }
    }
}