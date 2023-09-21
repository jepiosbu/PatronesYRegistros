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
using System.Diagnostics.CodeAnalysis;

namespace PlantillaBrasil
{
    public partial class Splahs : Form
    {
        string[] vectorRutasVideo = new string[3];
        int con1;
        int con2;
        int sum;
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
            con1 = Properties.Settings.Default.RamdonVideo1;
            con2 = Properties.Settings.Default.RamdonVideo2;
            Random random = new Random();
            value= random.Next(0, 3);
            while (con1 == value || con2 == value)
            {
                value = random.Next(0, 3);
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
            sum++;
            if (sum == 0)
            {
                Properties.Settings.Default.RamdonVideo1 = value;
                Properties.Settings.Default.Suma = sum;
            }
            if (sum == 1)
            {
                Properties.Settings.Default.RamdonVideo2=value;
                Properties.Settings.Default.Suma = sum;
            }
            if (sum == 2)
            {
                Properties.Settings.Default.RamdonVideo1 = value;
                Properties.Settings.Default.Suma = 0;

            }
            Reproductor.Ctlcontrols.stop();
            Properties.Settings.Default.RamdonVideo1=value;
            Properties.Settings.Default.Save();
            Bienvenida form2 = new Bienvenida();
            TimeOpen.Enabled = false;
            this.Hide();
            form2.Show();
        }

    }
}
