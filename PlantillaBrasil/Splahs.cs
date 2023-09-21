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
        string[] vectorRutasVideo = new string[3];
        int con;
        int value;
        public Splahs()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            vectorRutasVideo[0] = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Kimetsu.mp4");
            File.WriteAllBytes(vectorRutasVideo[0], Properties.Resources.Kimetsu);
            vectorRutasVideo[1] = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Solo.mp4");
            File.WriteAllBytes(vectorRutasVideo[1], Properties.Resources.Solo);
            vectorRutasVideo[2] = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Tokyo.mp4");
            File.WriteAllBytes(vectorRutasVideo[2], Properties.Resources.Tokyo);

            this.Size = SystemInformation.PrimaryMonitorSize;
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        private void Reproductor_Enter(object sender, EventArgs e)
        {
            con = Properties.Settings.Default.RamdonVideo;
            Random random = new Random(); 
            value= random.Next(0, 3);
            while (con == value)
            {
                value = random.Next(0, 3);
                label1.Text = con.ToString();
            }
            if (con != value)
            {
                label1.Text = con.ToString();
            }
            
            Reproductor.URL = vectorRutasVideo[value]; 
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
            Reproductor.Ctlcontrols.stop();
            Properties.Settings.Default.RamdonVideo = value;
            Properties.Settings.Default.Save();
            Bienvenida form2 = new Bienvenida();
            TimeOpen.Enabled = false;
            this.Hide();
            form2.Show();
        }

    }
}
