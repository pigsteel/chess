

using System.Numerics;

namespace chess;

public interface IEntity {
    public abstract void Start();

    public abstract void Update();

    public abstract void FixedUpdate();

    public abstract void LateUpdate();
}

public interface IRenderable {
    Renderer renderer {get; set;}

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
        Rotation = Quaternion.Identity;
    }

    public Vector3 Position { get { return Position; } set { Position = value; OnTransformUpdate?.Invoke(); } }

    public Quaternion Rotation
    { 
        get { return Rotation; }
        set 
        {
            Rotation = value;
            Up = Vector3.Transform(-Vector3.UnitY, Rotation);
            Right = Vector3.Transform(Vector3.UnitX, Rotation);
            Forward = Vector3.Transform(Vector3.UnitZ, Rotation);
            OnTransformUpdate?.Invoke();
        }
    }
    // Current scale of the object
    public Vector3 Scale { get; set; }

    // The Up, Foward, and Left vectors of this transform
    public Vector3 Up { get; set; }
    public Vector3 Forward { get; set; }
    public Vector3 Right { get; set; }

    public event Action OnTransformUpdate;
}