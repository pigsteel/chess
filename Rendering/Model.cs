using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using chess.Rendering;

namespace chess;

public class Model {
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

    public Model() {
        VBO = GL.GenBuffer();
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
            GL.BindVertexArray(VAO);

            if(indices != null) {
                EBO = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
                GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.DynamicDraw);
            }

            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);

            GL.EnableVertexAttribArray(5);
            GL.VertexAttribPointer(5, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));

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

        GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
    }


    public static Model Square(float x1, float y1, float x2, float y2) {
        Model model = new Model();
        model.SetIndices(new uint[] {
            0, 1, 2, 2, 1, 3
        });

        model.SetVertices(new float[] {
            x1, y1, 0.0f, 0.0f, 0.0f,
            x2, y1, 0.0f, 1.0f, 0.0f,
            x1, y2, 0.0f, 0.0f, 1.0f,
            x2, y2, 0.0f, 1.0f, 1.0f
        });

        return model;
    }
}