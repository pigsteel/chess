using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using chess.Rendering;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace chess;

public class Window : GameWindow 
{
    private int ScreenSizeVBO;

    public Window(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) {

    }
    
    protected override void OnLoad() {
        base.OnLoad();
        ScreenSizeVBO = GL.GenBuffer();

        World.Start();
    }

    // Our two main functions, Update and Render.
    protected override void OnUpdateFrame(FrameEventArgs e) {
        base.OnUpdateFrame(e);

        World.FixedUpdateWorld();
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);

        GL.Clear(ClearBufferMask.ColorBufferBit);

        World.UpdateWorld(e.Time);
        World.RenderWorld(e.Time);
        World.LateUpdateWorld(e.Time);

        SwapBuffers();
    }

    protected override void OnResize(ResizeEventArgs e) {
        base.OnResize(e);

        GL.Viewport(0, 0, e.Width, e.Height);

        World.RefreshRendering();
    }

    public void PassWindowSize(int handle) {
        GL.UseProgram(handle);
        GL.Uniform2(GL.GetAttribLocation(handle, "screenSize"), this.Size);
    }
}