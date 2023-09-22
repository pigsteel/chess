

using chess;
using chess.Rendering;
using OpenTK.Graphics.OpenGL;

public class Renderer {
    /// <summary>
    /// The shader pipeline assigned to this Renderer.
    /// </summary>
    Shader shader;

    public void Initialize(Shader shader) {
        this.shader = shader;

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="camera"></param>
    public void Render(ref Mesh mesh) {
        shader.Use();
        
        if(mesh.Initialized) {
            GL.BindVertexArray(mesh.VAO);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
        }
    }

}