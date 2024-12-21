using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Novels_Narkomans
{
	public partial class SettingsForm : Form
	{
        public event Action<bool> MusicStateChanged;
        public event Action DisplayModeChanged;
        
        public SettingsForm()
		{
			InitializeComponent();
        }

        public static class Settings
        {
            public static int Volume { get; set; } = 50;  // Громкость
            public static bool IsMusicEnabled { get; set; } = true;  // Включена ли музыка
            public static bool IsFullScreen { get; set; } = false; // Фулл Скрин
            public static bool IsBorderless { get; set; } = false; // Store borderless state
        }

        private void label1_Click(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{ 
			this.Hide();
		}

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            trackBar1.Minimum = 0;
            trackBar1.Maximum = 100;
            trackBar1.Value = Settings.Volume;

            checkBox1.Checked = Settings.IsMusicEnabled;

            ApplyDisplayMode();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int m_volume = trackBar1.Value;
            Settings.Volume = m_volume;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Settings.IsMusicEnabled = checkBox1.Checked;
            MusicStateChanged?.Invoke(Settings.IsMusicEnabled);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Saved", "Result");
        }

        private void ApplyDisplayMode()
        {
            if (Settings.IsFullScreen)
            {
                // Set window to fullscreen
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.Bounds = Screen.PrimaryScreen.Bounds;

                Form1 form1 = new Form1
                {
                    FormBorderStyle = FormBorderStyle.None,
                    WindowState = FormWindowState.Maximized,
                    Bounds = Screen.PrimaryScreen.Bounds
                };

                stage1 stage1 = new stage1
                {
                    FormBorderStyle = FormBorderStyle.None,
                    WindowState = FormWindowState.Maximized,
                    Bounds = Screen.PrimaryScreen.Bounds
                };


            }
            else if (Settings.IsBorderless)
            {
                // Set window to borderless mode without fullscreen
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Normal;
                this.Size = new System.Drawing.Size(800, 600); // Set desired size for borderless mode

                Form1 form1 = new Form1();
                form1.FormBorderStyle = FormBorderStyle.None;
                form1.WindowState |= FormWindowState.Normal;
                form1.Size = new System.Drawing.Size(800, 600);

                stage1 stage1 = new stage1();
                stage1.FormBorderStyle = FormBorderStyle.None;
                stage1.WindowState |= FormWindowState.Normal;
                stage1.Size = new System.Drawing.Size(800, 600);
            }
            else
            {
                // Default mode (normal window)
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;

                Form1 form1 = new Form1();
                form1.FormBorderStyle |= FormBorderStyle.Sizable;
                form1.WindowState = FormWindowState.Normal;

                stage1 stage1 = new stage1();
                stage1.FormBorderStyle = FormBorderStyle.Sizable;
                stage1.WindowState = FormWindowState.Normal;
            }
            
            DisplayModeChanged?.Invoke();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: // "Полный экран"
                    Settings.IsFullScreen = true;
                    Settings.IsBorderless = false;
                    break;

                case 1: // "Экран без рамок"
                    Settings.IsFullScreen = false;
                    Settings.IsBorderless = true;
                    break;

                default: // No selection or default mode
                    Settings.IsFullScreen = false;
                    Settings.IsBorderless = false;
                    break;
            }
            this.Hide();
            // Apply the new display mode
            ApplyDisplayMode();
        }
        private readonly SoundPlayer _player;
        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        { 
            _player.Dispose(); // Освобождаем ресурсы
        }
    }
}
