namespace Homework8
{
    internal struct Vector3D
    {
        public double x;
        public double y;
        public double z;

        public Vector3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector3D operator *(Vector3D vector, double number)
        {
            return new Vector3D(vector.x * number, vector.y * number, vector.z * number);
        }

        public static Vector3D operator +(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1.x + vector2.x, vector1.y + vector2.y, vector1.z + vector2.z);
        }

        public static Vector3D operator -(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1.x - vector2.x, vector1.y - vector2.y, vector1.z - vector2.z);
        }

        public override string ToString()
        {
            return $"({x}; {y}; {z})";
        }
    }
}
