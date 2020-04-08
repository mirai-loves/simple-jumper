using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class  DoodlerContorller : MonoBehaviour
{
    public static DoodlerContorller Instance {get; private set;}
    [SerializeField] private float movementSpeed = 6f;
    private Rigidbody2D rigidBody;
    //private IInputMethod input = AccelerometerInput.Instance;
    private IInputMethod input;

    public void Init()
    {
        Instance = this;
        rigidBody = GetComponent<Rigidbody2D>();
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        input = AccelerometerInput.Instance;
#else
        input = PcInput.Instance;
#endif
    }

    private void Update()
    {
        input.CollectInput();
    }

    private void FixedUpdate()
    {
        var velocity = rigidBody.velocity;
        velocity.x = input.HorizontalAxis * movementSpeed;
        rigidBody.velocity = velocity;
    }

    public void BounceFromPlatform(float bounceForce = 10f)
	{
		var velocity = rigidBody.velocity;
	    velocity.y = bounceForce;
	    rigidBody.velocity = velocity;	
    }

    public void Die()
    {
        DoodlerContorller.Instance = null;
        Destroy(gameObject);
    }
}