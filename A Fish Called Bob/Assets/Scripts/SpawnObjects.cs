using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject fishingSpot;
    int numFishSpots = Random.Range(1, 10);

    void Start()
    {
        Vector3 center = transform.position;

        for (int i = 0; i < numFishSpots; i++)
        {
            Vector3 pos = RandomCircle(center, 100f);
            //Quaternion rot = Random.rotation;
            var fishSpot = Instantiate(fishingSpot, pos, Quaternion.identity);
            fishSpot.transform.parent = transform;
        }

        //InvokeRepeating("SpawnMore", 10.0f, 10.0f);
    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        return pos;
    }

    void SpawnMore()
    {
        Vector3 center = transform.position;
        int chance = Random.Range(1, 100);

        if (chance == 100)
        {
            Vector3 pos = RandomCircle(center, 100f);
            var fishSpot = Instantiate(fishingSpot, pos, Quaternion.identity);
            fishSpot.transform.parent = transform;
        }
    }
}
