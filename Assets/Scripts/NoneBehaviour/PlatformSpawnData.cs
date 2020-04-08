using System;
using UnityEngine;

[Serializable]
public class PlatformSpawnData
{
    [SerializeField] private Platform platformPrefab;
    public Platform PlatformPrefab 
    {
        get {return platformPrefab;}
    }
    
    [Range(0, 1)]
    [SerializeField] private float spawnChance;
    public float SpawnChance
    {
        get {return spawnChance;}
    }
}
