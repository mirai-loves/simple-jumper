using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    [SerializeField] DoodlerContorller doodlerPrefab;

    public static GameManager Instance {get; private set;}

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        var doodler = Instantiate(doodlerPrefab);
        doodler.Init();
        
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        DoodlerContorller.Instance.Die();
    }
}