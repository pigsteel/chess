
using OpenTK.Graphics.OpenGL;
using chess.Rendering;

namespace chess.Game;

public class TestObject : GameObject {
    public Mesh mesh;
    public Shader shader;

    public override void Start()
    {
        base.Start();
        mesh = new Mesh();
        mesh.SetVertices(Shapes.Square(-100.0f, -100.0f, 100.0f, 100.0f));
        mesh.Package();
        shader = new Shader(new string[] {@"shader.vert", @"shader.frag"});
    }

    public void Initialize()
    {
    }

    public override void Update() {
        Render();
    }

    public void Render()
    {
        shader?.Use();
        mesh?.Render(shader);
    }
}