using System.IO;
using Xamarin.Forms;
using EZCode.Droid;
using System;

[assembly: Dependency(typeof(DatabaseHelper))]
namespace EZCode.Droid
{
    public class DatabaseHelper : IDatabaseHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string docFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, fileName);
        }

        public void CopyDatabaseToLocal(string dbPath)
        {
            if (!System.IO.File.Exists(dbPath))
            {
                Console.WriteLine("Copying database path:" + dbPath);
                var s = Android.App.Application.Context.Resources.OpenRawResource(Resource.Raw.EZCodeDatabase);

                FileStream writeStream = new FileStream(dbPath, FileMode.OpenOrCreate, FileAccess.Write);
                ReadWriteStream(s, writeStream);
            }
        }

        private void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int Length = 256;
            Byte[] buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer, 0, Length);
            // write the required bytes
            while (bytesRead > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
        }
    }
}