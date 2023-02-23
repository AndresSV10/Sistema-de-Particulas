using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeParticulas
{
    internal class Particle
    {
        public PointF Position { get; set; }
        public PointF Velocity { get; set; }
        public Color color { get; set; }
        public float Size { get; set; }
        public int Alpha { get; set; }
        public ParticleType Type { get; set; }
        public float LifeSpan { get; set; }
    }
    public enum ParticleType
    {
        Fire,
        Spark
    }
}

