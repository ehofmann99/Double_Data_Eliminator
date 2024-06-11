
namespace Double_Data_Eliminator
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox_Input_Path = new System.Windows.Forms.TextBox();
            this.Button_Confirm_Path = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Confirm_deletion_button = new System.Windows.Forms.Button();
            this.CheckedListBox_Paths_To_Delete = new System.Windows.Forms.CheckedListBox();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.RBttn_Find_Empty_Folders = new System.Windows.Forms.RadioButton();
            this.RBttn_Find_Same_Name = new System.Windows.Forms.RadioButton();
            this.RBttn_Find_Same_Content = new System.Windows.Forms.RadioButton();
            this.Settings = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Button_Commit_Error = new System.Windows.Forms.Button();
            this.TextBox_ErrorMessage = new System.Windows.Forms.TextBox();
            this.Settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 190);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter your destinationpath here";
            // 
            // TextBox_Input_Path
            // 
            this.TextBox_Input_Path.Location = new System.Drawing.Point(22, 223);
            this.TextBox_Input_Path.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TextBox_Input_Path.Name = "TextBox_Input_Path";
            this.TextBox_Input_Path.Size = new System.Drawing.Size(338, 20);
            this.TextBox_Input_Path.TabIndex = 1;
            this.TextBox_Input_Path.Text = "C:\\Users\\ehofm\\Desktop\\Testverzeichnis";
            // 
            // Button_Confirm_Path
            // 
            this.Button_Confirm_Path.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button_Confirm_Path.ForeColor = System.Drawing.Color.Black;
            this.Button_Confirm_Path.Location = new System.Drawing.Point(373, 223);
            this.Button_Confirm_Path.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Button_Confirm_Path.Name = "Button_Confirm_Path";
            this.Button_Confirm_Path.Size = new System.Drawing.Size(85, 45);
            this.Button_Confirm_Path.TabIndex = 2;
            this.Button_Confirm_Path.Text = "Confirm path";
            this.Button_Confirm_Path.UseVisualStyleBackColor = false;
            this.Button_Confirm_Path.Click += new System.EventHandler(this.Button_Confirm_Path_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 287);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Please check the files you want to be deleted";
            // 
            // Confirm_deletion_button
            // 
            this.Confirm_deletion_button.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Confirm_deletion_button.Location = new System.Drawing.Point(373, 458);
            this.Confirm_deletion_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Confirm_deletion_button.Name = "Confirm_deletion_button";
            this.Confirm_deletion_button.Size = new System.Drawing.Size(85, 45);
            this.Confirm_deletion_button.TabIndex = 5;
            this.Confirm_deletion_button.Text = "Confirm deletion";
            this.Confirm_deletion_button.UseVisualStyleBackColor = false;
            this.Confirm_deletion_button.Click += new System.EventHandler(this.Button_Confirm_Deletion_Click);
            // 
            // CheckedListBox_Paths_To_Delete
            // 
            this.CheckedListBox_Paths_To_Delete.FormattingEnabled = true;
            this.CheckedListBox_Paths_To_Delete.HorizontalScrollbar = true;
            this.CheckedListBox_Paths_To_Delete.Location = new System.Drawing.Point(22, 318);
            this.CheckedListBox_Paths_To_Delete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CheckedListBox_Paths_To_Delete.Name = "CheckedListBox_Paths_To_Delete";
            this.CheckedListBox_Paths_To_Delete.Size = new System.Drawing.Size(436, 109);
            this.CheckedListBox_Paths_To_Delete.TabIndex = 3;
            // 
            // ProgressBar
            // 
            this.ProgressBar.BackColor = System.Drawing.Color.White;
            this.ProgressBar.ForeColor = System.Drawing.SystemColors.Control;
            this.ProgressBar.Location = new System.Drawing.Point(22, 260);
            this.ProgressBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(336, 12);
            this.ProgressBar.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 61);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Please enter your prefered options";
            // 
            // RBttn_Find_Empty_Folders
            // 
            this.RBttn_Find_Empty_Folders.AutoSize = true;
            this.RBttn_Find_Empty_Folders.Location = new System.Drawing.Point(6, 13);
            this.RBttn_Find_Empty_Folders.Name = "RBttn_Find_Empty_Folders";
            this.RBttn_Find_Empty_Folders.Size = new System.Drawing.Size(128, 17);
            this.RBttn_Find_Empty_Folders.TabIndex = 8;
            this.RBttn_Find_Empty_Folders.TabStop = true;
            this.RBttn_Find_Empty_Folders.Text = "Find out empty folders";
            this.RBttn_Find_Empty_Folders.UseVisualStyleBackColor = true;
            // 
            // RBttn_Find_Same_Name
            // 
            this.RBttn_Find_Same_Name.AutoSize = true;
            this.RBttn_Find_Same_Name.Location = new System.Drawing.Point(6, 36);
            this.RBttn_Find_Same_Name.Name = "RBttn_Find_Same_Name";
            this.RBttn_Find_Same_Name.Size = new System.Drawing.Size(181, 17);
            this.RBttn_Find_Same_Name.TabIndex = 9;
            this.RBttn_Find_Same_Name.TabStop = true;
            this.RBttn_Find_Same_Name.Text = "Find out files with the same name";
            this.RBttn_Find_Same_Name.UseVisualStyleBackColor = true;
            // 
            // RBttn_Find_Same_Content
            // 
            this.RBttn_Find_Same_Content.AutoSize = true;
            this.RBttn_Find_Same_Content.Location = new System.Drawing.Point(6, 59);
            this.RBttn_Find_Same_Content.Name = "RBttn_Find_Same_Content";
            this.RBttn_Find_Same_Content.Size = new System.Drawing.Size(191, 17);
            this.RBttn_Find_Same_Content.TabIndex = 10;
            this.RBttn_Find_Same_Content.TabStop = true;
            this.RBttn_Find_Same_Content.Text = "Find out files with the same content";
            this.RBttn_Find_Same_Content.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.RBttn_Find_Empty_Folders);
            this.Settings.Controls.Add(this.RBttn_Find_Same_Content);
            this.Settings.Controls.Add(this.RBttn_Find_Same_Name);
            this.Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings.Location = new System.Drawing.Point(22, 87);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(436, 84);
            this.Settings.TabIndex = 11;
            this.Settings.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Double_Data_Eliminator.Properties.Resources._360_F_700047085_Z2IMFm6gHHzdS9uM6G0rthWyZe6YYPtR;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(485, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // Button_Commit_Error
            // 
            this.Button_Commit_Error.Location = new System.Drawing.Point(22, 458);
            this.Button_Commit_Error.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Button_Commit_Error.Name = "Button_Commit_Error";
            this.Button_Commit_Error.Size = new System.Drawing.Size(59, 36);
            this.Button_Commit_Error.TabIndex = 13;
            this.Button_Commit_Error.Text = "button1";
            this.Button_Commit_Error.UseVisualStyleBackColor = true;
            this.Button_Commit_Error.Click += new System.EventHandler(this.Button_Commit_Error_Click);
            // 
            // TextBox_ErrorMessage
            // 
            this.TextBox_ErrorMessage.Location = new System.Drawing.Point(100, 458);
            this.TextBox_ErrorMessage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TextBox_ErrorMessage.Name = "TextBox_ErrorMessage";
            this.TextBox_ErrorMessage.Size = new System.Drawing.Size(245, 20);
            this.TextBox_ErrorMessage.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(482, 513);
            this.Controls.Add(this.TextBox_ErrorMessage);
            this.Controls.Add(this.Button_Commit_Error);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.Confirm_deletion_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CheckedListBox_Paths_To_Delete);
            this.Controls.Add(this.Button_Confirm_Path);
            this.Controls.Add(this.TextBox_Input_Path);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Double Data Eliminator";
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBox_Input_Path;
        private System.Windows.Forms.Button Button_Confirm_Path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Confirm_deletion_button;
        private System.Windows.Forms.CheckedListBox CheckedListBox_Paths_To_Delete;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton RBttn_Find_Empty_Folders;
        private System.Windows.Forms.RadioButton RBttn_Find_Same_Name;
        private System.Windows.Forms.RadioButton RBttn_Find_Same_Content;
        private System.Windows.Forms.GroupBox Settings;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Button_Commit_Error;
        private System.Windows.Forms.TextBox TextBox_ErrorMessage;
    }
}

