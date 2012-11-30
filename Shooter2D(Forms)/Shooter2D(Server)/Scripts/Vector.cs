using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter2D_Server
{
    public struct Vector
    {
        public double X;
        public double Y;

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Length
        {
            get
            {
                return Math.Sqrt(LengthSquared);
            }
        }

        public double LengthSquared
        {
            get
            {
                return X * X + Y * Y;
            }
        }

        public void Normalize()
        {
            double length = Length;
            X /= length;
            Y /= length;
        }

        public static Vector operator -(Vector vector)
        {
            return new Vector(-vector.X, -vector.Y);
        }

        public static Vector operator *(Vector vector, double scalar)
        {
            return new Vector(scalar * vector.X, scalar * vector.Y);
        }

        public static Vector operator +(Vector point, Vector vector)
        {
            return new Vector(point.X + (int)vector.X, point.Y + (int)vector.Y);
        }

        static public Vector Ponto(int X, int Y)
        {
            return new Vector(X, Y);
        }

        static public Vector CreateVectorFromAngle(double angleInDegrees, double length)
        {
            double x = Math.Sin(DegreesToRadians(180 - angleInDegrees)) * length;
            double y = Math.Cos(DegreesToRadians(180 - angleInDegrees)) * length;
            return new Vector(x, y);
        }

        static public double DegreesToRadians(double degrees)
        {
            double radians = ((degrees / 360) * 2 * Math.PI);
            return radians;
        }
    }
}
