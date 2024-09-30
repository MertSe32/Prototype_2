using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool ready = true;
    private float coolDownTime = 3.0f;
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && ready)
        {
            //Skill used, the player can't send dog now
            ready = !ready;

            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            //After 3 second, the player can't send dog again
            Invoke("CoolingDown", coolDownTime);
        }
    }

    void CoolingDown()
    {
        ready = !ready;
    }
}
