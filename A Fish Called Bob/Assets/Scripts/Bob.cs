using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour
{
    public SpawnFishItem obejctSpawner;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "FishingSpot")
        {
            Debug.Log("Collision between bob and fishing spot");
            int time = Random.Range(1, 10);
            //yield return new WaitForSeconds(time);
            Vector3 spawnPos = player.transform.position;
            spawnPos.y += 1.0f;
            obejctSpawner.CatchFish(spawnPos);
        }
    }
}
