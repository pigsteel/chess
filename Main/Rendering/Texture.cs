using OpenTK.Graphics.OpenGL4;
using StbImageSharp;

namespace chess.Core;

public class Texture : ILoadable<Texture>
{
    public int handle {get; private set;} = -1;

    public static Texture LoadResource(ref byte[] bytes, string fileName)
    {
        StbImage.stbi_set_flip_vertically_on_load(1);

        ImageResult imageResult = ImageResult.FromMemory(bytes, ColorComponents.RedGreenBlueAlpha);

        int thandle = GL.GenTexture();
        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, imageResult.Width, imageResult.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, imageResult.Data);
        //GL.TextureParameter(TextureTarget.Texture2D, );

        return new Texture { handle = thandle };
    }

    public static Texture LoadResource(ref FileStream stream, string fileName)
    {
        throw new NotImplementedException();
    }
}