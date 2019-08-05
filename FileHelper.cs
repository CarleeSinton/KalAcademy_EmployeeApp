using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace EmployeesApp
{
    public static class FileHelper
    {
        public async static void WriteTextFile(string filename, string content)
        {
            //Access to appdata folder
            var storageFolder = ApplicationData.Current.LocalFolder;
            
            //create a file on the folder 
            //Async - can only do it asynchronously (something is going to go get a file and report back)
            //we will overload this method
            var textFile = await storageFolder.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);
           
            //Open the file for write mode
            //Need to wait for the file to be completed before moving forward (only way to do it is multithreading but still have to wait)
            var textStream = await textFile.OpenAsync(FileAccessMode.ReadWrite);

            //Write the content into the stream
            var textWriter = new DataWriter(textStream);
            textWriter.WriteString(content);
           
            //Close file and save - don't need to wait but should (if you close you don't know if it actually saved)
            await textWriter.StoreAsync();
        }
    }
}
