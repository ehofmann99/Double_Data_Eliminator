using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Double_Data_Eliminator
{
    class Double_data_delete_Functions
    {
        //Double_data_delete deletes all files which are stored in the deletelist textfile
        static public void Double_data_delete(List<string> final_delete_list)
        {
            Debug.WriteLine("\nAusgabe der Dateien, welche tatsächlich gelöscht werden (Double_data_delete)\n");

            //ProgressBar myprogressbar = (ProgressBar)Application.OpenForms["Form1"].Controls.Find("Progressbar", false).FirstOrDefault();
            //myprogressbar.Maximum = final_delete_list.Count;
            //myprogressbar.Value = 0;

            Span<string> final_delete_listSpan = final_delete_list.ToArray();

            for (int index = 0; index < final_delete_listSpan.Length; index++)
            {
                try
                {
                    //test if the path is a directory
                    FileAttributes path_attributes = File.GetAttributes(final_delete_listSpan[index]);

                    if (path_attributes.HasFlag(FileAttributes.Directory))
                    {
                        //delete the empty directory
                        Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(final_delete_listSpan[index], Microsoft.VisualBasic.FileIO.DeleteDirectoryOption.ThrowIfDirectoryNonEmpty);

                        Debug.WriteLine(final_delete_listSpan[index]);
                    }
                    else
                    {
                        //the files are not actually deleted, they get stored in the RecycleBin 

                        Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(final_delete_listSpan[index],
                        Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs,
                        Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);

                        Debug.WriteLine(final_delete_listSpan[index]);
                    }
                }
                catch (System.Exception)
                {
                    //myprogressbar.Value += 1;
                    continue;
                }

                //myprogressbar.Value += 1;

            }
        }

    }
}
