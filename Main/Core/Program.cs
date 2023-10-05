using System.Numerics;
using OpenTK.Graphics.OpenGL4;

namespace chess;

public static class Program {
    private static Window window;

    public static void Main(string[] args) {
        Console.WriteLine("Initializing...");

        /*
            Where we initialize our settings.
        */

        window = new Window(800, 600, "Window");
        window.Run();

        Console.WriteLine("Exiting...");
    }
    
    public static OpenTK.Mathematics.Vector2 GetWindowSize() {
        return window.Size;
    }
}

