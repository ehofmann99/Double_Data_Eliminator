using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Double_Data_Eliminator
{

    class Directory_scanner_files_Functions
    {
        //Diretory_scanner scanns all paths from the path list and creats a new textfile(named filelist) in the executable path which stores
        //all paths to all files that where found in all path from path list

        static public void Directory_scanner_files(List<string> path_list)
        {
            if (!(path_list.Count > 0))
            {
                return;
            }

            List<string> path_list_test = path_list;

            File.Create(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\all_found_files_list.txt").Close();

            for (int index = 0; index < path_list_test.Count; index++)
            {
                string path = path_list_test[index];

                if (!(Directory.Exists(path)))
                {
                    continue;
                }

                try
                {
                    Get_files_in_directory(path);
                }
                catch (Exception)
                {
                    continue;
                }

            }

            Main_Function.textfiles_used_in_program.Add(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\all_found_files_list.txt");
            return;
        }

        //Gets all files in the directory and stores them in the "all_found_files_list" file
        private static void Get_files_in_directory(string path)
        {
            string[] file_list_from_directory = Directory.GetFiles(path);

            for (int index = 0; index < file_list_from_directory.Length; index++)
            {
                string line = file_list_from_directory[index];

                // Create a file to write to.
                using (StreamWriter streamwriter_all_found_files_list = File.AppendText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\all_found_files_list.txt"))
                {
                    streamwriter_all_found_files_list.WriteLine(line);
                }

            }
        }
    }
}