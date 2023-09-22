using OpenTK.Graphics.OpenGL;
using System;
using System.IO;
using System.Text;
using OpenTK.Mathematics;

namespace chess.Rendering
{
    /// <summary>
    /// The shader handler that compiles the shaders at runtime
    /// </summary>
    public class Shader
    {
        private int handle;
        public string name { get; set; }

        /// <summary>
        /// Shader constructor
        /// </summary>
        /// <param name="vertexPath">Path of the vertex shader</param>
        /// <param name="fragmentPath">Path of the fragment shader</param>
        public Shader(string name)
        {
            handle = ResourceLoader.RequestShaderPipeline(name);
            this.name = name;
        }

        /// <summary>
        /// Use this shader before rendering an object
        /// </summary>
        public void Use() { GL.UseProgram(handle); }

        /// <summary>
        /// Get an attribute location from it's name
        /// </summary>
        /// <param name="attribName">The attribute name</param>
        /// <returns></returns>
        public int GetAttribLocation(string attribName) { return GL.GetAttribLocation(handle, attribName); }

        /// <summary>
        /// Get a uniform location from it's name
        /// </summary>
        /// <param name="uniformName">The uniform name</param>
        /// <returns></returns>
        public int GetUniformLocation(string uniformName) { return GL.GetUniformLocation(handle, uniformName); }

        #region Set Uniforms        

        // Sets a uniform float
        public void SetFloat(int location, float value) { GL.Uniform1(location, value); }
        // Sets a uniform int
        public void SetInt(int location, int value) { GL.Uniform1(location, value); }
        // Sets a uniform Vector2
        public void SetVector2(int location, Vector2 value) { GL.Uniform2(location, value.X, value.Y); }
        // Sets a uniform Vector3
        public void SetVector3(int location, Vector3 value) { GL.Uniform3(location, value.X, value.Y, value.Z); }
        // Sets a uniform Vector4
        public void SetVector4(int location, Vector4 value) { GL.Uniform4(location, value.X, value.Y, value.Z, value.W); }
        // Sets a uniform Matrix4
        public void SetMatrix4(int location, Matrix4 value) { GL.UniformMatrix4(location, false, ref value); }

        #endregion  

        /// <summary>
        /// Dispose of this shader
        /// </summary>
        public void Dispose() { GL.DeleteProgram(handle); }

        /// <summary>
        /// Destructor
        /// </summary>
        //~Shader() { GL.DeleteProgram(handle); }
    }
}
