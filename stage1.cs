using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Novels_Narkomans
{
    public partial class stage1 : Form
    {
        // Список текстов для отображения
        private List<string> texts = new List<string>
        {
            "Текст 1: Привет, мир!",
            "Текст 2: Это пример текста.",
            "Текст 3: Нажмите кнопку, чтобы продолжить."
        };

        // Список изображений для отображения
        private List<Image> images = new List<Image>
        {
            Properties.Resources.image1, // Замените на ваши изображения
            Properties.Resources.image2,
            Properties.Resources.image3
        };

        private int currentIndex = 0; // Текущий индекс для текста и изображений

        public stage1()
        {
            InitializeComponent();

            // Инициализация элементов управления
            label2.Text = texts[currentIndex];
            picture_artem.Image = images[currentIndex];
        }

        private void Stage1_Load(object sender, EventArgs e)
        {
            ApplyDisplayMode();
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Переключение на следующий текст и изображение
            currentIndex++;
            if (currentIndex >= texts.Count)
            {
                currentIndex = 0; // Возвращаемся к началу, если достигли конца
            }

            // Обновляем текст и изображение
            label2.Text = texts[currentIndex];
            pictureBox1.Image = images[currentIndex];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Save
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home
        }
    }   
}
