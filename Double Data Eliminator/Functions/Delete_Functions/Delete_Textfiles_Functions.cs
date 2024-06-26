﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Double_Data_Eliminator
{
    public class Delete_Textfiles_Functions
    {
        //delete all Textfiles which where used during the program 
        //the paths of the used textfiles were stored during the runtime in the static "textfiles_used_in_program" variable
        //which is part of the main function, where it can be accessed from all functions

        static public void Delete_Textfiles()
        {
            //The following files where used during the Program
            Span<string> deletetextfiles = Main_Function.textfiles_used_in_program.ToArray();

            //List for not deletable Programm Textfiles
            List<string> problematicTextfiles = new List<string>();

            //delete the Textfiles used in the Program
            for (int i = 0; i < deletetextfiles.Length; i++)
            {
                string textfile = Main_Function.textfiles_used_in_program[i];
                Debug.WriteLine("\n!!! ORDNER WIRD GELÖSCHT :" + textfile);

                if(!(File.Exists(textfile)))
                {
                    problematicTextfiles.Add(textfile);
                    continue;
                }

                try
                {
                    File.Delete(textfile);
                }
                catch
                {
                    problematicTextfiles.Add(textfile);
                    continue;
                }
            
            }

            //Output which program files could not be deleted
            if (!(problematicTextfiles.Count == 0))
            {

                //Output of the Textfiles, which are not deletable
                for (int i = 0; i < problematicTextfiles.Count; i++)
                {
                    Debug.WriteLine("Programmtextfile konnte nicht gelöscht werden: " + problematicTextfiles[i]);
                }
              
            }

            return;
        }//end of function

    }
}
