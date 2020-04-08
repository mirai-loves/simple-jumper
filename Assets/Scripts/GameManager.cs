using UnityEngine;
using System.Text;

public sealed class GameManager : MonoBehaviour
{
    [SerializeField] DoodlerContorller doodlerPrefab;
    private const int SEED_LEN = 8;
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
        var seed = GenerateSeed();
        Debug.Log(string.Format("Game started with seed: {0}", seed));
        Random.InitState(seed.GetHashCode());
        var doodler = Instantiate(doodlerPrefab);
        doodler.Init();
        PlatformSpawner.Instance.StartSpawning(seed);
        
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        DoodlerContorller.Instance.Die();
    }

    private string GenerateSeed()
	{
		var seed = new StringBuilder();
		const string accessableChars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890";
		for (var i = 0; i < SEED_LEN; ++i)
			seed.Append(accessableChars[Random.Range(0, accessableChars.Length)]);
		return seed.ToString();

	}
}