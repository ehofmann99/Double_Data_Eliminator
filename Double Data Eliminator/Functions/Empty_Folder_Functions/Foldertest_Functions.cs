using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Double_Data_Eliminator
{
    class Foldertest_Functions
    {
        public void Foldertest(string starting_folder_path, string origin_folder_path, List<string> path_list_local)
        {
            //lösche pfad aus der liste
            path_list_local.Remove(starting_folder_path);

            //Debug.WriteLine("\nAusgabe des Foldertests\n");
            if (!(Directory.Exists(starting_folder_path)))
            {
                return;
            }

            //prüfe ob es dem pfad des Users enspricht 
            if (starting_folder_path == origin_folder_path)
            {
                //Debug.WriteLine("starting_folder_path ist der origin_folder_path");
                return;
            }

            if ((!(Directory.GetFiles(starting_folder_path).Length == 0)) ||
                !(Directory.GetDirectories(starting_folder_path).Length == 0))
            {
                //Debug.WriteLine(starting_folder_path + "Ordner ist nicht leer.");
                return;
            }

            //ist der ordner leer ? ---> lösche den leeren ordner
            try
            {
                //Debug.WriteLine(starting_folder_path + " wird gelöscht");
                //Directory.Delete(starting_folder_path);

                DirectoryInfo directory_executable = new DirectoryInfo((Application.ExecutablePath));

                using (StreamWriter streamwriter_file_list_delete = File.AppendText(directory_executable.Parent.FullName + "\\file_list_delete.txt"))
                {
                    streamwriter_file_list_delete.WriteLine(starting_folder_path);
                }
            }
            catch (IOException)
            {
                //Debug.WriteLine(starting_folder_path + " --------------------------------------------------------------hat IOException");
            }
            catch (UnauthorizedAccessException)
            {
                //Debug.WriteLine(starting_folder_path + "--------------------------------------------------------------hat UnauthorizedAccessException");
            }
            catch (ArgumentException)
            {
                //Debug.WriteLine(starting_folder_path + "--------------------------------------------------------------hat ArgumentException");
            }

            //rufe Find_out_empty_folders wieder auf 
            Find_out_empty_folders_Functions.Find_out_empty_folders(path_list_local, origin_folder_path);
        }


    }
}