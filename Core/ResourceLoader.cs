

using chess.Rendering;
using OpenTK.Graphics.OpenGL;
using System.IO;
using System.Linq;
using System.Data;

namespace chess;

public static class ResourceLoader {
    static string Path = @"Resources\\\";

    /// <summary>
    /// Shader pipeline loader. This takes the ID of a shader and attempts to load every step associated with it.
    /// Supports .vert, .frag and .geom
    /// </summary>
    /// <param name="path">The ID of a shader, i.e. its name.</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static int RequestShaderPipeline(string path) {
        int vert = -1, geom = -1, frag = -1;
        int handle = GL.CreateProgram();
        string LogPath = $"\'{path}\'";

        if(File.Exists(Path + $"{path}.vert")) {
            Console.WriteLine($"Found Vertex Shader for ID {LogPath}...");

            vert = GL.CreateShader(ShaderType.VertexShader);
            try {
                GL.ShaderSource(vert, File.ReadAllText(Path + $"{path}.vert"));
            } catch(FileLoadException e) {
                Console.WriteLine($"Failed while attempting to load file {path}.vert.");
                goto Failure;
            }

            GL.CompileShader(vert);
            string infoLog = GL.GetShaderInfoLog(vert);
            if (infoLog != string.Empty) {
                Console.WriteLine(infoLog);
                goto Failure;
            }

            GL.AttachShader(handle, vert);
        }
        
        if(File.Exists(Path + $"{path}.geom")) {
            Console.WriteLine($"Found Geometry Shader for ID {LogPath}...");

            geom = GL.CreateShader(ShaderType.GeometryShader);
            try {
                GL.ShaderSource(geom, File.ReadAllText(Path + $"{path}.geom"));
            } catch(FileLoadException e) {
                Console.WriteLine($"Failed while attempting to load file {path}.geom.");
                goto Failure;
            }

            GL.CompileShader(geom);
            string infoLog = GL.GetShaderInfoLog(geom);
            if (infoLog != string.Empty) {
                Console.WriteLine(infoLog);
                goto Failure;
            }

            GL.AttachShader(handle, geom);
        }

        if(File.Exists(Path + $"{path}.frag")) {
            Console.WriteLine($"Found Fragment Shader for ID {LogPath}...");

            frag = GL.CreateShader(ShaderType.FragmentShader);
            try {
                GL.ShaderSource(frag, File.ReadAllText(Path + $"{path}.frag"));
            } catch(FileLoadException e) {
                Console.WriteLine($"Failed while attempting to load file {path}.frag.");
                goto Failure;
            }

            GL.CompileShader(frag);
            string infoLog = GL.GetShaderInfoLog(frag);
            if (infoLog != string.Empty) {
                Console.WriteLine(infoLog);
                goto Failure;
            }

            GL.AttachShader(handle, frag);
        }

        GL.LinkProgram(handle);
        string programLog = GL.GetProgramInfoLog(handle);
        if (programLog != string.Empty) {
            Console.WriteLine(programLog);
            goto Failure;
        }

        DeleteShaderIfNull(handle, vert);
        DeleteShaderIfNull(handle, geom);
        DeleteShaderIfNull(handle, frag);

        Console.WriteLine($"Shader {LogPath} successfully compiled! Happy rendering.");

        return handle; 

        Failure:

        DeleteShaderIfNull(handle, vert);
        DeleteShaderIfNull(handle, geom);
        DeleteShaderIfNull(handle, frag);

        GL.DeleteProgram(handle);

        throw new Exception($"Compilation of {LogPath} shader failed. Skipping...");
    }

    public static void DeleteShaderIfNull(int handle, int shader) {
        if(handle != -1) {
            DeleteShader(handle, shader);
        }
    }

    public static void DeleteShader(int handle, int shader) {
        GL.DetachShader(handle, shader);
        GL.DeleteShader(shader);
    }

    public static void Load<T>(string path) {
        
    }

    public static Mesh RequestOBJModel(string path) {
        throw new NotImplementedException();
    }
}