using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Vector2 secondsBetweenSpawnsMinMax ;
    [SerializeField] private Vector2 SpawnSizeMinMax;
    private float nextSpawnTime;
    
    
    private Vector2 _screenHalfWidth;
    // Start is called before the first frame update
    void Start()
    {
        var main = Camera.main;
        _screenHalfWidth = new Vector2( main.aspect * main.orthographicSize,main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.isGameActive)
        {
            if (Time.time>nextSpawnTime)
            {
                float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x,Difficulty.GetDificultyPercent());
                nextSpawnTime = Time.time + secondsBetweenSpawns;
                float spawnSize = Random.Range(SpawnSizeMinMax.x, SpawnSizeMinMax.y);
                Vector2 spawnPosition = new Vector2(Random.Range(-_screenHalfWidth.x, _screenHalfWidth.x),_screenHalfWidth.y+spawnSize/2);
                var obj = PoolController.Instance.GetFallingObject();//Instantiate(_prefab, spawnPosition, quaternion.identity);
                obj.transform.position = spawnPosition;
                obj.transform.localScale = Vector2.one * spawnSize;
                obj.SetActive(true);
            } 
        }
       
    }
}
