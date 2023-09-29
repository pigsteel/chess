using System.Numerics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using Vector3 = OpenTK.Mathematics.Vector3;
using Matrix3x2 = OpenTK.Mathematics.Vector3;
using chess.Rendering;

namespace chess;

public class Mesh {
    protected float[] vertices = new float[] {};
    protected uint[] indices = new uint[] {};
    public Matrix3 modelMatrix {get; private set;}

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

        modelMatrix = Matrix3.Identity;
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

    public void Render(Shader shader) {
        shader.SetMatrix3(shader.GetUniformLocation("modelMatrix"), modelMatrix);
        shader.SetVector2(shader.GetUniformLocation("screenSize"), Program.GetWindowSize());

        GL.BindVertexArray(VAO);
        GL.DrawArrays(PrimitiveType.Triangles, 0, Length);
    }
}