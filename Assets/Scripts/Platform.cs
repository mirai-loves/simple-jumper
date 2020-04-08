using UnityEngine;

public class Platform : MonoBehaviour 
{
	private const string PLAYER_TAG = "Player";

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == PLAYER_TAG && collision.relativeVelocity.y <= 0f) 
			DoodlerContorller.Instance.BounceFromPlatform();

	}

}
