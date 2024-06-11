using System.Diagnostics;
using System.IO;

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

            foreach (string line in Main_Function.textfiles_used_in_program)
            {
                Debug.WriteLine("\n!!! ORDNER WIRD GELÖSCHT :" + line);

                File.Delete(line);
            }

            return;
        }//end of function

    }
}
