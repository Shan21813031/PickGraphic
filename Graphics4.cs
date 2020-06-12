using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pick_a_Graphic
{
    /// <summary>
    /// Unit 6 Task 6.4
    /// Author: Shan Ahmed 21813031
    ///
    /// This application produces a number of different types of 
    /// graphical shapes on the keyboard input of the user (L, R, E, S, C, M)
    /// </summary>
    public partial class Graphics4 : Form
    {
        private int x, y, size;
        private Random generator = new Random();
        public const int MAXCOLOUR = 256;
        private graphic typeOfGraphic = graphic.FIGURE;

        /// <summary>
        /// Empty slots for graphic
        /// </summary>
        public enum graphic
        {
            LINE,
            RECTANGLE,
            SQUARE,
            CIRCLE,
            ELLIPSE,
            FIGURE,
        }

        public Graphics4()
        {
            InitializeComponent();
        }
        private Point randomPoint()
        {
            x = generator.Next(Width);
            y = generator.Next(Height);
            Point point = new Point(x, y);
            return point;
        }

        /// <summary>
        /// generates random number for each R G B value 
        /// within 256 bits
        /// </summary>
        /// <returns></returns>

        private Color randomColor()
        {
            int r, g, b;
            r = generator.Next(MAXCOLOUR);
            g = generator.Next(MAXCOLOUR);
            b = generator.Next(MAXCOLOUR);

            return Color.FromArgb(r, g, b);

        }

        private void Graphics4_Load(object sender, EventArgs e)
        {
            x = 20;
            y = 100;
            size = 30;
        }

        /// <summary>
        /// the below draws the image out depending on which
        /// type of graphic is called and assigns a random x and y value to a point
        /// </summary>

        public void Graphics4_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Point p1 = randomPoint();
            Color color = randomColor();
            Pen myPen = new Pen(color, 10);
            if (typeOfGraphic == graphic.LINE)
            {
                Point p2 = randomPoint();
                g.DrawLine(myPen, p1.X, p1.Y, p2.X, p2.Y);
            }
            if(typeOfGraphic == graphic.CIRCLE)
            {
                g.DrawEllipse(myPen, p1.X, p1.Y, size, size);
            }
            if(typeOfGraphic == graphic.RECTANGLE)
            {
                g.DrawRectangle(myPen, p1.X, p1.Y, 2 * size, size);
            }
            if(typeOfGraphic == graphic.ELLIPSE)
            {
                g.DrawEllipse(myPen, p1.X, p1.Y, 3 * size, size);
            }
            if(typeOfGraphic == graphic.SQUARE)
            {
                g.DrawRectangle(myPen, p1.X, p1.Y, 200, 200);
            }
            if (typeOfGraphic == graphic.FIGURE)
            {
                g.DrawEllipse(myPen, 400, 100, 60, 60); 
                g.DrawLine(myPen, 430, 160, 430, 300);  
                g.DrawLine(myPen, 330, 200, 530, 200); 
                g.DrawLine(myPen, 430, 300, 330, 400);  
                g.DrawLine(myPen, 430, 300, 530, 400);  
            }
        }
        /// <summary>
        /// below allows user input to be read
        /// and input is stored into key
        /// </summary>

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            string key = keyData.ToString();
            drawShape(key);
            return false;
        }

        /// <summary>
        /// Calls a type of graphic depending on which 
        /// key user inputs
        /// </summary>
     
        private void drawShape(string key)
        {
            if (key == "L")
            {
                typeOfGraphic = graphic.LINE;
            }
            if (key == "R")
            {
                typeOfGraphic = graphic.RECTANGLE;
            }
            if (key == "E")
            {
                typeOfGraphic = graphic.ELLIPSE;
            }
            if (key == "C")
            {
                typeOfGraphic = graphic.CIRCLE;
            }
            if (key == "S")
            {
                typeOfGraphic = graphic.SQUARE;
            }
            if (key == "M")
            {
                typeOfGraphic = graphic.FIGURE;
            }
            Refresh();
        }
    }
}

