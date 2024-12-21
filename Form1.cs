using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace Novels_Narkomans
{ 
    [DesignerCategory("Form")]
    
    public partial class Form1 : Form
    {
        private SettingsForm _settingsForm;

        public static class MusicPlayer
        {

            private static SoundPlayer _player;

            public static void Play(string filePath)
            {
                if (_player == null)
                {
                    _player = new SoundPlayer(filePath);
                }

                _player.PlayLooping();
            }

            public static void Stop()
            {
                _player?.Stop();
            }

            public static void Dispose()
            {
                _player?.Dispose();
                _player = null;
            }
        }

        public Form1()
        {
            InitializeComponent();
            try
            {
                // Указываем путь к музыке
                string musicPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "res", "mus1.wav");

                if (!File.Exists(musicPath))
                {
                    throw new FileNotFoundException("Файл музыки не найден", musicPath);
                }

                // Устанавливаем фоновое изображение
                string backgroundImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "res", "main_pic1.jpg");
                if (File.Exists(backgroundImagePath))
                {
                    this.BackgroundImage = Image.FromFile(backgroundImagePath);
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                }

                // Воспроизводим музыку, если она включена
                if (SettingsForm.Settings.IsMusicEnabled)
                {
                    MusicPlayer.Play(musicPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки музыки: {ex.Message}", "Ошибка");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_settingsForm == null || _settingsForm.IsDisposed)
            {
                _settingsForm = new SettingsForm();
                _settingsForm.MusicStateChanged += OnMusicStateChanged;
                _settingsForm.DisplayModeChanged += ApplyDisplayMode;
            }

            _settingsForm.Size = new Size(800, 800);
            _settingsForm.WindowState = FormWindowState.Normal;
            _settingsForm.StartPosition = FormStartPosition.CenterScreen;
            _settingsForm.Show();
        }

        private void OnMusicStateChanged(bool isMusicEnabled)
        {
            if (isMusicEnabled)
            {
                string musicPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "res", "mus1.wav");
                MusicPlayer.Play(musicPath);
            }
            else
            {
                MusicPlayer.Stop();
            }
        }

        private void ApplyDisplayMode()
        {
            if (SettingsForm.Settings.IsFullScreen)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else if (SettingsForm.Settings.IsBorderless)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(800, 600);
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось открыть ссылку: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Disclaimer disclaimerForm = new Disclaimer
            {
                Size = new Size(800, 800),
                WindowState = FormWindowState.Normal,
                StartPosition = FormStartPosition.CenterScreen
            };
            disclaimerForm.Show();
            this.Hide();

        }
        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ApplyDisplayMode();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MusicPlayer.Dispose(); // Освобождаем ресурсы музыки при закрытии формы

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Saves saveStagesForm = new Saves();
            saveStagesForm.Show();
        }
    }
}
