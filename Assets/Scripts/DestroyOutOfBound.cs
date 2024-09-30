using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private float topBoundZ = 30.0f;
    private float lowerBoundZ = -10.0f;
    private float boundX = 40.0f;
    private int lives = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //If an object goes past the player view in the game, remove that object.(For Z spawner)
        if (transform.position.z > topBoundZ)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBoundZ)
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }

        //İf an object goes past the player view in the game, remove that object.(For X spawner)
        if (transform.position.x < -boundX || transform.position.x > boundX)
        {
            ReduceLife();
            Destroy(gameObject);
        }
        
        void ReduceLife()
        {
            lives--;
            Debug.Log("lives:" + lives);

            if(lives == 0)
            {
                Debug.Log("Game Over");
            }
        }

    }
}
