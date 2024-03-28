using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
//using System.Windows.Media;
//using System.Collections.Generic;

namespace SimulationRobotMovementAppWF
{
    public class Hexagon
    {
        private Rectangle _bounds;
        private GraphicsPath _path;
        
        // private PointF[] _circlePoint;
        // private Point[] _circleCenterPoint;

        private PointF[] _linePoint;
        
        private int _widthRect = 0;
        private int _heightRect = 0;
        private int _offset_x = 0;
        private int _offset_y = 0;
        private Point _location;
        private int _diameter;
        public PictureBox pictureBox;
        public Label _numberLabel;

        // Для цвета шестиугольника
        //private string _colorName;
        private string _colorName;
        private SolidBrush _colorBrush;

        // Пути к иконкам
        private string _roadWhite = @"D:\Users\Alexander\source\repos\SimulationRobotMovementAppWF\SimulationRobotMovementAppWF\res\icon\RoadWhite.png";
        private string _mountainsWhite = @"D:\Users\Alexander\source\repos\SimulationRobotMovementAppWF\SimulationRobotMovementAppWF\res\icon\MountainsWhite.png";
        private string _startFlag = @"D:\Users\Alexander\source\repos\SimulationRobotMovementAppWF\SimulationRobotMovementAppWF\res\icon\FlagStart.png";
        private string _finishFlag = @"D:\Users\Alexander\source\repos\SimulationRobotMovementAppWF\SimulationRobotMovementAppWF\res\icon\FlagFinish.png";


        public Hexagon(Point location, int diameter, int offsetX, int offsetY, int widthRect, int heightRect, string colorName)
        {
            _widthRect = widthRect;
            _heightRect = heightRect;
            _offset_x = offsetX;
            _offset_y = offsetY;
            this._colorName = colorName;
            this.colorHexagon = colorName;
            this._location = location;
            this._diameter = diameter;

            _bounds = new Rectangle(location, new Size(diameter, diameter));
            //Console.WriteLine("_border: {0}", _bounds);

            // Координаты центра
            int center_x = Convert.ToInt32(_bounds.Location.X);
            int center_y = Convert.ToInt32(_bounds.Location.Y);
            // int center_x = Convert.ToInt32(_bounds.Width / 2 + _bounds.Location.X);
            // int center_y = Convert.ToInt32(_bounds.Height / 2 + _bounds.Location.Y);
            //Console.WriteLine("center x: {0}, y: {1}", center_x, center_y);


            // Радиус вписанной окружности
            int inscribed_radius = Convert.ToInt32(diameter / 2);
            // int inscribed_radius = (int)(diameter / 2);

            // Радиус описанной окружности
            int circumscribed_radius = Convert.ToInt32(diameter / 3 * Math.Exp(0.5));
            // int circumscribed_radius = (int)(diameter / 3 * Math.Exp(0.5));

            // Сторона шестиугольника
            int side = circumscribed_radius;

            var r = diameter / 2;

            // Координаты вершин            
            var points = new PointF[6] {
                new PointF(center_x + (side / 2), center_y + inscribed_radius),
                new PointF(center_x + circumscribed_radius, center_y),
                new PointF(center_x + (side / 2), center_y - inscribed_radius),
                new PointF(center_x - (side / 2), center_y - inscribed_radius),
                new PointF(center_x - circumscribed_radius, center_y),
                new PointF(center_x - (side / 2), center_y + inscribed_radius)
            };

            // Для краёв шестиугольника
            var linePoint = new PointF[6];
            for (int i = 0; i < points.Length; i++) 
            {
                linePoint[i] = new PointF(points[i].X, points[i].Y);
            }
            _linePoint = linePoint;

            // Отрисовка точек шестиугольника
            /*
            var circlePoint = new PointF[6];
            _circleCenterPoint = new Point[] { new Point(center_x, center_y) };

            for (int i = 0; i < 6; i++)
            {
                points[i] = new PointF(
                    center_x + r * (float)Math.Cos(i * 60 * Math.PI / 180f),
                    center_y + r * (float)Math.Sin(i * 60 * Math.PI / 180f));
            }*/

            _path = new GraphicsPath();
            _path.AddPolygon(points);

            // Создание и скрытие иконки 
            //generatingImage(location, diameter);
        }

        // Отображение
        public void Draw(Graphics graph)
        {
            // Установка цвета
            // SolidBrush solidBrush = new SolidBrush(System.Drawing.Color.FromArgb(255, 12, 163, 233));
            // Отрисовка шестиугольника, зарание определённого цвета
            graph.FillPath(_colorBrush, _path);

            // Отрисовка боковой линии
            drawingSideLines(graph);

            // Отрисовка боковой линии поля
            /*
            Pen whitePen = new Pen(Color.White, 1);
            //Random rand = new Random();
            //int sizeW = rand.Next(50, 200);
            //int sizeH = rand.Next(50, 100);
            Rectangle rect = new Rectangle(_offset_x, _offset_y, _widthRect, _heightRect);
            graph.DrawRectangle(whitePen, rect);
            */

            // Отрисовка точек шестиугольника
            /*
            SolidBrush circleBrush = new SolidBrush(System.Drawing.Color.FromArgb(255, 255, 255, 233));
            for (int i = 0; i < _circlePoint.Length; i++)
            {
                graph.FillEllipse(circleBrush, _circlePoint[i].X - 5, _circlePoint[i].Y - 5, 10, 10);
            }
            graph.FillEllipse(circleBrush, _circleCenterPoint[0].X - 5, _circleCenterPoint[0].Y - 5, 10, 10);
            //graph.FillEllipse(circleBrush, 0, 35, 10, 10);
            */
        }

        // Изменение цвета
        public void colorChange(Graphics graph)
        {
            // Отрисовка шестиугольника
            graph.FillPath(_colorBrush, _path);
            drawingSideLines(graph);
        }

        // Отрисовка боковых линий у шестиугольника
        private void drawingSideLines(Graphics graph)
        {
            Pen redPen = new Pen(System.Drawing.Color.FromArgb(255, 249, 57, 67), 5);
            graph.DrawLine(redPen, _linePoint[0], _linePoint[1]);
            graph.DrawLine(redPen, _linePoint[1], _linePoint[2]);
            graph.DrawLine(redPen, _linePoint[2], _linePoint[3]);
            graph.DrawLine(redPen, _linePoint[3], _linePoint[4]);
            graph.DrawLine(redPen, _linePoint[4], _linePoint[5]);
            graph.DrawLine(redPen, _linePoint[5], _linePoint[0]);
        }

        // Отрисовка точки в центре
        public void circleDraw(Graphics graph, Point point, SolidBrush circleBrush)
        {
            //SolidBrush circleBrush = new SolidBrush(System.Drawing.Color.FromArgb(255, 255, 255, 233));
            //SolidBrush circleBrush = new SolidBrush(Color.Aqua);
            int size = _diameter / 4;
            graph.FillEllipse(circleBrush, point.X - size / 2, point.Y - size / 2, size, size);
        }

        // Создание иконки у объекта
        public PictureBox createImage()
        {
            pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            //Console.WriteLine("createImage color Name: {0}", _colorName);
            if (_colorName == "road")
            {
                pictureBox.Image = Image.FromFile(_roadWhite);
                pictureBox.BackColor = Color.FromArgb(255, 12, 163, 233);
            }
            else if (_colorName == "mountain")
            {
                pictureBox.Image = Image.FromFile(_mountainsWhite);
                pictureBox.BackColor = Color.FromArgb(255, 252, 230, 170);
            }
            else if (_colorName == "start")
            {
                pictureBox.Image = Image.FromFile(_startFlag);
            }
            else if (_colorName == "finish")
            {
                pictureBox.Image = Image.FromFile(_finishFlag);
            }
            pictureBox.Size = new Size(this._diameter / 2 + 5, this._diameter / 2 + 5);
            pictureBox.Location = new Point(this._location.X - pictureBox.Size.Width / 2, this._location.Y - pictureBox.Size.Height / 2);

            return pictureBox;
        }

        // Удалить иконку
        public void deleteImage()
        {
            this.pictureBox.Image = null;
        }

        // Метод для вывода номера объекта
        public Label createLabelNumber(string numberText, Point point)
        {
            _numberLabel = new Label();
            //_numberLabel.Font = new Font("Nautilus Pompilius", 9);
            _numberLabel.Text = numberText;
            _numberLabel.TextAlign = ContentAlignment.MiddleCenter;
            _numberLabel.Size = new Size(this._diameter / 2 + 5, this._diameter / 2 + 5);
            _numberLabel.Location = new Point(this._location.X - _numberLabel.Size.Width / 2, this._location.Y - _numberLabel.Size.Height / 2);
            if (this.colorHexagon == "road")
            {
                _numberLabel.ForeColor = Color.White;
                _numberLabel.BackColor = Color.FromArgb(255, 12, 163, 233);
            }
            if (this.colorHexagon == "mountain")
            {
                _numberLabel.ForeColor = Color.FromArgb(255, 255, 150, 1);
                _numberLabel.BackColor = Color.FromArgb(255, 252, 230, 170);
            }
            switch (_diameter)
            {
                case 50:
                    _numberLabel.Font = new Font("Nautilus Pompilius", 9);
                    break;
                case 60:
                    _numberLabel.Font = new Font("Nautilus Pompilius", 12);
                    break;
                case 70:
                    _numberLabel.Font = new Font("Nautilus Pompilius", 14);
                    break;
                case 80:
                    _numberLabel.Font = new Font("Nautilus Pompilius", 16);
                    break;
                case 90:
                    _numberLabel.Font = new Font("Nautilus Pompilius", 18);
                    break;
                case 100:
                    _numberLabel.Font = new Font("Nautilus Pompilius", 20);
                    break;
            }
            return _numberLabel;
        }


        // Удалить номер объекта
        public Label getLabelNumber()
        {
            return _numberLabel;
        }

        // Определение над этим ли объектом курсор
        public bool HitTest(Point p)
        {
            return _path.IsVisible(p);
        }

        // Цвета объекта
        public string colorHexagon
        {
            get    
            {
                return _colorName;
            }
            set 
            {
                if (value == "road") 
                {
                    _colorName = "road";
                    _colorBrush = new SolidBrush(System.Drawing.Color.FromArgb(255, 12, 163, 233)); 
                }
                if (value == "mountain") 
                {
                    _colorName = "mountain";
                    _colorBrush = new SolidBrush(System.Drawing.Color.FromArgb(255, 252, 230, 170));  
                }
                if (value == "start")
                {
                    _colorName = "start";
                }
                if (value == "finish")
                {
                    _colorName = "finish";
                }
            }
        }

        // Координаты объекта
        public Point getPoint()
        {
            return _location;
        }


        /*

        public Rectangle Bounds { get { return _bounds; } }
        public Point Location
        {
            get { return _bounds.Location; }
            set { _bounds.Location = value; }
        }
        */
    }
}
