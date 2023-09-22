using OpenTK.Mathematics;

namespace chess;

public class Camera : ITransform, IEntity
{
    public Transform transform { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    //public event Action OnLoad;

    Matrix4 Projection;

    public Camera() {
    }

    public void FixedUpdate()
    {
        throw new NotImplementedException();
    }

    public void LateUpdate()
    {
        throw new NotImplementedException();
    }

    /*
        Not technically important for the rendering parameters; Refresh is called as well as Start.
    */
    public void Start()
    {
        
    }

    public void Update()
    {
        throw new NotImplementedException();
    }

    public void Refresh(Vector2 size) {
        Projection = Matrix4.CreateOrthographic(size.X, size.Y, 0.01f, 1000.0f);
    }
}