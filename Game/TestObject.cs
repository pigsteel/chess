
using OpenTK.Graphics.OpenGL;
using chess.Rendering;

namespace chess.Game;

public class TestObject : GameObject {
    Mesh mesh = new Mesh();

    public override void Start()
    {
        base.Start();

        mesh.SetVertices(Shapes.Square(0.0f, 0.0f, 100.0f, 100.0f));
        mesh.Package();
    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Render()
    {
        renderer.Render(ref mesh);

        base.Render();
    }

}