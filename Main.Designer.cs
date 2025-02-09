namespace CodeRaid
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            b_prev = new Button();
            b_next = new Button();
            current_line = new TextBox();
            l_line = new Label();
            l_line_amount = new Label();
            current_code = new CustomRichTextBox();
            menuStrip1 = new MenuStrip();
            aToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            bToolStripMenuItem = new ToolStripMenuItem();
            opacityToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // b_prev
            // 
            b_prev.Location = new Point(132, 110);
            b_prev.Name = "b_prev";
            b_prev.Size = new Size(75, 23);
            b_prev.TabIndex = 2;
            b_prev.Text = "<<";
            b_prev.UseVisualStyleBackColor = true;
            b_prev.Click += ButtonPrevious_Click;
            // 
            // b_next
            // 
            b_next.Location = new Point(213, 110);
            b_next.Name = "b_next";
            b_next.Size = new Size(75, 23);
            b_next.TabIndex = 3;
            b_next.Text = ">>";
            b_next.UseVisualStyleBackColor = true;
            b_next.Click += ButtonNext_Click;
            // 
            // current_line
            // 
            current_line.Location = new Point(39, 111);
            current_line.MaxLength = 5;
            current_line.Name = "current_line";
            current_line.Size = new Size(38, 23);
            current_line.TabIndex = 4;
            // 
            // l_line
            // 
            l_line.AutoSize = true;
            l_line.Location = new Point(4, 114);
            l_line.Name = "l_line";
            l_line.Size = new Size(35, 15);
            l_line.TabIndex = 5;
            l_line.Text = "Code";
            // 
            // l_line_amount
            // 
            l_line_amount.AutoSize = true;
            l_line_amount.Location = new Point(77, 114);
            l_line_amount.Name = "l_line_amount";
            l_line_amount.Size = new Size(22, 15);
            l_line_amount.TabIndex = 6;
            l_line_amount.Text = "/ #";
            // 
            // current_code
            // 
            current_code.Anchor = AnchorStyles.None;
            current_code.BackColor = SystemColors.Control;
            current_code.BorderStyle = BorderStyle.None;
            current_code.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            current_code.Location = new Point(111, 44);
            current_code.Margin = new Padding(0);
            current_code.MaxLength = 4;
            current_code.Multiline = false;
            current_code.Name = "current_code";
            current_code.ReadOnly = true;
            current_code.ScrollBars = RichTextBoxScrollBars.None;
            current_code.Size = new Size(73, 43);
            current_code.TabIndex = 7;
            current_code.TabStop = false;
            current_code.Text = "0000";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { aToolStripMenuItem, bToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(290, 24);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // aToolStripMenuItem
            // 
            aToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem });
            aToolStripMenuItem.Name = "aToolStripMenuItem";
            aToolStripMenuItem.Size = new Size(37, 20);
            aToolStripMenuItem.Text = "File";
            aToolStripMenuItem.Click += aToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(112, 22);
            openToolStripMenuItem.Text = "Open...";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // bToolStripMenuItem
            // 
            bToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { opacityToolStripMenuItem });
            bToolStripMenuItem.Name = "bToolStripMenuItem";
            bToolStripMenuItem.Size = new Size(61, 20);
            bToolStripMenuItem.Text = "Options";
            // 
            // opacityToolStripMenuItem
            // 
            opacityToolStripMenuItem.Name = "opacityToolStripMenuItem";
            opacityToolStripMenuItem.Size = new Size(115, 22);
            opacityToolStripMenuItem.Text = "Opacity";
            opacityToolStripMenuItem.Click += opacityToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(107, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(290, 136);
            Controls.Add(current_code);
            Controls.Add(l_line_amount);
            Controls.Add(l_line);
            Controls.Add(current_line);
            Controls.Add(b_next);
            Controls.Add(b_prev);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Main";
            Opacity = 0.8D;
            ShowIcon = false;
            Text = "Code Raid Tool";
            FormClosing += Main_FormClosing;
            Load += Main_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        public class CustomRichTextBox : RichTextBox
        {
            const int WM_LBUTTONDOWN = 0x201;
            const int WM_RBUTTONDOWN = 0x204;
            const int WM_MBUTTONDOWN = 0x207;
            const int WM_LBUTTONDBLCLK = 0x203;
            const int WM_RBUTTONDBLCLK = 0x206;
            const int WM_MBUTTONDBLCLK = 0x209;
            const int WM_SETCURSOR = 0x20;

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM_LBUTTONDOWN || m.Msg == WM_RBUTTONDOWN || m.Msg == WM_MBUTTONDOWN || m.Msg == WM_LBUTTONDBLCLK || m.Msg == WM_RBUTTONDBLCLK || m.Msg == WM_MBUTTONDBLCLK || m.Msg == WM_SETCURSOR)
                {
                    return;
                }
                base.WndProc(ref m);
            }
        }
        

        #endregion
        private Button b_prev;
        private Button b_next;
        private TextBox current_line;
        private Label l_line;
        private Label l_line_amount;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem aToolStripMenuItem;
        private ToolStripMenuItem bToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem opacityToolStripMenuItem;
        private CustomRichTextBox current_code;
        private ToolStripMenuItem aboutToolStripMenuItem;
    }
}
