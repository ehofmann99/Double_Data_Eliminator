using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Double_Data_Eliminator
{
    class Directory_scanner_paths_Functions
    {
        //Directory_scanner scanns all Paths in the Users chosen Path and writes all of them into a path list,
        //which is stored as a textfile in the executablepath
        static public List<string> Directory_scanner_paths(string origin_folder_path)
        {
            if (!(origin_folder_path != null))
            {
                return null;
            }

            Debug.WriteLine("\nAusgabe Directory_scanner_paths\n");

            List<string> directories_list = new List<string>
            {
                origin_folder_path
            };

            for (int index = 0; index < directories_list.Count; index++)
            {
                try
                {
                    string[] list = Directory.GetDirectories(directories_list[index]);

                    if (list.Length == 0)
                    {
                        continue;
                    }

                    foreach (string path in list)
                    {
                        directories_list.Add(path);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }

            }

            // Create a file to write to.
            using (StreamWriter streamwriter_path_list = File.CreateText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\path_list.txt"))
            {
                foreach (string path in directories_list)
                {
                    Debug.WriteLine(path);
                    streamwriter_path_list.WriteLine(path);
                }

            }

            Main_Function.textfiles_used_in_program.Add(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\path_list.txt");
            return directories_list;
        }
    }
}

