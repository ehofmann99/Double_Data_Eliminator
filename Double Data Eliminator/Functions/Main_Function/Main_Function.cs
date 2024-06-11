using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Double_Data_Eliminator
{
    static class Main_Function
    {

        static public List<string> textfiles_used_in_program = new List<string>(1000);

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }

    }

}
