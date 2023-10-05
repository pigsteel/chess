
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
        string path = @"Resources\\\orange.jpg";
        FileStream stream = File.OpenRead(path);

        base.Start();
        model = Model.Square(0.0f, 0.0f, 640.0f, 427.0f);
        model.Package();
        shader = new Shader(new string[] {@"shader.vert", @"shader.frag"});
        texture = Resources.Load<Texture>("blueberry.jpg");
    }

    public void Initialize()
    {
    }

    public override void Update() {
        Render();
    }

    public void Render()
    {
        texture.Use(OpenTK.Graphics.OpenGL4.TextureUnit.Texture0);
        shader?.Use();
        model?.Render(shader);
    }
}