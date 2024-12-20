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
	public partial class Disclaimer : Form
	{
        private Timer timer;
        private Timer timer2;
        public Disclaimer()
		{
			InitializeComponent();
            timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += Timer_Tick;

            timer2 = new Timer();
            timer2.Interval = 10000;
            timer2.Tick += Timer_Tick2;

            timer2.Start();
            timer.Start();

            label1.Text = "Дисклеймер";
            label2.Text = "Данная игра предназначена только для взрослых пользователей в возрасте 18 лет и старше.\r\nОна может содержать сцены насилия, сексуальные элементы, ненормативную лексику и другие материалы,\r\n которые могут быть неподобающими или оскорбительными для некоторых людей.\r\nПрежде чем начать играть, убедитесь, что вы достигли минимального возраста, установленного в вашей стране для доступа к подобному контенту.\r\n В случае сомнений или отсутствия уверенности в том, что игра подходит вам по содержанию, настоятельно\r\n рекомендуем проконсультироваться с законным представителем или родителями.\r\nМы не несем ответственности за любые последствия, связанные с неподобающим использованием игры,\r\n включая, но не ограничиваясь, психологическими или эмоциональными последствиями для пользователей.\r\n\r\nКроме того, мы рекомендуем играть ответственно \r\nи делать перерывы, если вы чувствуете, что игра оказывает негативное воздействие на ваше самочувствие.\r\n\r\n";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            label1.Text = "Предистория";
            label2.Text = "\"Бесконечный срок\" — это не только история о преступности и искуплении, но и о поиске самого себя. В мире, где каждый выбор обостряет реальность, Артем оказывается в ловушке, из которой, кажется, нет выхода. Наркомания, наркотрафик, жестокая борьба за выживание — все это становится фоном для личной драмы героя, который, несмотря на свое прошлое, ищет путь к искуплению. Его жизнь — это бесконечный срок, день за днем, когда решения, принятые раньше, преследуют его, а каждый шаг вперед может стать решающим.\r\n\r\nМир, в который Артем попал, не прощает ошибок. Но может ли человек, окруженный тенью своего прошлого, найти свет, который выведет его из тьмы? Или ему суждено быть частью системы, которая его сломала?";

            timer.Stop();
        }

        private void Timer_Tick2(object sender, EventArgs e)
        { 
            stage1 stage1Form = new stage1();
            stage1Form.Size = new Size(1920, 1080);
            stage1Form.WindowState = FormWindowState.Maximized;
            stage1Form.StartPosition = FormStartPosition.CenterScreen;
            stage1Form.Show();
            this.Hide(); 
            
            timer2.Stop();
        }

        private void Disclaimer_Load(object sender, EventArgs e)
        {

        }
    }
}
