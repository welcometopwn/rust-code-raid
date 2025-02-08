namespace CodeRaid
{
    partial class About
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            app_name = new Label();
            label1 = new Label();
            app_project_link = new LinkLabel();
            SuspendLayout();
            // 
            // app_name
            // 
            app_name.AutoSize = true;
            app_name.Location = new Point(12, 9);
            app_name.Name = "app_name";
            app_name.Size = new Size(64, 15);
            app_name.TabIndex = 0;
            app_name.Text = "App Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 27);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 1;
            label1.Text = "welcometopwn";
            // 
            // app_project_link
            // 
            app_project_link.AutoSize = true;
            app_project_link.LinkBehavior = LinkBehavior.NeverUnderline;
            app_project_link.Location = new Point(12, 45);
            app_project_link.Name = "app_project_link";
            app_project_link.Size = new Size(44, 15);
            app_project_link.TabIndex = 2;
            app_project_link.TabStop = true;
            app_project_link.Text = "Project";
            app_project_link.LinkClicked += app_project_link_LinkClicked;
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(217, 91);
            Controls.Add(app_project_link);
            Controls.Add(label1);
            Controls.Add(app_name);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "About";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "About";
            TopMost = true;
            Load += About_Load;
            ResumeLayout(false);
            PerformLayout();
        }




        #endregion

        private Label app_name;
        private Label label1;
        private LinkLabel app_project_link;
    }
}