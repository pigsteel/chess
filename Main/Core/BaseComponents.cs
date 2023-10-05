

using System.Numerics;

namespace chess;

public interface IRenderable {
    Mesh mesh {get; set;}
    
    public void Initialize();

    public void Render();
}

public interface ITransform {
    Transform transform {get; set;}
}

/// <summary>
/// Transform data, holds position and rotation of the object in space
/// </summary>
public class Transform
{
    /// <summary>
    /// Constructor of this transform
    /// </summary>
    public Transform() 
    {

    }

    public Vector2 Position { get { return Position; } set { Position = value; OnTransformUpdate?.Invoke(); } }

    public float Rotation;
    // Current scale of the object
    public Vector2 Scale { get; set; }

    public event Action OnTransformUpdate;
}