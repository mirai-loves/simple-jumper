using UnityEngine;

public class Platform : MonoBehaviour 
{
	private const string PLAYER_TAG = "Player";
	public int IndexOfType {get; set;}
	[SerializeField] private float bounceForce = 10f;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == PLAYER_TAG && collision.relativeVelocity.y <= 0f) 
			DoodlerContorller.Instance.BounceFromPlatform(bounceForce);
	}

	private void Update()
	{
		if (transform.position.y < PlatformSpawner.Instance.transform.position.y)
			Disable();
	}

	protected virtual void Disable()
	{
		PlatformSpawner.Instance.OnPlatformDisabled(this);
	}

	public virtual void ResetState(){}

}
