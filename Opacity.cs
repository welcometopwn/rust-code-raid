using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeRaid
{
    public partial class Opacity : Form
    {
        public Opacity()
        {
            InitializeComponent();
            this.Load += new EventHandler(this.Opacity_Load);
        }

        private void trackBar_Opacity(object sender, EventArgs e)
        {
            TrackBar? trackBar = sender as TrackBar;
            if (trackBar != null)
            {
                // Convert the trackBar value to a percentage (0.05 to 1.0)
                double opacity = Math.Max(0.05, trackBar.Value / 100.0);

                // Get a reference to the main form
                Main? mainForm = Application.OpenForms.OfType<Main>().FirstOrDefault();
                if (mainForm != null)
                {
                    // Set the opacity of the main form
                    mainForm.Opacity = opacity;
                }
            }
        }
        private void Opacity_Load(object sender, EventArgs e)
        {
            // Get a reference to the main form
            Main? mainForm = Application.OpenForms.OfType<Main>().FirstOrDefault();
            if (mainForm != null)
            {
                // Convert the opacity of the main form to a trackBar value (10 to 100)
                int trackBarValue = (int)Math.Round(mainForm.Opacity * 100);
                trackBar1.Value = Math.Max(trackBar1.Minimum, Math.Min(trackBar1.Maximum, trackBarValue));
            }
        }
    }
}
