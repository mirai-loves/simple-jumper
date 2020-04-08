using UnityEngine;
using System.Collections.Generic;

public sealed class PlatformSpawner : MonoBehaviour 
{
    [SerializeField] private PlatformSpawnData[] platformSpawnData;
    [SerializeField] private float levelWidth = 3f;
    [SerializeField] private float minY = 0.2f;
    [SerializeField] private float maxY = 1.5f;
    private Queue<Platform>[] platformPool;
    private const int RANDOM_SAMPLE_RANGE = 10;
    private const int MAX_PLATFORM_COUNT = 20;
    public static PlatformSpawner Instance {get; private set;}
    private bool isSpawning;
    private Vector3 spawnPosition;
    private int[] randomSample;
    private System.Random random;

    private void Awake()
    {
        Instance = this;
    }

    public void StartSpawning(string seed)
    {
        isSpawning = true;
        spawnPosition = Vector3.zero;
        random = new System.Random(seed.GetHashCode());
        GenerateRandomSample();

        platformPool = new Queue<Platform>[platformSpawnData.Length];
        for (var i = 0; i < platformSpawnData.Length; ++i)
            platformPool[i] = new Queue<Platform>();
        
        for (var i = 0; i < MAX_PLATFORM_COUNT; ++i)
            SpawnRandomPlatform();
        
    }

    public void OnPlatformDisabled(Platform platform)
    {
        platform.gameObject.SetActive(false);
        var type = platform.IndexOfType;
        platformPool[type].Enqueue(platform);
        SpawnRandomPlatform();
    }

    private void GenerateRandomSample()
    {
        var length = 0;
        foreach(var platformType in platformSpawnData)
            length += Mathf.FloorToInt(platformType.SpawnChance * RANDOM_SAMPLE_RANGE);
        randomSample = new int[length];

        var index = 0;
        for(var i = 0; i < platformSpawnData.Length; ++i)
        {
            var count = Mathf.FloorToInt(platformSpawnData[i].SpawnChance * RANDOM_SAMPLE_RANGE);
            if (count == length)
                count--;

            for (var j = index; j < index + count; ++j)
                randomSample[j] = i;
            
            index += count;
        }

#if DEBUG
        var res = new System.Text.StringBuilder("Random sample: ");
        foreach(var num in randomSample)
            res.Append(num.ToString() + ", ");
        Debug.Log(res.ToString());
#endif
    }

    private void SpawnPlatform(int type)
    {
        var prefab = platformSpawnData[type].PlatformPrefab;
        spawnPosition.y += Random.Range(minY, maxY);
        spawnPosition.x = Random.Range(-levelWidth, levelWidth);

        if (platformPool[type].Count == 0)
        {
            var platform = Instantiate(prefab, spawnPosition, Quaternion.identity);
            platform.IndexOfType = type;
        }else
        {
            var platform = platformPool[type].Dequeue();
            platform.ResetState();
            platform.gameObject.SetActive(true);
            platform.gameObject.transform.position = spawnPosition;
        }
    }

    private void SpawnRandomPlatform()
    {
        SpawnPlatform(randomSample[random.Next(0, randomSample.Length - 1)]);
    }
}