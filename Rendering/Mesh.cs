using System.Numerics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using Vector3 = OpenTK.Mathematics.Vector3;

namespace chess;

public class Mesh {
    protected float[]? vertices = null;
    protected uint[]? indices = null;

    public int Length {
        get {
            return vertices.Length;
        }
        private set{}
    }

    public int VBO;
    public int EBO;
    public int VAO;

    public bool Initialized;

    public Mesh() {
        VBO = GL.GenBuffer();
        EBO = GL.GenBuffer();
        VAO = GL.GenVertexArray();
    }

    public void SetVertices(float[] vertices) {
        this.vertices = vertices;
    }

    public void SetIndices(uint[] indices) {
        this.indices = indices;
    }

    public void SetNormals() {

    }

    public void Package() {
        if (vertices != null) {
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.DynamicDraw);

            if(indices != null) {
                //GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
                //GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.DynamicDraw);
            }

            GL.BindVertexArray(VAO);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            Initialized = true;

            Console.WriteLine();
            } else {
            throw new Exception("No vertex data to package!");
        }
    }
}