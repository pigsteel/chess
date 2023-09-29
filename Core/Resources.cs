

using chess.Rendering;
using OpenTK.Graphics.OpenGL;
using System.IO;
using System.Linq;
using System.Data;
using System.Runtime.CompilerServices;
using System.Formats.Tar;

namespace chess;

public static class Resources {
    static string Directory = @"Resources\\\";

    public static T Load<T> (string fileName) where T : ILoadable<T> {
        return T.LoadResource(File.ReadAllBytes(Directory + fileName), fileName);
    }
}

public interface ILoadable<T> where T : ILoadable<T> {
    abstract static T LoadResource(byte[] bytes, string fileName);
}