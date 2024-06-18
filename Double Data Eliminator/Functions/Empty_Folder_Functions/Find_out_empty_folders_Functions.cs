using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static Double_Data_Eliminator.Form1;

namespace Double_Data_Eliminator
{
    static class Find_out_empty_folders_Functions
    {
        public static void Find_out_empty_folders(List<string> path_list_local, string origin_folder_path)
        {
            //Debug.WriteLine("\nAusgabe Find_out_empty_folders:\n");

            //Debug.WriteLine("Origin Path:");
            //Debug.WriteLine(origin_folder_path);

            //Debug.WriteLine("\nPath_list_local Liste:");

            //foreach (string line in path_list_local)
            //{
            //    Debug.WriteLine(line);
            //}

            if (path_list_local.Count == 0)
            {
                return;
            }

            //Setup Deligate to get access to Form1
            var form1 = Application.OpenForms[0];
            Double_Data_Eliminator.Form1.Test9999deligate myTest9999delegate = new Double_Data_Eliminator.Form1.Test9999deligate(ProgressBar_setup);
            form1.Invoke(myTest9999delegate, path_list_local.Count % 1000);

            //Setup Progressbar
            int abstandProgressBar = path_list_local.Count / 10;

            if (path_list_local.Count <= 10)
            {
                abstandProgressBar = 1;
            }

            var mc1 = new Foldertest_Functions();

            //do the actual foldertest
            for (int index = 0; index < path_list_local.Count; index++)
            {
                mc1.Foldertest(path_list_local[index], origin_folder_path, path_list_local);

                //every 10. Index, the Progressbar increases by 10
                switch (index % abstandProgressBar)
                {
                    case (0):
                        Double_Data_Eliminator.Form1.Test999deligate myTest999delegate = new Double_Data_Eliminator.Form1.Test999deligate(ProgressBar_increase);
                        form1.Invoke(myTest999delegate);
                        break;
                }
            }

        }
    }
}


