using UnityEngine;

public sealed class CameraController : MonoBehaviour
{

    private const float DEATH_HEIGHT = 5.2f;

    private void LateUpdate()
    {
        if (DoodlerContorller.Instance == null)
            return;
        
       var target = DoodlerContorller.Instance.transform;
       if (target.position.y > transform.position.y)
       {
           var newPosition = transform.position;
           newPosition.y = target.position.y;
           transform.position = newPosition;
       }
       else if (target.position.y < transform.position.y - DEATH_HEIGHT)
            GameManager.Instance.GameOver();
    }
}