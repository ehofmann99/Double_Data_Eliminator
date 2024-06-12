using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Double_Data_Eliminator.Functions.Files_with_same_content;
using System.Net.Http;
using System.Text;

namespace Double_Data_Eliminator
{
    //Testkommentar
    public partial class Form1 : Form
    {
        public delegate void Test999deligate();
        public delegate void Test9999deligate(int laenge);

        public int progressBar_groesse = 0;
        public Form1()
        {
            InitializeComponent();
            ProgressBar.CreateControl();
        }

        public void Button_Confirm_Path_Click(object sender, EventArgs e)
        {

            string origin_folder_path = TextBox_Input_Path.Text;

            if (!(origin_folder_path.Length > 0))
            {
                MessageBox.Show("Please enter a valid destination path.", "Error: The destination path is missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(Directory.Exists(origin_folder_path)))
            {
                MessageBox.Show(origin_folder_path, "Error: Could not reach the Destinationpath", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (RBttn_Find_Same_Name.Checked ||
                RBttn_Find_Empty_Folders.Checked ||
                RBttn_Find_Same_Content.Checked)
            {
                Button_Confirm_Path.Enabled = false;
                Confirm_deletion_button.Enabled = false;
            }

            //Get all directories from the origin_folder_path
            List<string> path_list = Directory_scanner_paths_Functions.Directory_scanner_paths(origin_folder_path);

            //read all existing files in folders and subfolders
            Directory_scanner_files_Functions.Directory_scanner_files(path_list);

            DirectoryInfo directory_executable = new DirectoryInfo((System.Windows.Forms.Application.ExecutablePath));

            ProgressBar.Value = 0;

            if (!(RBttn_Find_Same_Name.Checked || RBttn_Find_Empty_Folders.Checked || RBttn_Find_Same_Content.Checked))
            {
                MessageBox.Show("Please select a search option befor you try searching", "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(path_list.Count > 0))
            {
                MessageBox.Show("The Path does not have any directories in it", "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(File.Exists(directory_executable.Parent.FullName + "\\file_list_delete.txt")))
            {
                File.Create(directory_executable.Parent.FullName + "\\file_list_delete.txt").Close();
                Main_Function.textfiles_used_in_program.Add(directory_executable.Parent.FullName + "\\file_list_delete.txt");
            }

            CheckedListBox_Paths_To_Delete.Items.Clear();

            ProgressBar myprogressbar = (ProgressBar)System.Windows.Forms.Application.OpenForms["Form1"].Controls.Find("Progressbar", false).FirstOrDefault();
            myprogressbar.Maximum = 100;
            myprogressbar.Value = 0;

            //check if at least one of the searching options is checked
            if (RBttn_Find_Same_Name.Checked)
            {
                Thread thread_Find_Same_Name = new Thread(() =>
                {
                    Deletelist_creator_Functions.Deletelist_creator();
                    Checkbox_Ausgabe();
                });

                thread_Find_Same_Name.Start();
                //thread_Find_Same_Name.Join();
            }

            if (RBttn_Find_Empty_Folders.Checked)
            {
                path_list.Reverse();

                Thread thread_Find_Empty_Folders = new Thread(() =>
                {
                    Find_out_empty_folders_Functions.Find_out_empty_folders(path_list, origin_folder_path);
                    Checkbox_Ausgabe();
                });

                thread_Find_Empty_Folders.Start();
                //thread_Find_Empty_Folders.Join();
            }

            if (RBttn_Find_Same_Content.Checked)
            {

                Thread thread_Find_Same_Content = new Thread(() =>
                {
                    Find_out_files_with_same_content.Get_files_with_same_content();
                    Checkbox_Ausgabe();
                });

                thread_Find_Same_Content.Start();

                //UI soll warten bis der Thread beendet ist 
                //thread_Find_Same_Content.Join();
            }

        }

        public void Button_Confirm_Deletion_Click(object sender, EventArgs e)
        {
            List<string> delete_list = new List<string>();

            for (int i = 0; i < CheckedListBox_Paths_To_Delete.CheckedItems.Count; i++)
            {
                string listenBox = (string)CheckedListBox_Paths_To_Delete.CheckedItems[i];
                delete_list.Add(listenBox);
            }

            Thread mythread = new Thread(() =>
            {
                //create a list "delete_list" with only the items which are checked by the user
                Debug.WriteLine("Task wird gestartet");

                //delete the files stored in the "delete_list" list
                Double_data_delete_Functions.Double_data_delete(delete_list);

                File.Delete(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\file_list_delete.txt");

                MessageBox.Show("Thank you", "The Task executed successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);


            });

            mythread.Start();
            mythread.Join();

            CheckedListBox_Paths_To_Delete.Items.Clear();
        }

        public void Checkbox_Ausgabe()
        {
            //Show the "delete_list" in the CheckboxListBox
            Debug.WriteLine("\nAusgabe Checkbox Inhalt(Form1)\n");

            DirectoryInfo directory_executable = new DirectoryInfo((System.Windows.Forms.Application.ExecutablePath));

            List<string> delete_list;
            delete_list = File.ReadAllLines(directory_executable.Parent.FullName + "\\file_list_delete.txt").ToList();
            delete_list.Sort();

            //Span<string> delete_listSpan = delete_list.ToArray();


            Thread.Sleep(1000);
            this.BeginInvoke((MethodInvoker)delegate()
            {
                for (int index = 0; index < delete_list.Count; index++)
                {
                    Debug.WriteLine(delete_list[index]);

                    CheckedListBox_Paths_To_Delete.Items.Add(delete_list[index]);
                }
            });


            //select all checkbox items

            Thread.Sleep(1000);
            this.BeginInvoke((MethodInvoker)delegate()
            {
                for (int i = 0; i < CheckedListBox_Paths_To_Delete.Items.Count; i++)
                {
                    CheckedListBox_Paths_To_Delete.SetItemChecked(i, true);
                }

            });


            //delete all remaining textfiles used in the programm
            Delete_Textfiles_Functions.Delete_Textfiles();

            //delete the "delete_list" textfile
            File.Delete(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\file_list_delete.txt");

            Thread.Sleep(1000);
            this.BeginInvoke((MethodInvoker)delegate()
            {
                ProgressBar.Increment(100);

                Button_Confirm_Path.Enabled = true;
                Confirm_deletion_button.Enabled = true;
            });


        }

        public static void ProgressBar_setup(int laenge)
        {
            var form1 = System.Windows.Forms.Application.OpenForms[0];
            //Control mycontrol = form1.Controls["ProgressBar"]; 
            ProgressBar mycontrol = (ProgressBar)form1.Controls["ProgressBar"];

            Thread.Sleep(1000);
            form1.BeginInvoke((MethodInvoker)delegate ()
            {
                mycontrol.Minimum = 0;
                mycontrol.Maximum = 100;
            });
        }

            public static void ProgressBar_increase()
        {
            //Double_Data_Eliminator.Form1 myform = new Form1();
            //TextBox_Input_Path.CreateControl();

            var form1 = System.Windows.Forms.Application.OpenForms[0];
            //Control mycontrol = form1.Controls["ProgressBar"]; 
            ProgressBar mycontrol = (ProgressBar)form1.Controls["ProgressBar"];

            Thread.Sleep(1000);
            form1.BeginInvoke((MethodInvoker)delegate ()
            {
                mycontrol.Increment(10);
            });

            //Debug.WriteLine(TextBox_Input_Path.Text);
        }

        private void Button_Commit_Error_Click(object sender, EventArgs e)
        {
            String message = TextBox_ErrorMessage.Text;

            if(message.Length == 0) {
                return;
            }

            CreateIssue(message);
        }

        //Rest API von Github nutzen, um ein neues Issue zu erzeugen
        private static async void CreateIssue(string message)

        {
            var owner = "ehofmann99";
            var repo = "Double_Data_Eliminator";
            var token = "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";

            //Issue Nachricht konfigurieren 
            var issue = new
            {
                title = "Found a bug",
                body = message,
                assignees = new[] { "ehofmann99" },
                labels = new[] { "bug" }
            };

            //Nachricht in Json umwandeln
            var json = System.Text.Json.JsonSerializer.Serialize(issue);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            //Nachricht mit dem http Client an die API Schnittstelle von Github senden
            using (var client = new HttpClient())
            {
                //Request Header Konfiguration
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
                client.DefaultRequestHeaders.Add("Accept", "application/vnd.github+json");
                client.DefaultRequestHeaders.Add("user-agent", "ehofmann99");

                //Ziel URL der Nachricht angeben
                var url = $"https://api.github.com/repos/{owner}/{repo}/issues";

                //Response Nachricht von Github auffangen
                var response = await client.PostAsync(url, data);

                //Response Nachricht auswerten
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Issue created: {result}");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");

                    //Gesamten Nachrichteninhalt ausgeben
                    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                }

            }
    }
    }

}




