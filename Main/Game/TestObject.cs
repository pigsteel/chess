
using OpenTK.Graphics.OpenGL;
using chess.Rendering;
using chess.Core;

namespace chess.Game;

public class TestObject : GameObject {
    public Model model;
    public Shader shader;
    public Texture texture;

    public override void Start()
    {
        base.Start();
        model = Model.Square(-100.0f, -100.0f, 100.0f, 100.0f);
        model.Package();
        shader = new Shader(new string[] {@"shader.vert", @"shader.frag"});
        texture = Resources.Load<Texture>("jed.webp");
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
        model?.Render(shader);
    }
}