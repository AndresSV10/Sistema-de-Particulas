using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemadeParticulas
{
    public partial class Form1 : Form
    {
        private List<Particle> particles = new List<Particle>();
        List<Particle> sparks = new List<Particle>();
        
        Bitmap bmp;
        
        public Form1()
        {
            InitializeComponent();
            
            PointF center = new PointF(pictureBox1.Width / 2.0f, pictureBox1.Height / 2.0f);
            
            Random Ran = new Random();
            for (int i = 0; i < 100; i++)
            {
                particles.Add(new Particle
                {
                    Position = new PointF((float)Ran.NextDouble() * pictureBox1.Width, 0),
                    Velocity = new PointF((float)Ran.NextDouble() * 2 - 1, (float)Ran.NextDouble() * 4),
                    color = Color.White
                });
            }
            
            for (int i = 0; i < 50; i++)
            {
                Particle spark = new Particle();
               
                sparks.Add(spark);


            }
            timer1.Start();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random Ran = new Random();
            
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            foreach (Particle particle in particles)
            {
                particle.Position = new PointF(particle.Position.X + particle.Velocity.X, particle.Position.Y + particle.Velocity.Y);
                particle.Velocity = new PointF(particle.Velocity.X + (float)Ran.NextDouble() * 0.2f - 0.1f, particle.Velocity.Y + 0.1f);
                particle.Size = (float)Ran.Next(10, 20);
                particle.Alpha = Ran.Next(50, 256);
                
            }
            
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Black);
                foreach (Particle particle in particles)
                {
                    Color particleColor = Color.FromArgb(particle.Alpha, particle.color.R, particle.color.G, particle.color.B);
                    g.FillEllipse(new SolidBrush(particleColor), particle.Position.X, particle.Position.Y, particle.Size, particle.Size);
                }
            }

            using (Graphics g = Graphics.FromImage(bmp))
            {
                foreach (Particle spark in sparks)
                {
                    spark.Position = new PointF(spark.Position.X + spark.Velocity.X, spark.Position.Y + spark.Velocity.Y);
                    spark.Size = Math.Max(0, spark.Size - 0.05f);
                    spark.Alpha = (int)(spark.Alpha * 0.95);

                    if (spark.Alpha <= 0 || spark.Size <= 0)
                    {
                        spark.Alpha = 0;
                        spark.Size = 0;
                        continue;
                    }
                    g.FillEllipse(new SolidBrush(Color.FromArgb(spark.Alpha, spark.color)), spark.Position.X, spark.Position.Y, spark.Size, spark.Size);
                }
            }
            pictureBox1.Image = bmp;
        }
    }
}
