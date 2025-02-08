namespace CodeRaid
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            app_name.Text = $"{Application.ProductName} ({Application.ProductVersion})";
        }

        private void app_project_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/welcometopwn/rust-code-raid",
                UseShellExecute = true
            };
            System.Diagnostics.Process.Start(psi);
        }
    }


}
