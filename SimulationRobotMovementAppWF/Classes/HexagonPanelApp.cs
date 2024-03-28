using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SimulationRobotMovementAppWF.Classes
{
    public partial class HexagonPanelApp : UserControl
    {
        // Массив шестиугольников
        private List<Hexagon> hexagons;
        private List<Hexagon> cloneHexagons;
        //int panelWidth = 1479;
        //int panelHeight = 784;
        int panelWidth = 1109;
        int panelHeight = 637;

        // Хранение графического объекта для отрисовки
        private Graphics _graphics;

        // Для случайного заполения
        private Random _random = new Random();

        // Статус рисования (изменения) поля с шестиугольниками
        public bool statusEditingMap = false;

        // Статус зажатия ЛКМ
        private bool _clamping = false;

        // Кол-во строк и колонок
        private int _rowsCount = 0;
        private int _colsCount = 0;

        // Нужно ли перерисовывать путь
        private bool _pathPrint = false;

        // Список для пути на графе
        private List<int> _pathGraph = new List<int>();

        // Номер пересекающейся вершины
        private int _intersectNode = -1;

        public HexagonPanelApp()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.Selectable, true);
            hexagons = new List<Hexagon>();

            /*
            int diameter = 70;
            int rows = 10;
            int cols = 20;

            int offset_x = 0;
            int offset_y = 0;
            int widthRect = 0;
            int heightRect = 0;
            (widthRect, heightRect, offset_x, offset_y) = offsetHexagon(rows, cols, diameter);

            changingMap(rows, cols, offset_x, offset_y, diameter, widthRect, heightRect);
            */
        }

        // Метод общий для вызова функций изменения карты
        public void Changing(int diameter, int rows, int cols, bool randFill = false)
        {
            _rowsCount = rows;
            _colsCount = cols;

            this.removeFlag("start");
            this.removeFlag("finish");
            clearPanel();

            int offset_x = 0;
            int offset_y = 0;
            int widthRect = 0;
            int heightRect = 0;
            (widthRect, heightRect, offset_x, offset_y) = offsetHexagon(rows, cols, diameter);

            changingMap(rows, cols, offset_x, offset_y, diameter, widthRect, heightRect);

            _graphics = Graphics.FromHwnd(this.Handle);
            foreach (var hexagon in hexagons)
            {
                string cloneColor = "null";
                if (cloneHexagons.Count != 0 && hexagons.IndexOf(hexagon) < cloneHexagons.Count)
                {
                    cloneColor = cloneHexagons[hexagons.IndexOf(hexagon)].colorHexagon;
                }

                // Если активирован режим случайного заполнения карты
                string colorName;
                if (randFill)
                {
                    int number = GetRandomNumber();
                    colorName = number == 0 ? "road" : "mountain";
                }
                // Иначе производим сравнение с предыдущей картой
                else
                {
                    colorName = cloneColor != "null" ? cloneColor : "road";
                }

                hexagon.colorHexagon = colorName;
                hexagon.Draw(_graphics);
            }
            generatingImage();
        }

        // Изменение карты
        private void changingMap(int rows, int cols, int offsetX, int offsetY, int diameter, int widthRect, int heightRect)
        {
            // Предыдущие координаты
            int last_x = 0;
            int last_y = 0;

            int x = 0;
            int y = 0;

            for (int row = 0; row < rows; row++)
            {
                //last_y = (diameter + 5) * row;
                last_y = diameter * row;
                for (int col = 0; col < cols; col++)
                {
                    if (col == 0)
                    {
                        x = offsetX + last_x + (int)(diameter / Math.Pow(3, 0.5));
                        y = offsetY + last_y + (int)(diameter / 2);
                    }
                    // Если не чётное
                    else if (col % 2 != 0)
                    {
                        x = last_x + (int)(Math.Sqrt(3) * diameter / 2);
                        y = last_y + (int)(diameter / 2);
                    }
                    // Если чётное
                    else if (col % 2 == 0)
                    {
                        x = last_x + (int)(Math.Sqrt(3) * diameter / 2);
                        y = last_y - (int)(diameter / 2);
                    }

                    //Console.WriteLine("rows: {0}, cols: {1}, x: {2}, y: {3}", row, col, x, y);
                    // Проверка на выход из зоны видимости
                    if (x > panelWidth - (int)(Math.Sqrt(3) * diameter / 2) || y > panelHeight - (int)(diameter / 2) || x - (int)(Math.Sqrt(3) * diameter / 2) < 0 || y - (int)(diameter / 2) < 0)
                    {
                        //Console.WriteLine("x: {0}, y: {1}", x, y);
                        continue;
                    }
                    /*
                    if (panelWidth > 0 && panelHeight > 0)
                    {
                        if (((x + diameter / 2) > panelWidth) || ((y + diameter / 2) > panelHeight))
                            continue;
                    }*/

                    last_x = x;
                    last_y = y;
                    //Console.WriteLine("x: {0}, y:{1}", x, y);
                    hexagons.Add(new Hexagon(new Point(x, y), diameter, offsetX, offsetY, widthRect, heightRect, "road"));
                }
                x = 0;
                y = 0;
                last_x = 0;
                last_y = 0;
            }
        }

        // Генирация случайного числа из диапазона
        private int GetRandomNumber()
        {
            // Генирируем псевдослучайное число от 0.0 до 1.0, переводим от 0 до 9 и в зависимости от этого выдаём 0 или 1
            double numberDoble = _random.NextDouble();
            int number = (int)(numberDoble * 10);
            int result = number <= 6 ? 0 : 1;
            // Console.WriteLine("Number {0}; Res: {1}", number, result);
            return result;
        }

        // Чистим поле
        public void clearPanel()
        {
            cloneHexagons = new List<Hexagon>(hexagons);
            clearImage();
            hexagons.Clear();
            _graphics = Graphics.FromHwnd(this.Handle);
            _graphics.Clear(Color.FromArgb(41, 45, 75));
        }

        // Отрисовка this элемента
        protected override void OnPaint(PaintEventArgs e)
        {
            _graphics = e.Graphics;
            //_graphics = Graphics.FromHwnd(this.Handle);

            base.OnPaint(e);
            foreach (var hexagon in hexagons)
            {
                hexagon.Draw(e.Graphics);
            }

            // Чтобы путь оставался при перерисовки, если он был
            if (_pathGraph.Count > 0 && _pathPrint)
            {
                paintPathHexagons(e.Graphics);
            }
        }

        // Расчёт смещения шестиугольников
        public (int widthRect, int heightRect, int offsetX, int offsetY) offsetHexagon(int rows, int cols, int diameter)
        {
            int offset_x = 0;
            int offset_y = 0;

            //Console.WriteLine("Половина от высоты шестиугольника: {0}", (int)(Math.Sqrt(3) * (diameter / 2)) / 2);
            int size = (int)(diameter / 2);
            //int widthRect = (int)(diameter + 3/2 * size * (cols - 1));
            //int heightRect = (int)(Math.Sqrt(3) * size / 2 + rows * Math.Sqrt(3) * size);
            // Расчёт размеров прямоугольной области с шестиугольниками
            int widthRect = (int)(diameter / Math.Pow(3, 0.5)) * 2 + (int)(Math.Sqrt(3) * diameter / 2) * (cols - 1);
            int heightRect = diameter * rows + diameter / 2;

            // Console.WriteLine("widthRect: {0}, heightRect: {1}", widthRect, heightRect);

            // Координаты центра панели
            int center_x_panel = 0;
            int center_y_panel = 0;
            center_x_panel = panelWidth / 2;
            center_y_panel = panelHeight / 2;

            // Координаты центра прямоугольника с шестиугольниками
            int center_x_rect = widthRect / 2;
            int center_y_rect = heightRect / 2;

            // Console.WriteLine("center_x_panel: {0}, center_y_panel: {1}", center_x_panel, center_y_panel);
            // Console.WriteLine("center_x_rect: {0}, center_y_rect: {1}", center_x_rect, center_y_rect);

            // Смещение
            offset_x = center_x_panel - center_x_rect;
            offset_y = center_y_panel - center_y_rect;

            return (widthRect, heightRect, offset_x, offset_y);
        }

        // Клик на шестиугольник
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            // Если включён рещим редактирования
            if (statusEditingMap)
            {
                foreach (var hexagon in hexagons)
                {
                    if (hexagon.HitTest(e.Location))
                    {
                        //MessageBox.Show(hexagons.IndexOf(hexagon).ToString());
                        //Console.WriteLine("Color Hexagon: {0}", hexagon.colorHexagon);
                        if (hexagon.colorHexagon == "road")
                            hexagon.colorHexagon = "mountain";
                        else
                            hexagon.colorHexagon = "road";

                        _graphics = Graphics.FromHwnd(this.Handle);
                        hexagon.colorChange(_graphics);

                        recreationImage(hexagon);
                        break;
                    }
                }
            }
        }

        // Перемещение с зажатой ЛКМ
        int oldIndex = 0;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            // Если включён рещим редактирования
            if (statusEditingMap)
            {
                if (e.Button == MouseButtons.Left)
                {
                    _clamping = true;
                    //Console.WriteLine("Location: {0}", e.Location);
                    foreach (var hexagon in hexagons)
                    {
                        if (oldIndex != hexagons.IndexOf(hexagon))
                        {
                            if (hexagon.HitTest(e.Location))
                            {
                                //MessageBox.Show(hexagons.IndexOf(hexagon).ToString());
                                if (hexagon.colorHexagon == "road")
                                {
                                    hexagon.colorHexagon = "mountain";
                                    oldIndex = hexagons.IndexOf(hexagon);
                                }
                                else
                                {
                                    hexagon.colorHexagon = "road";
                                    oldIndex = hexagons.IndexOf(hexagon);
                                }

                                _graphics = Graphics.FromHwnd(this.Handle);
                                hexagon.colorChange(_graphics);
                                recreationImage(hexagon);
                                break;
                            }
                        }
                    }
                }
            }
        }

        // Отпускание кнопки мыши
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            // Если включён рещим редактирования
            if (statusEditingMap && _clamping)
            {
                foreach (var hexagon in hexagons)
                {
                    if (hexagon.HitTest(e.Location))
                    {
                        if (hexagon.colorHexagon == "road")
                            hexagon.colorHexagon = "mountain";
                        else
                            hexagon.colorHexagon = "road";

                        _graphics = Graphics.FromHwnd(this.Handle);
                        hexagon.colorChange(_graphics);
                        recreationImage(hexagon);
                        break;
                    }
                }
                _clamping = false;
            }

        }

        // Установка изображений карты проходимости
        public void generatingImage()
        {
            if (statusEditingMap)
            {
                /*
                PictureBox pictureBox2 = new PictureBox();
                pictureBox2.Image = Image.FromFile(@"D:\Users\Alexander\source\repos\SimulationRobotMovementAppWF\SimulationRobotMovementAppWF\res\icon\RoadWhite.png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.Size = new Size(50, 50);
                //pictureBox2.Location = new Point(10, 10);
                pictureBox2.BackColor = System.Drawing.Color.FromArgb(255, 12, 163, 233);
                Point location = hexagons[0].getPoint();
                int x = location.X - pictureBox2.Size.Width / 2;
                int y = location.Y - pictureBox2.Size.Height / 2;
                pictureBox2.Location = new Point(x, y);

                this.Controls.Add(pictureBox2);
                */
                /*
                PictureBox pictureBox3 = hexagons[1].createImage();
                this.Controls.Add(pictureBox3);
                */

                foreach (var hexagon in hexagons)
                {
                    PictureBox pictureBox = hexagon.createImage();
                    //pictureBox.Click += new MouseEventArgs();
                    pictureBox.MouseClick += PictureBox_MouseClick;
                    //pictureBox.MouseMove += PictureBox_MouseMove;
                    //pictureBox.MouseUp += PictureBox_MouseUp;
                    this.Controls.Add(pictureBox);
                }
            }
        }

        // Пересоздание иконки карты местности у 1 объекта
        private void recreationImage(Hexagon hexagon)
        {
            this.Controls.Remove(hexagon.pictureBox);
            hexagon.deleteImage();
            PictureBox pictureBox = hexagon.createImage();
            pictureBox.MouseClick += PictureBox_MouseClick;
            //pictureBox.MouseMove += PictureBox_MouseMove;
            //pictureBox.MouseUp += PictureBox_MouseUp;
            this.Controls.Add(pictureBox);
        }

        // Действия для PictureBox, иконки карты местности
        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            // Ищем выбранный объект
            foreach (Control control in this.Controls)
            {
                if ((sender as Control).Equals(control))
                {
                    // Console.WriteLine("control Location {0}", control.Location);
                    MouseEventArgs me = e as MouseEventArgs;
                    MouseEventArgs newme = new MouseEventArgs(me.Button, me.Clicks, control.Location.X, control.Location.Y, me.Delta);
                    OnMouseClick(newme);
                    break;
                }
            }
        }

        /*
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _clamping = true;
                if (_clamping == true)
                {
                    foreach (Control control in this.Controls)
                    {
                        if ((sender as Control).Equals(control))
                        {
                            MouseEventArgs me = e as MouseEventArgs;
                            MouseEventArgs newme = new MouseEventArgs(me.Button, me.Clicks, control.Location.X, control.Location.Y, me.Delta);
                            OnMouseClick(newme);
                            break;
                        }
                    }
                }
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _clamping = false;
        }
        */

        // Очистка поля от картинок
        public void clearImage()
        {
            foreach (var hexagon in hexagons)
            {
                if (hexagon.pictureBox != null)
                {
                    if (hexagon.colorHexagon == "start" || hexagon.colorHexagon == "finish")
                        continue;
                    this.Controls.Remove(hexagon.pictureBox);
                }

            }
        }

        // Установка флагов
        public int settingFlag(Point pos, string flagName)
        {
            foreach (var hexagon in hexagons)
            {
                // Console.WriteLine("hexagon: {0}", hexagon.HitTest(pos));
                // Проверка входит ли координаты в какой-нибудь шестиугольник
                if (hexagon.HitTest(pos))
                {
                    if (hexagon.colorHexagon == "mountain")
                    {
                        MessageBox.Show("Флаг можно установить только на дорогу!");
                    }
                    else if (hexagon.colorHexagon == "road")
                    {
                        //string backColor = hexagon.colorHexagon;

                        hexagon.colorHexagon = flagName;

                        this.Controls.Remove(hexagon.pictureBox);
                        if (hexagon.pictureBox != null)
                            hexagon.deleteImage();

                        PictureBox pictureBox = hexagon.createImage();
                        pictureBox.BackColor = Color.FromArgb(255, 12, 163, 233);
                        //pictureBox.Click += new MouseEventArgs();
                        pictureBox.MouseClick += PictureBox_MouseClick;
                        //pictureBox.MouseMove += PictureBox_MouseMove;
                        //pictureBox.MouseUp += PictureBox_MouseUp;
                        this.Controls.Add(pictureBox);

                        return hexagons.IndexOf(hexagon);
                    }
                }
            }
            return -1;
        }

        // Убрать с поля флаг
        public void removeFlag(string flagName)
        {
            _pathPrint = false;
            foreach (var hexagon in hexagons)
            {
                if (hexagon.colorHexagon == flagName)
                {
                    hexagon.colorHexagon = "road";
                    _graphics = Graphics.FromHwnd(this.Handle);
                    hexagon.colorChange(_graphics);
                    recreationImage(hexagon);
                }
            }
        }

        // Кол-во элементов на карте
        public int countHex()
        {
            return hexagons.Count;
        }

        // Генирация случайного числа для размещения флага
        public int GetRandomNumberHex(int count)
        {
            int number = 0;
            bool whileStatus = true;
            while (whileStatus)
            {
                number = _random.Next(count);
                // Console.WriteLine("colorHexagon: {0}", hexagons[number].colorHexagon);
                if (hexagons[number].colorHexagon == "road")
                    whileStatus = false;

            }
            return number;
        }

        // Возврат координат центра выбранного элемента массива
        public Point getCenterCoordinates(int hexagonNumber)
        {
            return hexagons[hexagonNumber].getPoint();
        }

        // Возврат значений на которых установлены флаги
        public (int, int) getIndexFlag()
        {
            int startIndex = -1;
            int finishIndex = -1;
            foreach (var hexagon in hexagons)
            {
                if (hexagon.colorHexagon == "start")
                    startIndex = hexagons.IndexOf(hexagon);
                if (hexagon.colorHexagon == "finish")
                    finishIndex = hexagons.IndexOf(hexagon);
            }
            return (startIndex, finishIndex);
        }

        // Метод для поиска пути
        public string pathFinding(int startIndex, int finishIndex)
        {
            // Console.WriteLine("startIndex: {0}, finishIndex: {1}", startIndex, finishIndex);

            // Передать данные классу Graph
            Graph graph = new Graph(hexagons.Count);

            // Создать граф
            creatingGraph(graph);

            // Выполнение поиска
            if (graph.BiDirSearch(startIndex, finishIndex) == -1)
            {
                _pathPrint = false;
                MessageBox.Show("Путь между " + startIndex.ToString() + " и " + finishIndex.ToString() + " \nшестиогольниками не существует");
                return "Путь между " + startIndex.ToString() + " и " + finishIndex.ToString() + " не существует";
            }
            else
            {
                _pathGraph = graph.getPath();
                _pathPrint = true;
                _intersectNode = graph.intersectNode;
                paintPathHexagons(Graphics.FromHwnd(this.Handle));
                return "Путь между " + startIndex.ToString() + " и " + finishIndex.ToString() + " существует";
            }
            /*
            if (graph.BiDirSearch(startIndex, finishIndex) == -1)
            {
                Console.WriteLine("Путь не существует между {0} и {1}", startIndex, finishIndex);
                return "Путь не существует между " + startIndex.ToString() + " и " + finishIndex.ToString();
                //MessageBox.Show("Путь не существует между "+ startIndex.ToString() + " и " + finishIndex.ToString() + " ");
            }
            */
        }

        // Метод для проверки установлены ли флаги на карте
        private bool chechingFlags()
        {
            bool chechFlags = false;
            bool startFlag = false;
            bool finishFlag = false;
            foreach (var hexagon in hexagons)
            {
                if (hexagon.colorHexagon == "start")
                    startFlag = true;
                if (hexagon.colorHexagon == "finish")
                    finishFlag = true;
            }
            if (startFlag == true && finishFlag == true)
                return true;

            return chechFlags;
        }

        // Метод для создания графа
        private void creatingGraph(Graph graph)
        {
            // Предворительный список для заполнения графа
            List<int[]> graphListArr = new List<int[]>();

            int index = -1;
            // Для определения сверху (чётное) шестиугольник или снизу (не чётное)
            int numberStep = 0;
            //bool parityStep = (numberStep % 2 == 0) ? true : false;
            // Обход всего графа с выбором только участка дороги
            for (int i = 0; i < hexagons.Count; i++)
            {
                int hexagonsIndex = hexagons.IndexOf(hexagons[i]);
                // Чётный ли индекс
                bool evenHexagonsIndex = (hexagonsIndex % 2 == 0) ? true : false;
                if (numberStep == _colsCount)
                    numberStep = 0;
                bool parityStep = (numberStep % 2 == 0) ? true : false;
                // Console.WriteLine("numberStep: {0}, parityStep: {1}", numberStep, parityStep);
                for (int step = 0; step <= 5; step++)
                {
                    switch (step)
                    {
                        case 0:
                            // Если чётное
                            if (parityStep)
                            {
                                // Если первый элемент строки
                                if (hexagonsIndex % _colsCount != 0)
                                {
                                    index = hexagonsIndex - _colsCount - 1;
                                    break;
                                }

                            }
                            else
                                index = hexagonsIndex - 1;
                            break;
                        case 1:
                            index = hexagonsIndex - _colsCount;
                            break;
                        case 2:
                            // Ограничение с права
                            if (hexagonsIndex < _colsCount - 1)
                            {
                                // Если чётное
                                if (parityStep)
                                    index = hexagonsIndex - _colsCount + 1;
                                else
                                    index = hexagonsIndex + 1;
                            }
                            break;
                        case 3:
                            // Ограничение с права
                            if (hexagonsIndex < _colsCount - 1)
                            {
                                // Если чётное
                                if (parityStep)
                                    index = hexagonsIndex + 1;
                                else
                                    index = hexagonsIndex + _colsCount + 1;
                            }
                            break;
                        case 4:
                            index = hexagonsIndex + _colsCount;
                            break;
                        case 5:
                            // Если чётное
                            if (parityStep)
                            {
                                // Если первый элемент строки
                                if (hexagonsIndex % _colsCount != 0)
                                {
                                    index = hexagonsIndex - 1;
                                    break;
                                }
                            }
                            else
                                index = hexagonsIndex + _colsCount - 1;
                            break;
                    }
                    // Ограничение сверху и снизу
                    if (index >= 0 && index < hexagons.Count)
                    {
                        if (hexagons[i].colorHexagon == "road" || hexagons[i].colorHexagon == "start" || hexagons[i].colorHexagon == "finish")
                        {
                            if (hexagons[index].colorHexagon != "mountain")
                            {
                                if (checkingNumbers(graphListArr, hexagonsIndex, index))
                                {
                                    // Console.WriteLine("hexagonsIndex: {0}, index: {1}", hexagonsIndex, index);
                                    graphListArr.Add(new[] { hexagonsIndex, index });
                                }
                                //graphListArr.Add(new[] { hexagonsIndex, index });
                                //graph.AddEdge(hexagonsIndex, index);
                            }
                        }
                    }
                    index = -1;
                }
                numberStep++;
            }

            // Добавления графа
            for (int i = 0; i < graphListArr.Count; i++)
            {
                //Console.WriteLine("AddEdge ({0}, {1})", graphListArr[i][0], graphListArr[i][1]);
                graph.AddEdge(graphListArr[i][0], graphListArr[i][1]);
            }
        }

        // Проверка есть ли данные числа в массиве
        private bool checkingNumbers(List<int[]> listNumber, int firstNumber, int secondNumber)
        {
            for (int i = 0; i < listNumber.Count; i++)
            {
                //Console.WriteLine("listNumber 0: {0} = {1}, listNumber 1: {2} = {3}", listNumber[i][0], secondNumber, listNumber[i][1], firstNumber);
                if (listNumber[i][0] == secondNumber && listNumber[i][1] == firstNumber)
                {
                    return false;
                }
            }
            return true;
        }

        // Отрисовка пути
        public void paintPathHexagons(Graphics graph)
        {
            //_graphics = Graphics.FromHwnd(this.Handle);
            _graphics = graph;

            // Цвета общие и центрального
            SolidBrush generalCircle = new SolidBrush(Color.FromArgb(255, 255, 255, 233));
            SolidBrush centerCircle = new SolidBrush(Color.FromArgb(255, 254, 198, 1));

            // Если режим редактирования выкл.
            if (!statusEditingMap)
            {
                // Отрисовка кружков в центре у тех, что есть в пути
                for (int i = 0; i < hexagons.Count; i++)
                {
                    for (int j = 0; j < _pathGraph.Count; j++)
                    {
                        if (hexagons.IndexOf(hexagons[i]) == _pathGraph[j])
                        {
                            Point point = hexagons[i].getPoint();

                            if (hexagons.IndexOf(hexagons[i]) == _intersectNode)
                                hexagons[i].circleDraw(_graphics, point, centerCircle);
                            else
                                hexagons[i].circleDraw(_graphics, point, generalCircle);
                        }
                    }
                }
            }
        }

        // Для первого срабатывания
        private int _countClick = 0;

        // Установка label цифр
        public void createHexagonsLabel()
        {
            _countClick++;
            if (_countClick == 1)
            {
                for (int i = 0; i < hexagons.Count; i++)
                {
                    if (hexagons[i].colorHexagon == "start" || hexagons[i].colorHexagon == "finish")
                        continue;
                    Point point = hexagons[i].getPoint();
                    Label numberLabel = hexagons[i].createLabelNumber(i.ToString(), point);
                    Controls.Add(numberLabel);
                }
            }
        }

        // Удаление label цифр
        public void deleteHexagonsLabel()
        {
            _countClick = 0;
            foreach (var hexagon in hexagons)
            {
                Controls.Remove(hexagon.getLabelNumber());
            }
        }

        // Установка размеров
        public void setPanelWidth(int width)
        {
            panelWidth = width;
        }
        public void setPanelHeight(int height)
        {
            panelHeight = height;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // HexagonPanelApp
            // 
            this.Name = "HexagonPanelApp";
            this.ResumeLayout(false);

        }
    }
}
