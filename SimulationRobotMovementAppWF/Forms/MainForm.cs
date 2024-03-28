using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SimulationRobotMovementAppWF
{
    public partial class MainForm : Form
    {
        // Для перемещения формы
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);


        public MainForm()
        {
            InitializeComponent();
            // Чтобы работал перехват нажатий на клавиатуре
            this.KeyPreview = true;
        }

        // Перемещение формы
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        // Сворачивание окна
        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Закрытия окна
        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // кнопка выхода по середине
        private void buttonQuit2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Кнопка перехода на основное окно
        private void StartAppButton_Click(object sender, EventArgs e)
        {
            // Прячем текущее окно
            this.Hide();
            StartForm startForm = new StartForm();
            // Показываем новую форму
            startForm.Show();
            // Чтобы сразу выполнялся поиск пути
            startForm.pathFindingForm();
        }

        // Кнопка перехода на окно с информацией
        private void InfoButton_Click(object sender, EventArgs e)
        {
            // Прячем текущее окно
            this.Hide();
            Forms.InfoForm infoForm = new Forms.InfoForm();
            // Показываем новую форму
            infoForm.Show();
        }
    }
}
