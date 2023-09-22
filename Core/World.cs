using System.Numerics;
using OpenTK.Mathematics;
using chess.Game;

namespace chess;

public static class World {
    static List<GameObject>? gameObjects = new List<GameObject>();

    public static Camera camera {get; private set;}

    public static void Start() {
        camera = new Camera();
        gameObjects.Add(new TestObject());

        RefreshRendering();

        foreach(GameObject? gameObject in gameObjects) {
            gameObject?.Start();
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
}