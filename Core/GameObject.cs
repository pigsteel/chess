namespace chess;

public abstract class GameObject
{
    public bool Awake {get; set;}

    public GameObject() {
        Awake = false;
    }

    public virtual void FixedUpdate()
    {
        
    }

    public virtual void LateUpdate()
    {
        
    }

    public virtual void Start()
    {

    }

    public virtual void Update()
    {
        
    }
}