using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static Double_Data_Eliminator.Form1;


namespace Double_Data_Eliminator
{
    static class Deletelist_creator_Functions
    {

        //Delelist_creator searches for files which have the same name, if it finds two files with the same Name it writes the
        //path of the second name in the delete_list textfile(which is stored in the executable path)

        //for every new filename, it creats a new textfile in the executable path, which has
        //the name of the first letter of the new filename and write the path of the new found file in it 

        //the Deletelist_creator uses the all_found_files_list textfile to read out the name of the files 

        static public void Deletelist_creator()
        {
            //read out all lines from the "all_found_files_list.txt" file into a "all_found_files_list" list
            DirectoryInfo directory_executable = new DirectoryInfo((Application.ExecutablePath));
            List<string> all_found_files_list = File.ReadLines(directory_executable.Parent.FullName + "\\all_found_files_list.txt").ToList();

            // Add the newly created textfile to the Programm files list (list which contains the created textfiles during runtime)
            Main_Function.textfiles_used_in_program.Add((directory_executable.Parent.FullName + "\\path_list_read.txt"));

            File.Create(directory_executable.Parent.FullName + "\\file_list_delete.txt").Close();

            //Setup the deligate to access Form1 Progressbar 
            var form1 = Application.OpenForms[0];
            Double_Data_Eliminator.Form1.Test9999deligate myTest9999delegate = new Double_Data_Eliminator.Form1.Test9999deligate(ProgressBar_setup);
            form1.Invoke(myTest9999delegate, all_found_files_list.Count % 1000);

            int abstandProgressBar = all_found_files_list.Count / 10;

            if (all_found_files_list.Count <= 10)
            {
                abstandProgressBar = 1;
            }

            int index = 0;

            foreach (string line in all_found_files_list)
            {
                //read all characters from the "all_found_files_list" into an char array to get the first letter("first_letter_from_filename") of the filename

                if (line.Length > 248)
                {
                    continue;
                }

                char first_letter_from_filename = Get_first_letter(line);

                DirectoryInfo filepath = new DirectoryInfo(line);
                string filename = filepath.Name;

                //create a new textfile with the first letter of the new path and store the path in it (to know if a path was already discovered once before)
                if (File.Exists(directory_executable.Parent.FullName + "\\" + first_letter_from_filename + ".txt"))
                {
                    List<string> lines_first_letter_textfile = File.ReadAllLines(directory_executable.Parent.FullName + "\\" + first_letter_from_filename + ".txt").ToList();

                    //test if lines_first_letter_textfile contains filename
                    bool test = false;

                    foreach (string path in lines_first_letter_textfile)
                    {
                        DirectoryInfo file = new DirectoryInfo(line);

                        if (path.Contains(filename))
                        {
                            test = true;
                        }
                    }

                    if (test)
                    {
                        //write the path in the delete_list textfile if the filename was already found before
                        Append_Text_to_delete_list(line, directory_executable);
                    }
                    else
                    {
                        //write path into first_letter_list 
                        using (StreamWriter streamwriter_first_letter_from_filename = File.AppendText(directory_executable.Parent.FullName + "\\" + first_letter_from_filename + ".txt"))
                        {
                            streamwriter_first_letter_from_filename.WriteLine(line);
                        }
                    }
                }
                else
                {
                    //if the Path doesnt already exists, create a new one and store the filepath inside it
                    Create_Textfile_with_path_inside(line, first_letter_from_filename, directory_executable);
                }

                switch (index % abstandProgressBar)
                {
                    case (0):
                        Double_Data_Eliminator.Form1.Test999deligate myTest999delegate = new Double_Data_Eliminator.Form1.Test999deligate(ProgressBar_increase);
                        form1.Invoke(myTest999delegate);
                        break;
                }

                index++;
            }
        }

        private static void Append_Text_to_delete_list(string line, DirectoryInfo directory_executable)
        {
            using (StreamWriter streamwriter_file_list_delete = File.AppendText(directory_executable.Parent.FullName + "\\file_list_delete.txt"))
            {
                streamwriter_file_list_delete.WriteLine(line);
            }
        }

        private static void Create_Textfile_with_path_inside(string line, char first_letter_from_filename, DirectoryInfo directory_executable)
        {
            using (StreamWriter streamwriter_first_letter_from_filename = File.AppendText(directory_executable.Parent.FullName + "\\" + first_letter_from_filename + ".txt"))
            {
                streamwriter_first_letter_from_filename.WriteLine(line);
            }

            Main_Function.textfiles_used_in_program.Add(directory_executable.Parent.FullName + "\\" + first_letter_from_filename + ".txt");

        }

        private static char Get_first_letter(string path_complete)
        {
            //Name der Datei zu dem Pfad ermitteln
            // 20221225 = ["C:\Users\Test\Documents\20221225"].Split('\\').Last()
            string dateiname = path_complete.Split('\\').Last();

            //Den ersten Buchstaben des Namen zurückgeben
            return dateiname[0];
        }
    }
}