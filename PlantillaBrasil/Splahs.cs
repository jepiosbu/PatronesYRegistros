using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace PlantillaBrasil
{
    public partial class Splahs : Form
    {
        int con;
        string[] vectorRutasVideo = new string[3];
        public Splahs()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = SystemInformation.PrimaryMonitorSize;
            this.StartPosition = FormStartPosition.CenterScreen;
            vectorRutasVideo[0] = @"C:\Users\ender\Downloads\videoplayback.mp4";
            vectorRutasVideo[1] = @"C:\Users\ender\Downloads\videoplayKimetsu.mp4";
            vectorRutasVideo[2] = @"C:\Users\ender\Downloads\videoplayGojoSatoru.mp4";
            con = Properties.Settings.Default.RamdonVideo;
            


}
        private void Reproductor_Enter(object sender, EventArgs e)
        {
            string mp4Path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "videoplayback.mp4");

            if (!File.Exists(mp4Path))
            {
                File.WriteAllBytes(mp4Path, Properties.Resources.videoplayback);
            }
            Reproductor.URL = mp4Path;
            Reproductor.Ctlcontrols.play();
            TimeOpen.Enabled = true;
            Reproductor.Ctlenabled = false;
            Reproductor.Size = SystemInformation.PrimaryMonitorSize;
        }

        private void Reproductor_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            
            if (Reproductor.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                Reproductor.fullScreen = true;
            }
        }

        private void TimeOpen_Tick(object sender, EventArgs e)
        {
            Bienvenida form2 = new Bienvenida();
            TimeOpen.Enabled = false;
            this.Hide();
            form2.Show();
            
            
        }

        private void Splahs_FormClosed(object sender, FormClosedEventArgs e)
        {
       
        }
    }
}
