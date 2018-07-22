﻿/*
Copyright (c) 2006 - 2008 The Open Toolkit library.

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
of the Software, and to permit persons to whom the Software is furnished to do
so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
 */

using System;
using System.Runtime.InteropServices;

namespace Urho3DNet
{
    /// <summary>
    /// Represents a 3x4 Matrix
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix3x4 : IEquatable<Matrix3x4>
    {
        /// <summary>
        /// Top row of the matrix
        /// </summary>
        public Vector4 Row0;

        /// <summary>
        /// 2nd row of the matrix
        /// </summary>
        public Vector4 Row1;

        /// <summary>
        /// Bottom row of the matrix
        /// </summary>
        public Vector4 Row2;

        /// <summary>
        /// The identity matrix.
        /// </summary>
        public static readonly Matrix3x4 Identity = new Matrix3x4(Vector4.UnitX, Vector4.UnitY, Vector4.UnitZ);

        /// <summary>
        /// The zero matrix
        /// </summary>
        public static Matrix3x4 Zero = new Matrix3x4(Vector4.Zero, Vector4.Zero, Vector4.Zero);

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="row0">Top row of the matrix</param>
        /// <param name="row1">Second row of the matrix</param>
        /// <param name="row2">Bottom row of the matrix</param>
        public Matrix3x4(Vector4 row0, Vector4 row1, Vector4 row2)
        {
            Row0 = row0;
            Row1 = row1;
            Row2 = row2;
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="m00">First item of the first row of the matrix.</param>
        /// <param name="m01">Second item of the first row of the matrix.</param>
        /// <param name="m02">Third item of the first row of the matrix.</param>
        /// <param name="m03">Fourth item of the first row of the matrix.</param>
        /// <param name="m10">First item of the second row of the matrix.</param>
        /// <param name="m11">Second item of the second row of the matrix.</param>
        /// <param name="m12">Third item of the second row of the matrix.</param>
        /// <param name="m13">Fourth item of the second row of the matrix.</param>
        /// <param name="m20">First item of the third row of the matrix.</param>
        /// <param name="m21">Second item of the third row of the matrix.</param>
        /// <param name="m22">Third item of the third row of the matrix.</param>
        /// <param name="m23">First item of the third row of the matrix.</param>
        public Matrix3x4(
            float m00, float m01, float m02, float m03,
            float m10, float m11, float m12, float m13,
            float m20, float m21, float m22, float m23)
        {
            Row0 = new Vector4(m00, m01, m02, m03);
            Row1 = new Vector4(m10, m11, m12, m13);
            Row2 = new Vector4(m20, m21, m22, m23);
        }

        /// Copy-construct from a 3x3 matrix and set the extra elements to identity.
        public Matrix3x4(Matrix3 matrix)
        {
            Row0 = new Vector4(matrix.Row0, 0.0f);
            Row1 = new Vector4(matrix.Row1, 0.0f);
            Row2 = new Vector4(matrix.Row2, 0.0f);
        }

        /// <summary>
        /// Gets the first column of this matrix.
        /// </summary>
        public Vector3 Column0
        {
            get { return new Vector3(Row0.X, Row1.X, Row2.X); }
        }

        /// <summary>
        /// Gets the second column of this matrix.
        /// </summary>
        public Vector3 Column1
        {
            get { return new Vector3(Row0.Y, Row1.Y, Row2.Y); }
        }

        /// <summary>
        /// Gets the third column of this matrix.
        /// </summary>
        public Vector3 Column2
        {
            get { return new Vector3(Row0.Z, Row1.Z, Row2.Z); }
        }

        /// <summary>
        /// Gets the fourth column of this matrix.
        /// </summary>
        public Vector3 Column3
        {
            get { return new Vector3(Row0.W, Row1.W, Row2.W); }
        }

        /// <summary>
        /// Gets or sets the value at row 1, column 1 of this instance.
        /// </summary>
        public float M00 { get { return Row0.X; } set { Row0.X = value; } }

        /// <summary>
        /// Gets or sets the value at row 1, column 2 of this instance.
        /// </summary>
        public float M01 { get { return Row0.Y; } set { Row0.Y = value; } }

        /// <summary>
        /// Gets or sets the value at row 1, column 3 of this instance.
        /// </summary>
        public float M02 { get { return Row0.Z; } set { Row0.Z = value; } }

        /// <summary>
        /// Gets or sets the value at row 1, column 4 of this instance.
        /// </summary>
        public float M03 { get { return Row0.W; } set { Row0.W = value; } }

        /// <summary>
        /// Gets or sets the value at row 2, column 1 of this instance.
        /// </summary>
        public float M10 { get { return Row1.X; } set { Row1.X = value; } }

        /// <summary>
        /// Gets or sets the value at row 2, column 2 of this instance.
        /// </summary>
        public float M11 { get { return Row1.Y; } set { Row1.Y = value; } }

        /// <summary>
        /// Gets or sets the value at row 2, column 3 of this instance.
        /// </summary>
        public float M12 { get { return Row1.Z; } set { Row1.Z = value; } }

        /// <summary>
        /// Gets or sets the value at row 2, column 4 of this instance.
        /// </summary>
        public float M13 { get { return Row1.W; } set { Row1.W = value; } }

        /// <summary>
        /// Gets or sets the value at row 3, column 1 of this instance.
        /// </summary>
        public float M20 { get { return Row2.X; } set { Row2.X = value; } }

        /// <summary>
        /// Gets or sets the value at row 3, column 2 of this instance.
        /// </summary>
        public float M21 { get { return Row2.Y; } set { Row2.Y = value; } }

        /// <summary>
        /// Gets or sets the value at row 3, column 3 of this instance.
        /// </summary>
        public float M22 { get { return Row2.Z; } set { Row2.Z = value; } }

        /// <summary>
        /// Gets or sets the value at row 3, column 4 of this instance.
        /// </summary>
        public float M23 { get { return Row2.W; } set { Row2.W = value; } }

        /// <summary>
        /// Gets or sets the values along the main diagonal of the matrix.
        /// </summary>
        public Vector3 Diagonal
        {
            get
            {
                return new Vector3(Row0.X, Row1.Y, Row2.Z);
            }
            set
            {
                Row0.X = value.X;
                Row1.Y = value.Y;
                Row2.Z = value.Z;
            }
        }

        /// <summary>
        /// Gets the trace of the matrix, the sum of the values along the diagonal.
        /// </summary>
        public float Trace { get { return Row0.X + Row1.Y + Row2.Z; } }

        /// <summary>
        /// Gets or sets the value at a specified row and column.
        /// </summary>
        public float this[int rowIndex, int columnIndex]
        {
            get
            {
                if (rowIndex == 0)
                {
                    return Row0[columnIndex];
                }
                else if (rowIndex == 1)
                {
                    return Row1[columnIndex];
                }
                else if (rowIndex == 2)
                {
                    return Row2[columnIndex];
                }
                throw new IndexOutOfRangeException("You tried to access this matrix at: (" + rowIndex + ", " + columnIndex + ")");
            }
            set
            {
                if (rowIndex == 0)
                {
                    Row0[columnIndex] = value;
                }
                else if (rowIndex == 1)
                {
                    Row1[columnIndex] = value;
                }
                else if (rowIndex == 2)
                {
                    Row2[columnIndex] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("You tried to set this matrix at: (" + rowIndex + ", " + columnIndex + ")");
                }
            }
        }

        /// <summary>
        /// Converts this instance into its inverse.
        /// </summary>
        public void Invert()
        {
            this = Matrix3x4.Invert(this);
        }

        /// <summary>
        /// Build a rotation matrix from the specified axis/angle rotation.
        /// </summary>
        /// <param name="axis">The axis to rotate about.</param>
        /// <param name="angle">Angle in radians to rotate counter-clockwise (looking in the direction of the given axis).</param>
        /// <param name="result">A matrix instance.</param>
        public static void CreateFromAxisAngle(Vector3 axis, float angle, out Matrix3x4 result)
        {
            axis.Normalize();
            float axisX = axis.X, axisY = axis.Y, axisZ = axis.Z;

            float cos = (float)System.Math.Cos(angle);
            float sin = (float)System.Math.Sin(angle);
            float t = 1.0f - cos;

            float tXX = t * axisX * axisX,
                tXY = t * axisX * axisY,
                tXZ = t * axisX * axisZ,
                tYY = t * axisY * axisY,
                tYZ = t * axisY * axisZ,
                tZZ = t * axisZ * axisZ;

            float sinX = sin * axisX,
                sinY = sin * axisY,
                sinZ = sin * axisZ;

            result.Row0.X = tXX + cos;
            result.Row0.Y = tXY - sinZ;
            result.Row0.Z = tXZ + sinY;
            result.Row0.W = 0;
            result.Row1.X = tXY + sinZ;
            result.Row1.Y = tYY + cos;
            result.Row1.Z = tYZ - sinX;
            result.Row1.W = 0;
            result.Row2.X = tXZ - sinY;
            result.Row2.Y = tYZ + sinX;
            result.Row2.Z = tZZ + cos;
            result.Row2.W = 0;
        }

        /// <summary>
        /// Build a rotation matrix from the specified axis/angle rotation.
        /// </summary>
        /// <param name="axis">The axis to rotate about.</param>
        /// <param name="angle">Angle in radians to rotate counter-clockwise (looking in the direction of the given axis).</param>
        /// <returns>A matrix instance.</returns>
        public static Matrix3x4 CreateFromAxisAngle(Vector3 axis, float angle)
        {
            Matrix3x4 result;
            CreateFromAxisAngle(axis, angle, out result);
            return result;
        }

        /// <summary>
        /// Builds a rotation matrix from a quaternion.
        /// </summary>
        /// <param name="q">The quaternion to rotate by.</param>
        /// <param name="result">A matrix instance.</param>
        public static void CreateFromQuaternion(ref Quaternion q, out Matrix3x4 result)
        {
            float x = q.X, y = q.Y, z = q.Z, w = q.W,
                tx = 2 * x, ty = 2 * y, tz = 2 * z,
                txx = tx * x, tyy = ty * y, tzz = tz * z,
                txy = tx * y, txz = tx * z, tyz = ty * z,
                txw = tx * w, tyw = ty * w, tzw = tz * w;

            result.Row0.X = 1f - (tyy + tzz);
            result.Row0.Y = txy + tzw;
            result.Row0.Z = txz - tyw;
            result.Row0.W = 0f;
            result.Row1.X = txy - tzw;
            result.Row1.Y = 1f - (txx + tzz);
            result.Row1.Z = tyz + txw;
            result.Row1.W = 0f;
            result.Row2.X = txz + tyw;
            result.Row2.Y = tyz - txw;
            result.Row2.Z = 1f - (txx + tyy);
            result.Row2.W = 0f;

            /*Vector3 axis;
            float angle;
            q.ToAxisAngle(out axis, out angle);
            CreateFromAxisAngle(axis, angle, out result);*/
        }

        /// <summary>
        /// Builds a rotation matrix from a quaternion.
        /// </summary>
        /// <param name="q">The quaternion to rotate by.</param>
        /// <returns>A matrix instance.</returns>
        public static Matrix3x4 CreateFromQuaternion(Quaternion q)
        {
            Matrix3x4 result;
            CreateFromQuaternion(ref q, out result);
            return result;
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation around the x-axis.
        /// </summary>
        /// <param name="angle">The counter-clockwise angle in radians.</param>
        /// <param name="result">The resulting Matrix4 instance.</param>
        public static void CreateRotationX(float angle, out Matrix3x4 result)
        {
            float cos = (float)System.Math.Cos(angle);
            float sin = (float)System.Math.Sin(angle);

            result.Row0.X = 1;
            result.Row0.Y = 0;
            result.Row0.Z = 0;
            result.Row0.W = 0;
            result.Row1.X = 0;
            result.Row1.Y = cos;
            result.Row1.Z = sin;
            result.Row1.W = 0;
            result.Row2.X = 0;
            result.Row2.Y = -sin;
            result.Row2.Z = cos;
            result.Row2.W = 0;
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation around the x-axis.
        /// </summary>
        /// <param name="angle">The counter-clockwise angle in radians.</param>
        /// <returns>The resulting Matrix4 instance.</returns>
        public static Matrix3x4 CreateRotationX(float angle)
        {
            Matrix3x4 result;
            CreateRotationX(angle, out result);
            return result;
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation around the y-axis.
        /// </summary>
        /// <param name="angle">The counter-clockwise angle in radians.</param>
        /// <param name="result">The resulting Matrix4 instance.</param>
        public static void CreateRotationY(float angle, out Matrix3x4 result)
        {
            float cos = (float)System.Math.Cos(angle);
            float sin = (float)System.Math.Sin(angle);

            result.Row0.X = cos;
            result.Row0.Y = 0;
            result.Row0.Z = -sin;
            result.Row0.W = 0;
            result.Row1.X = 0;
            result.Row1.Y = 1;
            result.Row1.Z = 0;
            result.Row1.W = 0;
            result.Row2.X = sin;
            result.Row2.Y = 0;
            result.Row2.Z = cos;
            result.Row2.W = 0;
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation around the y-axis.
        /// </summary>
        /// <param name="angle">The counter-clockwise angle in radians.</param>
        /// <returns>The resulting Matrix4 instance.</returns>
        public static Matrix3x4 CreateRotationY(float angle)
        {
            Matrix3x4 result;
            CreateRotationY(angle, out result);
            return result;
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation around the z-axis.
        /// </summary>
        /// <param name="angle">The counter-clockwise angle in radians.</param>
        /// <param name="result">The resulting Matrix4 instance.</param>
        public static void CreateRotationZ(float angle, out Matrix3x4 result)
        {
            float cos = (float)System.Math.Cos(angle);
            float sin = (float)System.Math.Sin(angle);

            result.Row0.X = cos;
            result.Row0.Y = sin;
            result.Row0.Z = 0;
            result.Row0.W = 0;
            result.Row1.X = -sin;
            result.Row1.Y = cos;
            result.Row1.Z = 0;
            result.Row1.W = 0;
            result.Row2.X = 0;
            result.Row2.Y = 0;
            result.Row2.Z = 1;
            result.Row2.W = 0;
        }

        /// <summary>
        /// Builds a rotation matrix for a rotation around the z-axis.
        /// </summary>
        /// <param name="angle">The counter-clockwise angle in radians.</param>
        /// <returns>The resulting Matrix4 instance.</returns>
        public static Matrix3x4 CreateRotationZ(float angle)
        {
            Matrix3x4 result;
            CreateRotationZ(angle, out result);
            return result;
        }

        /// <summary>
        /// Creates a translation matrix.
        /// </summary>
        /// <param name="x">X translation.</param>
        /// <param name="y">Y translation.</param>
        /// <param name="z">Z translation.</param>
        /// <param name="result">The resulting Matrix4 instance.</param>
        public static void CreateTranslation(float x, float y, float z, out Matrix3x4 result)
        {
            result.Row0.X = 1;
            result.Row0.Y = 0;
            result.Row0.Z = 0;
            result.Row0.W = x;
            result.Row1.X = 0;
            result.Row1.Y = 1;
            result.Row1.Z = 0;
            result.Row1.W = y;
            result.Row2.X = 0;
            result.Row2.Y = 0;
            result.Row2.Z = 1;
            result.Row2.W = z;
        }

        /// <summary>
        /// Creates a translation matrix.
        /// </summary>
        /// <param name="vector">The translation vector.</param>
        /// <param name="result">The resulting Matrix4 instance.</param>
        public static void CreateTranslation(ref Vector3 vector, out Matrix3x4 result)
        {
            result.Row0.X = 1;
            result.Row0.Y = 0;
            result.Row0.Z = 0;
            result.Row0.W = vector.X;
            result.Row1.X = 0;
            result.Row1.Y = 1;
            result.Row1.Z = 0;
            result.Row1.W = vector.Y;
            result.Row2.X = 0;
            result.Row2.Y = 0;
            result.Row2.Z = 1;
            result.Row2.W = vector.Z;
        }

        /// <summary>
        /// Creates a translation matrix.
        /// </summary>
        /// <param name="x">X translation.</param>
        /// <param name="y">Y translation.</param>
        /// <param name="z">Z translation.</param>
        /// <returns>The resulting Matrix4 instance.</returns>
        public static Matrix3x4 CreateTranslation(float x, float y, float z)
        {
            Matrix3x4 result;
            CreateTranslation(x, y, z, out result);
            return result;
        }

        /// <summary>
        /// Creates a translation matrix.
        /// </summary>
        /// <param name="vector">The translation vector.</param>
        /// <returns>The resulting Matrix4 instance.</returns>
        public static Matrix3x4 CreateTranslation(Vector3 vector)
        {
            Matrix3x4 result;
            CreateTranslation(vector.X, vector.Y, vector.Z, out result);
            return result;
        }

        /// <summary>
        /// Build a scaling matrix
        /// </summary>
        /// <param name="scale">Single scale factor for x,y and z axes</param>
        /// <returns>A scaling matrix</returns>
        public static Matrix3x4 CreateScale(float scale)
        {
            return CreateScale(scale, scale, scale);
        }

        /// <summary>
        /// Build a scaling matrix
        /// </summary>
        /// <param name="scale">Scale factors for x,y and z axes</param>
        /// <returns>A scaling matrix</returns>
        public static Matrix3x4 CreateScale(Vector3 scale)
        {
            return CreateScale(scale.X, scale.Y, scale.Z);
        }

        /// <summary>
        /// Build a scaling matrix
        /// </summary>
        /// <param name="x">Scale factor for x-axis</param>
        /// <param name="y">Scale factor for y-axis</param>
        /// <param name="z">Scale factor for z-axis</param>
        /// <returns>A scaling matrix</returns>
        public static Matrix3x4 CreateScale(float x, float y, float z)
        {
            Matrix3x4 result;
            result.Row0.X = x;
            result.Row0.Y = 0;
            result.Row0.Z = 0;
            result.Row0.W = 0;
            result.Row1.X = 0;
            result.Row1.Y = y;
            result.Row1.Z = 0;
            result.Row1.W = 0;
            result.Row2.X = 0;
            result.Row2.Y = 0;
            result.Row2.Z = z;
            result.Row2.W = 0;
            return result;
        }

        /// <summary>
        /// Multiplies two instances.
        /// </summary>
        /// <param name="left">The left operand of the multiplication.</param>
        /// <param name="right">The right operand of the multiplication.</param>
        /// <returns>A new instance that is the result of the multiplication</returns>
        public static Matrix3x4 Mult(Matrix3x4 left, Matrix3x4 right)
        {
            Matrix3x4 result;
            Mult(ref left, ref right, out result);
            return result;
        }

        /// <summary>
        /// Multiplies two instances.
        /// </summary>
        /// <param name="left">The left operand of the multiplication.</param>
        /// <param name="right">The right operand of the multiplication.</param>
        /// <param name="result">A new instance that is the result of the multiplication</param>
        public static void Mult(ref Matrix3x4 left, ref Matrix3x4 right, out Matrix3x4 result)
        {
            float lM00 = left.Row0.X, lM01 = left.Row0.Y, lM02 = left.Row0.Z, lM03 = left.Row0.W,
                lM10 = left.Row1.X, lM11 = left.Row1.Y, lM12 = left.Row1.Z, lM13 = left.Row1.W,
                lM20 = left.Row2.X, lM21 = left.Row2.Y, lM22 = left.Row2.Z, lM23 = left.Row2.W,
                rM00 = right.Row0.X, rM01 = right.Row0.Y, rM02 = right.Row0.Z, rM03 = right.Row0.W,
                rM10 = right.Row1.X, rM11 = right.Row1.Y, rM12 = right.Row1.Z, rM13 = right.Row1.W,
                rM20 = right.Row2.X, rM21 = right.Row2.Y, rM22 = right.Row2.Z, rM23 = right.Row2.W;

            result.Row0.X = (lM00 * rM00) + (lM01 * rM10) + (lM02 * rM20);
            result.Row0.Y = (lM00 * rM01) + (lM01 * rM11) + (lM02 * rM21);
            result.Row0.Z = (lM00 * rM02) + (lM01 * rM12) + (lM02 * rM22);
            result.Row0.W = (lM00 * rM03) + (lM01 * rM13) + (lM02 * rM23) + lM03;
            result.Row1.X = (lM10 * rM00) + (lM11 * rM10) + (lM12 * rM20);
            result.Row1.Y = (lM10 * rM01) + (lM11 * rM11) + (lM12 * rM21);
            result.Row1.Z = (lM10 * rM02) + (lM11 * rM12) + (lM12 * rM22);
            result.Row1.W = (lM10 * rM03) + (lM11 * rM13) + (lM12 * rM23) + lM13;
            result.Row2.X = (lM20 * rM00) + (lM21 * rM10) + (lM22 * rM20);
            result.Row2.Y = (lM20 * rM01) + (lM21 * rM11) + (lM22 * rM21);
            result.Row2.Z = (lM20 * rM02) + (lM21 * rM12) + (lM22 * rM22);
            result.Row2.W = (lM20 * rM03) + (lM21 * rM13) + (lM22 * rM23) + lM23;

            /*result.Row0 = (right.Row0 * lM00 + right.Row1 * lM01 + right.Row2 * lM02);
            result.Row0.W += lM03;

            result.Row1 = (right.Row0 * lM10 + right.Row1 * lM11 + right.Row2 * lM12);
            result.Row1.W += lM13;

            result.Row2 = (right.Row0 * lM20 + right.Row1 * lM21 + right.Row2 * lM22);
            result.Row2.W += lM23;*/
        }

        /// <summary>
        /// Multiplies an instance by a scalar.
        /// </summary>
        /// <param name="left">The left operand of the multiplication.</param>
        /// <param name="right">The right operand of the multiplication.</param>
        /// <returns>A new instance that is the result of the multiplication</returns>
        public static Matrix3x4 Mult(Matrix3x4 left, float right)
        {
            Matrix3x4 result;
            Mult(ref left, right, out result);
            return result;
        }

        /// <summary>
        /// Multiplies an instance by a scalar.
        /// </summary>
        /// <param name="left">The left operand of the multiplication.</param>
        /// <param name="right">The right operand of the multiplication.</param>
        /// <param name="result">A new instance that is the result of the multiplication</param>
        public static void Mult(ref Matrix3x4 left, float right, out Matrix3x4 result)
        {
            result.Row0 = left.Row0 * right;
            result.Row1 = left.Row1 * right;
            result.Row2 = left.Row2 * right;
        }

        /// <summary>
        /// Adds two instances.
        /// </summary>
        /// <param name="left">The left operand of the addition.</param>
        /// <param name="right">The right operand of the addition.</param>
        /// <returns>A new instance that is the result of the addition.</returns>
        public static Matrix3x4 Add(Matrix3x4 left, Matrix3x4 right)
        {
            Matrix3x4 result;
            Add(ref left, ref right, out result);
            return result;
        }

        /// <summary>
        /// Adds two instances.
        /// </summary>
        /// <param name="left">The left operand of the addition.</param>
        /// <param name="right">The right operand of the addition.</param>
        /// <param name="result">A new instance that is the result of the addition.</param>
        public static void Add(ref Matrix3x4 left, ref Matrix3x4 right, out Matrix3x4 result)
        {
            result.Row0 = left.Row0 + right.Row0;
            result.Row1 = left.Row1 + right.Row1;
            result.Row2 = left.Row2 + right.Row2;
        }

        /// <summary>
        /// Subtracts one instance from another.
        /// </summary>
        /// <param name="left">The left operand of the subraction.</param>
        /// <param name="right">The right operand of the subraction.</param>
        /// <returns>A new instance that is the result of the subraction.</returns>
        public static Matrix3x4 Subtract(Matrix3x4 left, Matrix3x4 right)
        {
            Matrix3x4 result;
            Subtract(ref left, ref right, out result);
            return result;
        }

        /// <summary>
        /// Subtracts one instance from another.
        /// </summary>
        /// <param name="left">The left operand of the subraction.</param>
        /// <param name="right">The right operand of the subraction.</param>
        /// <param name="result">A new instance that is the result of the subraction.</param>
        public static void Subtract(ref Matrix3x4 left, ref Matrix3x4 right, out Matrix3x4 result)
        {
            result.Row0 = left.Row0 - right.Row0;
            result.Row1 = left.Row1 - right.Row1;
            result.Row2 = left.Row2 - right.Row2;
        }

        /// <summary>
        /// Calculate the inverse of the given matrix
        /// </summary>
        /// <param name="mat">The matrix to invert</param>
        /// <returns>The inverse of the given matrix if it has one, or the input if it is singular</returns>
        /// <exception cref="InvalidOperationException">Thrown if the Matrix4 is singular.</exception>
        public static Matrix3x4 Invert(Matrix3x4 mat)
        {
            Matrix3x4 result;
            Invert(ref mat, out result);
            return result;
        }

        /// <summary>
        /// Calculate the inverse of the given matrix
        /// </summary>
        /// <param name="mat">The matrix to invert</param>
        /// <param name="result">The inverse of the given matrix if it has one, or the input if it is singular</param>
        /// <exception cref="InvalidOperationException">Thrown if the Matrix4 is singular.</exception>
        public static void Invert(ref Matrix3x4 mat, out Matrix3x4 result)
        {
            Matrix3 inverseRotation = new Matrix3(mat.Column0, mat.Column1, mat.Column2);
            inverseRotation.Row0 /= inverseRotation.Row0.LengthSquared;
            inverseRotation.Row1 /= inverseRotation.Row1.LengthSquared;
            inverseRotation.Row2 /= inverseRotation.Row2.LengthSquared;

            Vector3 translation = new Vector3(mat.Row0.W, mat.Row1.W, mat.Row2.W);

            result.Row0 = new Vector4(inverseRotation.Row0, -Vector3.Dot(inverseRotation.Row0, translation));
            result.Row1 = new Vector4(inverseRotation.Row1, -Vector3.Dot(inverseRotation.Row1, translation));
            result.Row2 = new Vector4(inverseRotation.Row2, -Vector3.Dot(inverseRotation.Row2, translation));
        }

        /// <summary>
        /// Matrix-scalar multiplication
        /// </summary>
        /// <param name="left">left-hand operand</param>
        /// <param name="right">right-hand operand</param>
        /// <returns>A new Matrix3x4 which holds the result of the multiplication</returns>
        public static Matrix3x4 operator *(Matrix3x4 left, Matrix3x4 right)
        {
            return Matrix3x4.Mult(left, right);
        }

        /// <summary>
        /// Matrix-scalar multiplication
        /// </summary>
        /// <param name="left">left-hand operand</param>
        /// <param name="right">right-hand operand</param>
        /// <returns>A new Matrix3x4 which holds the result of the multiplication</returns>
        public static Matrix3x4 operator *(Matrix3x4 left, float right)
        {
            return Matrix3x4.Mult(left, right);
        }
        /// <summary>
        /// Multiply a Vector3 which is assumed to represent position.
        /// </summary>
        /// <param name="left">left-hand operand</param>
        /// <param name="right">right-hand operand</param>
        /// <returns>A new Matrix3x4 which holds the result of the multiplication</returns>
        public static Vector3 operator *(Matrix3x4 left, Vector3 right)
        {
            return new Vector3(
                (left.M00 * right.X + left.M01 * right.Y + left.M02 * right.Z + left.M03),
                (left.M10 * right.X + left.M11 * right.Y + left.M12 * right.Z + left.M13),
                (left.M20 * right.X + left.M21 * right.Y + left.M22 * right.Z + left.M23)
            );
        }

        /// <summary>
        /// Matrix addition
        /// </summary>
        /// <param name="left">left-hand operand</param>
        /// <param name="right">right-hand operand</param>
        /// <returns>A new Matrix3x4 which holds the result of the addition</returns>
        public static Matrix3x4 operator +(Matrix3x4 left, Matrix3x4 right)
        {
            return Matrix3x4.Add(left, right);
        }

        /// <summary>
        /// Matrix subtraction
        /// </summary>
        /// <param name="left">left-hand operand</param>
        /// <param name="right">right-hand operand</param>
        /// <returns>A new Matrix3x4 which holds the result of the subtraction</returns>
        public static Matrix3x4 operator -(Matrix3x4 left, Matrix3x4 right)
        {
            return Matrix3x4.Subtract(left, right);
        }

        /// <summary>
        /// Compares two instances for equality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left equals right; false otherwise.</returns>
        public static bool operator ==(Matrix3x4 left, Matrix3x4 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two instances for inequality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left does not equal right; false otherwise.</returns>
        public static bool operator !=(Matrix3x4 left, Matrix3x4 right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Returns a System.String that represents the current Matrix4.
        /// </summary>
        /// <returns>The string representation of the matrix.</returns>
        public override string ToString()
        {
            return string.Format("{0}\n{1}\n{2}", Row0, Row1, Row2);
        }

        /// <summary>
        /// Returns the hashcode for this instance.
        /// </summary>
        /// <returns>A System.Int32 containing the unique hashcode for this instance.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = this.Row0.GetHashCode();
                hashCode = (hashCode * 397) ^ this.Row1.GetHashCode();
                hashCode = (hashCode * 397) ^ this.Row2.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>True if the instances are equal; false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Matrix3x4))
            {
                return false;
            }

            return this.Equals((Matrix3x4)obj);
        }

        /// <summary>
        /// Indicates whether the current matrix is equal to another matrix.
        /// </summary>
        /// <param name="other">An matrix to compare with this matrix.</param>
        /// <returns>true if the current matrix is equal to the matrix parameter; otherwise, false.</returns>
        public bool Equals(Matrix3x4 other)
        {
            return
                Row0 == other.Row0 &&
                Row1 == other.Row1 &&
                Row2 == other.Row2;
        }
    }
}
