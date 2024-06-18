using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static Double_Data_Eliminator.Form1;

namespace Double_Data_Eliminator.Functions.Files_with_same_content
{
    public class Find_out_files_with_same_content
    {
        private delegate void DELEGATE();

        public static object CollectionsMarshal { get; private set; }

        public static void Get_files_with_same_content()
        {
            //Querys to avoid errors

            List<string> fileList = File.ReadAllLines(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\all_found_files_list.txt").ToList();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            if (!fileList.Any())
            {
                return;
            }

            Debug.WriteLine("\nGet_files_with_same_content ausgabe\n");
            Debug.WriteLine("\nÜbergebene Liste\n");

            //Sort the filelists after the length to reduce compairingtimes

            Debug.WriteLine("\nDateigrößen und Listenname anzeigen\n");

            fileList = fileList.OrderBy(FL => FL.Length).ToList();

            Span<string> fileListSpan = fileList.ToArray();

            //Span<Tuple<string, bool, bool>> fileListSpanFlagged2 = fileList.Select(file => new Tuple<string, bool, bool>(file, false, false)).ToArray();

            //List<Tuple<string, bool, bool>> fileListProcessed = fileListSpanFlagged2.ToArray().ToList();
            //List<Tuple<string, bool, bool>> resultat = fileListProcessed.Where(tup => tup.Item3 == false).ToList();

            for (int i = 0; i < fileListSpan.Length; i++)
            {
                Debug.WriteLine(fileListSpan[i]);
            }
            //fileList.ForEach(file => Debug.WriteLine(file));

            var lengthListDictionary = new Dictionary<string, List<string>>();

            for (int i = 0; i < fileListSpan.Length; i++)
            {
                if (fileListSpan[i].Length > 248)
                {
                    continue;
                }

                if(!File.Exists(fileListSpan[i]))
                {
                    continue;
                }

                var fi1 = new FileInfo(fileListSpan[i]);

                string listName = "Liste_" + fi1.Length;

                Debug.WriteLine("Dateiendung: " + fi1.Length);
                //Debug.WriteLine("Filetype without the point: " + fi1.Extension.Remove(0,1));
                //
                Debug.WriteLine("Listenname: " + listName + "\n");

                //If the Extenstionlist doesnt exist, create a new one 
                if (!(lengthListDictionary.ContainsKey(listName)))
                {
                    lengthListDictionary[listName] = new List<string>
                    {
                        fileListSpan[i]
                    };
                    continue;
                }

                //If the Extensionlist already exists, Add the path(fileListSpan[i]) to the existing List
                lengthListDictionary[listName].Add(fileListSpan[i]);

            }

            var form1 = Application.OpenForms[0];
            Double_Data_Eliminator.Form1.Test9999deligate myTest9999delegate = new Double_Data_Eliminator.Form1.Test9999deligate(ProgressBar_setup);
            
            form1.Invoke(myTest9999delegate, lengthListDictionary.Count%1000 );

            Debug.WriteLine("\nExtensionlisten:\n");

            List<string> deleteFileList = new List<string>();

            int abstandProgressBar = lengthListDictionary.Count / 10;

            if (lengthListDictionary.Count <= 10)
            {
                abstandProgressBar = 1;
            }

            //Parallel.For(0, lengthListDictionary.Count, index =>
            //{
            for (int index = 0; index < lengthListDictionary.Count; index++)
            {
                switch (index % abstandProgressBar)
                {
                    case (0):
                        Double_Data_Eliminator.Form1.Test999deligate myTest999delegate = new Double_Data_Eliminator.Form1.Test999deligate(ProgressBar_increase);
                        form1.Invoke(myTest999delegate);
                        break;
                }

                KeyValuePair<string, List<string>> entry = lengthListDictionary.ElementAt(index);

                if (entry.Value.Count == 1)
                {
                    continue;
                }

                Debug.WriteLine(entry.Key);

                // .Value are the diffent extensionslists in the Dictionary

                for (int i = 0; i < entry.Value.Count; i++)
                {
                    Debug.WriteLine("\n---> " + entry.Value[i]);

                    if (entry.Value.Count == 1)
                    {
                        return;
                    }

                    Größenvergleich(entry.Value, deleteFileList);

                }

            }
                //});


                DirectoryInfo directory_executable = new DirectoryInfo(Application.ExecutablePath);

                Span<string> deleteFileListSpan = deleteFileList.ToArray();

                for (int i = 0; i < deleteFileListSpan.Length; i++)
                {
                    using (StreamWriter streamwriter_file_list_delete = File.AppendText(directory_executable.Parent.FullName + "\\file_list_delete.txt"))
                    {
                        streamwriter_file_list_delete.WriteLine(deleteFileListSpan[i]);
                    }
                }

                stopWatch.Stop();

                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

                Console.WriteLine("\n\nRunTime " + elapsedTime);

            MessageBox.Show("Zeit die gebraucht wurde:" + elapsedTime, "Zeit");


        }

        static public void Größenvergleich(List<string> extensionList, List<string> deleteFileList)
        {
            //compaire every file in the list with every file underneth it
            for (int index = 0; index < extensionList.Count - 1; index++)
            {
                if(!File.Exists(extensionList[0]))
                {
                    extensionList.Remove(extensionList[0]);
                    return;
                }

                if(!File.Exists(extensionList[index + 1]))
                {
                    extensionList.Remove(extensionList[index + 1]);
                    return;
                }
                
                if (extensionList.Count == 1)
                {
                    return;
                }


                //compaire the size of both files
                FileInfo fi1 = new FileInfo(extensionList[0]);
                FileInfo fi2 = new FileInfo(extensionList[index + 1]);

                if (fi1.Length == fi2.Length)
                {
                    //if both have the same content, one of them is deleted from the list and the search starts from the top of the list(index = 0;) again
                    if (Inhaltsvergleich(fi1, fi2, fi1.Length, extensionList, deleteFileList))
                    {
                        index = 0;
                    }
                }

            }

        }

        static public bool Inhaltsvergleich(FileInfo firstFile, FileInfo secondFile, long Length, List<string> extensionList, List<string> deleteFileList)
        {

            try
            {

                if (!Bytevergleich(firstFile, secondFile, System.Convert.ToInt32(Length)))
                {
                    return false;
                }

                //Write files, to be found double, into the File_delete_list and remove the file from the current search in "extensionList"
                //Only delete the files which are further down the line in the selected folder -> to delete only files which are in the same folder 
                //for example to folders are the same -> only one folders in put is deleted
                if (firstFile.FullName.Length > secondFile.FullName.Length)
                {
                    deleteFileList.Add(firstFile.FullName);
                    extensionList.Remove(firstFile.FullName);

                    Debug.WriteLine("----------> " + firstFile + " GELÖSCHT");

                    return true;
                }

                deleteFileList.Add(secondFile.FullName);
                extensionList.Remove(secondFile.FullName);

                Debug.WriteLine("----------> " + secondFile + " GELÖSCHT");

                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }

        private static bool Bytevergleich(FileInfo firstFile, FileInfo secondFile, int Length)
        {
            try
            {
                Span<byte> firstFileBytesSpan = File.ReadAllBytes(firstFile.FullName).Take(Length % 10).ToArray();
                Span<byte> secondFileBytesSpan = File.ReadAllBytes(secondFile.FullName).Take(Length % 10).ToArray();

                if (firstFileBytesSpan.Length == 0 || secondFileBytesSpan.Length == 0)
                {
                    return false;
                }

                if (!firstFileBytesSpan.SequenceEqual(secondFileBytesSpan))
                {
                    return false;
                }

            }
            catch (Exception)
            {
                Debug.WriteLine("Ein Fehler beim Lesen der Datei ist aufgetreten.");
                return false;
            }

            return true;
        }
    }


}