using System.Runtime.CompilerServices;

namespace chess.Rendering;

public static class Shapes {

    public static float[]? Triangle(float x1, float y1, float x2, float y2, float x3, float y3) {
        return new float[] {
        x1, y1, 0.0f, //Bottom-left vertex
        x2, y2, 0.0f, //Bottom-right vertex
        x3, y3, 0.0f  //Top vertex
        };
    }

    public static float[]? Triangle(float x1, float y1, float x2, float y2) {
        return new float[] {
        x1, y1, 0.0f, //Bottom-left vertex
        x2, y2, 0.0f, //Bottom-right vertex
        x2, y1, 0.0f  //Top vertex
        };
    }

    public static float[]? square() {
        return null;
    }

    public static float[]? circle() {
        return null;
    }

    public static float[]? line() {
        return null;
    }

    public static float[]? point() {
        return null;
    }

    public static float[]? quad() {
        return null;
    }

    public static float[]? rect() {
        return null;
    }
}