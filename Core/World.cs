using System.Numerics;
using OpenTK.Mathematics;
using chess.Game;
using OpenTK.Graphics.OpenGL4;
using chess.Rendering;

namespace chess;

public static class World {
    static List<GameObject> gameObjects = new List<GameObject>();

    public static Camera camera {get; private set;}

    public static Shader shader;

    public static void Start() {
        camera = new Camera();
        gameObjects.Add(new TestObject());
        shader = new Shader("shader");

        Color(1);

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
        GL.Uniform3(2, i);
    }

    public static void Color(float i) {
        GL.Uniform3(2, i, i, i);
    }

    public static void Color(float r, float g, float b) {
        GL.Uniform3(2, r, g, b);
    }
}