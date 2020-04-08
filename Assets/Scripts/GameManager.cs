using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] DoodlerContorller doodlerPrefab;

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        var doodler = Instantiate(doodlerPrefab);
        doodler.Init();
        
    }
}