using OpenTK.Graphics.OpenGL4;
using StbImageSharp;

namespace chess.Core;

public class Texture : ILoadable<Texture>
{
    public int handle {get; private set;} = -1;

    public static Texture LoadResource(ref byte[] bytes, string fileName)
    {
        int thandle = GL.GenTexture();

        GL.ActiveTexture(TextureUnit.Texture0);
        GL.BindTexture(TextureTarget.Texture2D, thandle);

        StbImage.stbi_set_flip_vertically_on_load(1);

        ImageResult imageResult = ImageResult.FromMemory(bytes, ColorComponents.RedGreenBlueAlpha);

        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, imageResult.Width, imageResult.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, imageResult.Data);

        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

        //GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

        return new Texture { handle = thandle };
    }

    public static Texture LoadResource(ref FileStream stream, string fileName)
    {
        StbImage.stbi_set_flip_vertically_on_load(1);

        ImageResult imageResult = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);

        int thandle = GL.GenTexture();
        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, imageResult.Width, imageResult.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, imageResult.Data);

        //GL.TextureParameter(TextureTarget.Texture2D, );

        return new Texture { handle = thandle };
    }

    public void Use(TextureUnit unit) {
        GL.ActiveTexture(unit);
        GL.BindTexture(TextureTarget.Texture2D, handle);
    }
}