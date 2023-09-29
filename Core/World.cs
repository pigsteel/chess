using System.Numerics;
using OpenTK.Mathematics;
using chess.Game;
using OpenTK.Graphics.OpenGL4;
using chess.Rendering;

namespace chess;

public static class World {
    static List<GameObject> gameObjects = new List<GameObject>();
    static Dictionary<string, Shader> shaders = new Dictionary<string, Shader>();

    public static Camera camera {get; private set;}

    public static int flash = 0;

    public static void Start() {
        camera = new Camera();
        gameObjects.Add(new TestObject());
        shaders.Add("shader", new Shader("shader"));

        Color(1.0f, 0, 0);

        RefreshRendering();

        foreach(GameObject gameObject in gameObjects) {
            gameObject.Start();
        }
    }

    public static void RefreshRendering() { 
        camera.Refresh(Program.GetWindowSize());
    }

    public static void FixedUpdateWorld() {
        foreach(GameObject? gameObject in gameObjects) {
            gameObject?.FixedUpdate();
        }
    }

    public static void UpdateWorld(double delta) {
        foreach(GameObject? gameObject in gameObjects) {
            gameObject?.Update();
        }

        if (flash <= 100) {
            flash++;
            Color(1, 0, 0);
        } else if (flash > 100 && flash <= 200) {
            flash++;
            Color(0, 1, 0);
        } else {
            flash = 0;
        }
    }

    public static void RenderWorld(double delta) {
        foreach(GameObject? gameObject in gameObjects) {
            gameObject?.Render();
        }
    }

    public static void LateUpdateWorld(double delta) {
        foreach(GameObject? gameObject in gameObjects) {
            gameObject?.LateUpdate();
        }
    }

    public static void Color(OpenTK.Mathematics.Vector3 i) {
        GetShader("shader").SetVector3(2, i);
    }

    public static void Color(float i) {
        GetShader("shader").SetVector3(2, new OpenTK.Mathematics.Vector3(i, i, i));
    }

    public static void Color(float r, float g, float b) {
        GetShader("shader").SetVector3(2, new OpenTK.Mathematics.Vector3(r, g, b));
    }

    public static Shader GetShader(string id) {
        return shaders[id];
    }
}