namespace chess;

public abstract class GameObject : ITransform, IEntity, IRenderable
{
    public Transform transform { get; set; }
    public Renderer renderer { get; set; }

    public bool Awake {get; set;}

    public GameObject() {
        Awake = false;
    }

    public virtual void FixedUpdate()
    {
        
    }

    public virtual void Initialize()
    {
        
    }

    public virtual void LateUpdate()
    {
        
    }

    public virtual void Render() {
        
    }

    public virtual void Start()
    {
        renderer = new Renderer();
        renderer.Initialize(new Rendering.Shader("shader"));
    }

    public virtual void Update()
    {
        //throw new NotImplementedException();
    }
}