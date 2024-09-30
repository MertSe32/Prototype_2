using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;
    //[SerializeField] float minDelay = 3f;
    //[SerializeField] float maxDelay = 5f;

    // We create a variable that will track the next time we spawn a ball
    private float nextSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        // Since you want a delay, the first spawn time needs to be initialized so that it takes it into consideration
        nextSpawnTime = Time.time + startDelay;
    }

    // Update is called every frame
    void Update()
    {
        // If the current time is past the time we are supposed to spawn something, we do stuff
        if (Time.time >= nextSpawnTime)
        {
            // spawn ball
            SpawnRandomBall();

            // The next time we want a ball to spawn is our current time + cooldown
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        int ballIndex = Random.Range(0, ballPrefabs.Length);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }
}
//``````
