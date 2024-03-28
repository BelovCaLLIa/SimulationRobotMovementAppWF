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

    public partial class StartForm : Form
    {
        // Для перемещения формы
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private int _diameter = 70;
        private int _rows = 1;
        private int _cols = 1;

        // Показывает состояние преремещения
        private bool _statusMovements = false;

        // Start & Finish panel
        private string _startFlag = @"D:\Users\Alexander\source\repos\SimulationRobotMovementAppWF\SimulationRobotMovementAppWF\res\icon\FlagStart.png";
        private string _finishFlag = @"D:\Users\Alexander\source\repos\SimulationRobotMovementAppWF\SimulationRobotMovementAppWF\res\icon\FlagFinish.png";
        public PictureBox pictureBoxStartFlag;
        public PictureBox pictureBoxFinishFlag;
        private bool statusStartPanel = false;
        private bool statusFinishPanel = false;

        // Стартовая и финишная позиция для поиска пути
        private int _startIndex = -1;
        private int _finishIndex = -1;

        public StartForm()
        {
            InitializeComponent();
            // Чтобы работал перехват нажатий на клавиатуре
            this.KeyPreview = true;

            // Установка параметров размера поля с шестиугольниками
            int hexPanAppWidth = hexagonPanelApp1.Size.Width;
            int hexPanAppHeight = hexagonPanelApp1.Size.Height;
            hexagonPanelApp1.setPanelWidth(hexPanAppWidth);
            hexagonPanelApp1.setPanelHeight(hexPanAppHeight);
            // Console.WriteLine("hexPanAppWidth: {0}, hexPanAppHeight: {1}", hexPanAppWidth, hexPanAppHeight);

            //Settings();
            visible_object(false);
            trackBarSettings();

            // Создание флагов в случайных местах
            int countHex = hexagonPanelApp1.countHex();
            // Старта
            int randHexStart = hexagonPanelApp1.GetRandomNumberHex(countHex);
            Point pointStart = hexagonPanelApp1.getCenterCoordinates(randHexStart);
            _startIndex = hexagonPanelApp1.settingFlag(pointStart, "start");
            // Финиша
            int randHexFinish = hexagonPanelApp1.GetRandomNumberHex(countHex);
            Point pointFinish = hexagonPanelApp1.getCenterCoordinates(randHexFinish);
            _finishIndex = hexagonPanelApp1.settingFlag(pointFinish, "finish");


            pictureBoxStartFlag = new PictureBox();
            pictureBoxStartFlag.BackColor = Color.Transparent;
            this.Controls.Add(pictureBoxStartFlag);
            
            pictureBoxFinishFlag = new PictureBox();
            pictureBoxFinishFlag.BackColor = Color.Transparent;
            this.Controls.Add(pictureBoxFinishFlag);
        }

        // Настройка
        /*
        private void Settings()
        {
            
        }
        */

        // Метод для выполнения поиска пути
        public void pathFindingForm()
        {
            string textPathFinding = "";
            // Вызов метода поиска пути
            if (_startIndex != -1 && _finishIndex != -1)
            {
                textPathFinding = hexagonPanelApp1.pathFinding(_startIndex, _finishIndex);
            }
            labelPathFinding.Text = textPathFinding;
        }

        // Настройка trackBar-ов
        private void trackBarSettings()
        {
            // Установка нач. значений
            trackBarRows.Value = 8;
            trackBarColums.Value = 17;

            trackBarDiameter.Value = 70;
            labelDiameter.Text = String.Format("Diameter: {0}", trackBarDiameter.Value);

            _rows = (int)trackBarRows.Value;
            _cols = (int)trackBarColums.Value;
            _diameter = (int)trackBarDiameter.Value;

            Changing_TrackBar(_diameter);
            hexagonPanelApp1.Changing(_diameter, _rows, _cols, true);

        }

        // Изменение положения Rows
        private void trackBarRows_Scroll(object sender, EventArgs e)
        {
            labelRows.Text = String.Format("Rows: {0}", trackBarRows.Value);
            _rows = (int)trackBarRows.Value;
            hexagonPanelApp1.Changing(_diameter, _rows, _cols);
        }

        // Изменение положения Cols
        private void trackBarColums_Scroll(object sender, EventArgs e)
        {
            labelCols.Text = String.Format("Cols: {0}", trackBarColums.Value);
            _cols = (int)trackBarColums.Value;
            hexagonPanelApp1.Changing(_diameter, _rows, _cols);
        }

        // Изменение положения Diameter
        private void trackBarDiameter_Scroll(object sender, EventArgs e)
        {
            // Для кратного перемещения на 10
            while (trackBarDiameter.Value % 10 != 0) 
            {
                trackBarDiameter.Value++;
            }

            if (trackBarDiameter.Value % 10 == 0) 
            {
                labelDiameter.Text = String.Format("Diameter: {0}", trackBarDiameter.Value);
                _diameter = (int)trackBarDiameter.Value;
                
                Changing_TrackBar(_diameter);

                hexagonPanelApp1.Changing(_diameter, _rows, _cols);
            }
        }

        // Пересоздание trackBar-ов для контроля размера карты
        private void Changing_TrackBar(int diameter) 
        {
            // Выполняется перерисовка trackBar-ов
            switch (diameter)
            {
                case 50:
                    trackBarRows.Minimum = 2;
                    trackBarRows.Maximum = 12;
                    labelRows.Text = String.Format("Rows: {0}", trackBarRows.Value);
                    _rows = (int)trackBarRows.Value;

                    trackBarColums.Minimum = 2;
                    trackBarColums.Maximum = 24;
                    labelCols.Text = String.Format("Cols: {0}", trackBarColums.Value);
                    _cols = (int)trackBarColums.Value;
                    break;

                case 60:
                    trackBarRows.Minimum = 2;
                    trackBarRows.Maximum = 10;
                    labelRows.Text = String.Format("Rows: {0}", trackBarRows.Value);
                    _rows = (int)trackBarRows.Value;

                    trackBarColums.Minimum = 2;
                    trackBarColums.Maximum = 20;
                    labelCols.Text = String.Format("Cols: {0}", trackBarColums.Value);
                    _cols = (int)trackBarColums.Value;
                    break;

                case 70:
                    trackBarRows.Minimum = 2;
                    trackBarRows.Maximum = 8;
                    labelRows.Text = String.Format("Rows: {0}", trackBarRows.Value);
                    _rows = (int)trackBarRows.Value;

                    trackBarColums.Minimum = 2;
                    trackBarColums.Maximum = 17;
                    labelCols.Text = String.Format("Cols: {0}", trackBarColums.Value);
                    _cols = (int)trackBarColums.Value;
                    break;

                case 80:
                    trackBarRows.Minimum = 2;
                    trackBarRows.Maximum = 7;
                    labelRows.Text = String.Format("Rows: {0}", trackBarRows.Value);
                    _rows = (int)trackBarRows.Value;

                    trackBarColums.Minimum = 2;
                    trackBarColums.Maximum = 15;
                    labelCols.Text = String.Format("Cols: {0}", trackBarColums.Value);
                    _cols = (int)trackBarColums.Value;
                    break;

                case 90:
                    trackBarRows.Minimum = 2;
                    trackBarRows.Maximum = 6;
                    labelRows.Text = String.Format("Rows: {0}", trackBarRows.Value);
                    _rows = (int)trackBarRows.Value;

                    trackBarColums.Minimum = 2;
                    trackBarColums.Maximum = 13;
                    labelCols.Text = String.Format("Cols: {0}", trackBarColums.Value);
                    _cols = (int)trackBarColums.Value;
                    break;

                case 100:
                    trackBarRows.Minimum = 2;
                    trackBarRows.Maximum = 5;
                    labelRows.Text = String.Format("Rows: {0}", trackBarRows.Value);
                    _rows = (int)trackBarRows.Value;

                    trackBarColums.Minimum = 2;
                    trackBarColums.Maximum = 11;
                    labelCols.Text = String.Format("Cols: {0}", trackBarColums.Value);
                    _cols = (int)trackBarColums.Value;
                    break;
                default:
                    break;
            }
        }

        // Возвращение назад к главному меню
        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
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

        // Редактирование карты местности и установка размеров элемента
        private void EditingMapButton_Click(object sender, EventArgs e)
        {
            // Удаление, если есть номеров с ячеек
            hexagonPanelApp1.deleteHexagonsLabel();

            hexagonPanelApp1.statusEditingMap = true;

            labelPathFinding.Visible = false;
            // Видимость
            visible_object(true);

            hexagonPanelApp1.removeFlag("start");
            hexagonPanelApp1.removeFlag("finish");

            _diameter = (int)trackBarDiameter.Value;
            _rows = (int)trackBarRows.Value;
            _cols = (int)trackBarColums.Value;

            hexagonPanelApp1.Changing(_diameter, _rows, _cols);
            //hexagonPanelApp1.generatingImage();
        }
        // Сохранение изменений поля и выход в обычный режим
        private void SaveButton_Click(object sender, EventArgs e)
        {
            hexagonPanelApp1.statusEditingMap = false;
            hexagonPanelApp1.clearImage();

            hexagonPanelApp1.Update();

            // Видимость
            visible_object(false);
            labelPathFinding.Visible = true;

            _startIndex = -1;
            _finishIndex = -1;
            (_startIndex, _finishIndex) = hexagonPanelApp1.getIndexFlag();

            // Вызов метода поиска пути
            pathFindingForm();
        }
        // Клик на очистку карты
        private void labelClear_MouseClick(object sender, MouseEventArgs e)
        {
            hexagonPanelApp1.removeFlag("start");
            hexagonPanelApp1.removeFlag("finish");
            hexagonPanelApp1.clearPanel();
            hexagonPanelApp1.Changing(_diameter, _rows, _cols);
        }

        // Навидение мыши на очистку карты
        private void labelClear_MouseEnter(object sender, EventArgs e)
        {
            labelClear.BackColor = Color.FromArgb(255, 249, 57, 67);
        }
        // Уход с элемента очистки карты
        private void labelClear_MouseLeave(object sender, EventArgs e)
        {
            labelClear.BackColor = Color.FromArgb(255, 12, 163, 233);
        }

        // Случайная карта

        // Клик
        private void labelRandomMap_Click(object sender, EventArgs e)
        {
            hexagonPanelApp1.removeFlag("start");
            hexagonPanelApp1.removeFlag("finish");
            hexagonPanelApp1.clearPanel();
            hexagonPanelApp1.Changing(_diameter, _rows, _cols, true);
        }

        // Навидение
        private void labelRandomMap_MouseEnter(object sender, EventArgs e)
        {
            labelRandomMap.BackColor = Color.FromArgb(255, 124, 8, 213);
        }

        // Уход с элемента
        private void labelRandomMap_MouseLeave(object sender, EventArgs e)
        {
            labelRandomMap.BackColor = Color.FromArgb(255, 12, 163, 233);
        }

        // Перемещения флагов
        // Старт
        // Задержание
        private void buttonStart_MouseDown(object sender, MouseEventArgs e)
        {
            _statusMovements = true;
            pictureBoxStartFlag.Visible = true;

            // Убираем с поля флаг
            hexagonPanelApp1.removeFlag("start");
        }
        // Отпускание
        private void buttonStart_MouseUp(object sender, MouseEventArgs e)
        {
            _statusMovements = false;
            buttonStart.Image = Image.FromFile(_startFlag);

            // Координаты относительно формы
            Point clientPos = PointToClient(Cursor.Position);
            statusStartPanel = getHexagonsPanelUp(clientPos);

            // Координаты относительно hexagonPanel
            Point pointHex = hexagonPanelApp1.PointToClient(Cursor.Position);

            if (statusStartPanel)
            {
                // Вызов функции у hexagonPanelApp1
                hexagonPanelApp1.settingFlag(pointHex, "start");
            }

            // Убираем pictureBox
            pictureBoxStartFlag.Visible = false;
        }
        // Двежение
        private void buttonStart_MouseMove(object sender, MouseEventArgs e)
        {
            if (_statusMovements == true)
            {
                buttonStart.Image = null;
                // Переместить на верхний слой
                pictureBoxStartFlag.BringToFront();
                pictureBoxStartFlag.Image = Image.FromFile(_startFlag);
                pictureBoxStartFlag.BackColor = Color.FromArgb(0, 0, 0, 0);
                pictureBoxStartFlag.Size = new Size(50, 50);
                pictureBoxStartFlag.Location = new Point((Cursor.Position.X - this.Location.X - pictureBoxStartFlag.Size.Width / 2), (Cursor.Position.Y - this.Location.Y - pictureBoxStartFlag.Size.Height / 2));
            }
        }

        // Финиш
        // Задержание
        private void buttonFinish_MouseDown(object sender, MouseEventArgs e)
        {
            _statusMovements = true;
            pictureBoxFinishFlag.Visible = true;

            // Убираем с поля флаг
            hexagonPanelApp1.removeFlag("finish");
        }

        // Отпускание
        private void buttonFinish_MouseUp(object sender, MouseEventArgs e)
        {
            _statusMovements = false;
            buttonFinish.Image = Image.FromFile(_finishFlag);

            // Координаты относительно формы
            Point clientPos = PointToClient(Cursor.Position);
            statusFinishPanel = getHexagonsPanelUp(clientPos);
            
            // Координаты относительно hexagonPanel
            Point pointHex = hexagonPanelApp1.PointToClient(Cursor.Position);

            if (statusFinishPanel)
            {
                // Вызов функции у hexagonPanelApp1
                hexagonPanelApp1.settingFlag(pointHex, "finish");
            }

            // Убираем pictureBox
            pictureBoxFinishFlag.Visible = false;
        }

        // Двежение
        private void buttonFinish_MouseMove(object sender, MouseEventArgs e)
        {
            if (_statusMovements == true)
            {
                buttonFinish.Image = null;
                // Переместить на верхний слой
                pictureBoxFinishFlag.BringToFront();
                pictureBoxFinishFlag.Image = Image.FromFile(_finishFlag);
                pictureBoxFinishFlag.BackColor = Color.Transparent;
                pictureBoxFinishFlag.Size = new Size(50, 50);
                pictureBoxFinishFlag.Location = new Point((Cursor.Position.X - this.Location.X - pictureBoxFinishFlag.Size.Width / 2), (Cursor.Position.Y - this.Location.Y - pictureBoxFinishFlag.Size.Height / 2));
            }
        }

        // Определяет над hexagonsPanel отпущен курсор
        private bool getHexagonsPanelUp(Point clientPos)
        {
            /*
            Console.WriteLine("clientPos Loc: {0}", clientPos);
            Console.WriteLine("hexagonsPanel Loc: {0}", hexagonsPanel.Location);
            Console.WriteLine("hexagonsPanel Size: {0}", hexagonsPanel.Size);
            */

            if (clientPos.X > hexagonsPanel.Location.X && clientPos.Y > hexagonsPanel.Location.Y)
            {
                if (clientPos.X < hexagonsPanel.Location.X + hexagonsPanel.Size.Width && clientPos.Y < hexagonsPanel.Location.Y + hexagonsPanel.Size.Height)
                {
                    /*
                    MessageBox.Show($"pos x: {clientPos.X}, y: {clientPos.Y}\n" +
                        $"Вы отпустили кнопку мыши над элементом: {hexagonPanelApp1.Name}");*/
                    return true;
                }
            }
            return false;

            /* Перебор всех элементов формы
            foreach (Control control in Controls)
            {
                Console.WriteLine("Control: {0}", control.Name);
            }
            */
        }

        // Нажатия кливиш
        private void StartForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                // Метод отрисовки lebel с номерами
                hexagonPanelApp1.createHexagonsLabel();
            }
            if (e.KeyCode == Keys.Escape)
            {
                BackButton_Click(sender, e);
            }
        }

        // Отпускание клавиш
        private void StartForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                hexagonPanelApp1.deleteHexagonsLabel();
            }
        }

        // Функция для видимости объектов при нажатии книпки изменения карты
        private void visible_object(bool modeVisible)
        {
            if (modeVisible)
            {
                trackBarColums.Visible = true;
                trackBarRows.Visible = true;
                trackBarDiameter.Visible = true;
                SaveButton.Visible = true;
                labelRows.Visible = true;
                labelCols.Visible = true;
                labelDiameter.Visible = true;
                labelClear.Visible = true;
                labelRandomMap.Visible = true;
                buttonStart.Visible = true;
                buttonFinish.Visible = true;
                labelStart.Visible = true;
                labelFinish.Visible = true;
            }
            else
            {
                trackBarColums.Visible = false;
                trackBarRows.Visible = false;
                trackBarDiameter.Visible = false;
                SaveButton.Visible = false;
                labelRows.Visible = false;
                labelCols.Visible = false;
                labelDiameter.Visible = false;
                labelClear.Visible= false;
                labelRandomMap.Visible= false;
                buttonStart.Visible = false;
                buttonFinish.Visible = false;
                labelStart.Visible = false;
                labelFinish.Visible = false;
            }
        }
    }
}
