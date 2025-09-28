using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Will Spawn a Big Ball
    public GameObject ballPrefab;
    //Range on X-axis
    public float spawnRangeX = 10;
    //Position for spawn
    private float spawnPosY = 5;
    //Delay before 1st spawn
    private float startDelay = 2;
    //Time between Spawns
    private float spawnInterval = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnBalls", startDelay, spawnInterval);
    }

    //
    void SpawnBalls()   {
        //Random X positions within range
        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY);
        //Create Balls
        Instantiate(ballPrefab, spawnPos, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
