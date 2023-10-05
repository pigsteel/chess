using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using OpenTK.Mathematics;

namespace chess.Rendering;

public static class Shapes {

    public static float[] Triangle(float x1, float y1, float x2, float y2, float x3, float y3) {
        return new float[] {
        x1, y1, 0.0f, //Bottom-left vertex
        x2, y2, 0.0f, //Bottom-right vertex
        x3, y3, 0.0f  //Top vertex
        };
    }

    public static float[] Triangle(Vector2 first, Vector2 second, Vector2 third) {
        return new float[] {
            first.X, first.Y, 0.0f,
            second.X, second.Y, 0.0f,
            third.X, third.Y, 0.0f
        };
    }

    public static float[] Triangle(Vector3 first, Vector3 second, Vector3 third) {
        return new float[] {
            first.X, first.Y, first.Z,
            second.X, second.Y, second.Z,
            third.X, third.Y, third.Z
        };
    }

    public static float[] Triangle(float x1, float y1, float x2, float y2) {
        return new float[] {
        x1, y1, 0.0f, // First vertex
        x2, y2, 0.0f, // Top vertex
        x2, y1, 0.0f  // Second vertex
        };
    }

    public static float[] Triangle(Vector2 first, Vector2 second) {
        return new float[] {
            first.X, first.Y, 0.0f,
            second.X, second.Y, 0.0f,
            second.X, first.Y, 0.0f
        };
    }

    public static float[] Square(float x1, float y1, float x2, float y2) {
        return new float[] {
            x1, y1, 0.0f, //0
            x2, y1, 0.0f, //1
            x1, y2, 0.0f, //2
            x1, y2, 0.0f, //3
            x2, y1, 0.0f, //4
            x2, y2, 0.0f  //5
        };
    }

    public static float[] Square(Vector2 first, Vector2 second) {
        return new float[] {
            first.X, first.Y, 0.0f, //0
            second.X, first.Y, 0.0f, //1
            first.X, second.Y, 0.0f, //2
            first.X, second.Y, 0.0f, //3
            second.X, first.Y, 0.0f, //4
            second.X, second.Y, 0.0f  //5
        };
    }


    public static float[] circle() {
        return null;
    }

    public static float[] line(float x1, float y1, float x2, float y2) {
        return new float[] {
            x1, y1, 0.0f,
            x2, y2, 0.0f
        };
    }

    public static float[] line(Vector2 first, Vector2 second) {
        return new float[] {
            first.X, first.Y, 0.0f,
            second.X, second.Y, 0.0f
        };
    }

    public static float[] line(Vector3 first, Vector3 second) {
        return new float[] {
            first.X, first.Y, first.Z,
            second.X, second.Y, second.Z
        };
    }

    public static float[] quad() {
        return null;
    }

    public static float[] rect() {
        return null;
    }
}