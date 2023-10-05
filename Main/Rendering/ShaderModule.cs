using System.Text;
using OpenTK.Graphics.OpenGL4;

namespace chess;

public class ShaderModule : ILoadable<ShaderModule> {
    public int handle {get; private set;} = -1;

    /// <summary>
    /// Loads a shader from a file.
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="fileName"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static ShaderModule LoadResource(ref byte[] bytes, string fileName) {
        Console.WriteLine($"Compiling ShaderModule {fileName}...");

        string extension = Path.GetExtension(fileName).ToUpper();
        ShaderType shaderType;
        switch(extension) {
            case ".VERT":
                shaderType = ShaderType.VertexShader;
                break;

            case ".FRAG":
                shaderType = ShaderType.FragmentShader;
                break;

            default:
                throw new Exception("Invalid ShaderModule file extension"); 
        }

        int thandle = GL.CreateShader(shaderType);
        var source = Encoding.UTF8.GetString(bytes);
        GL.ShaderSource(thandle, source);
        GL.CompileShader(thandle);

        // Check shader errors
        string infoLog = GL.GetShaderInfoLog(thandle);
        if (infoLog != string.Empty) {
            Console.WriteLine(infoLog);
            throw new Exception($"Compilation of {fileName} ShaderModule failed");
        }

        return new ShaderModule { handle = thandle };
    }

    public static ShaderModule LoadResource(ref FileStream stream, string fileName)
    {
        throw new NotImplementedException();
    }

    public void Destroy() {
        GL.DeleteShader(handle);
    }
}