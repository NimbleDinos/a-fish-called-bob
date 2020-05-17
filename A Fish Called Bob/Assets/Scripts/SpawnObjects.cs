using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject fishingSpot;
    public GameObject[] rock;

    void Start()
    {
        int numFishSpots = Random.Range(1, 10);
        int numRocks = Random.Range(0, 5);

        Vector3 center = transform.position;

        for (int i = 0; i < numFishSpots; i++)
        {
            Vector3 pos = RandomCircle(center, 100f);
            var fishSpot = Instantiate(fishingSpot, pos, Quaternion.identity);
            fishSpot.transform.parent = transform;
        }

        for (int i = 0; i < numRocks; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-360, 360), 0, Random.Range(-360, 360));

            if (pos.x < 15 && pos.x > -15)
                pos.x = 32;
            if (pos.z < 15 && pos.z > -15)
                pos.z = 22;
            var rocks = Instantiate(rock[Random.Range(0,rock.Length)]);
            //var rocks = Instantiate(rock, pos, Quaternion.Euler(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360))));
            //rocks.transform.rotation = Random.rotation;
            //rocks.transform.eulerAngles = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100));
            //rocks.transform.parent = transform;
            rocks.transform.position = pos;
            Vector3 rot = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            rocks.transform.Rotate(rot);
            rocks.transform.localScale = Vector3.one * (Random.Range(0,30) * 0.25f);
        }

        InvokeRepeating("SpawnMore", 10.0f, 10.0f);
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

    private void SpawnMore()
    {
        Vector3 center = transform.position;
        int chance = Random.Range(1, 100);

        if (chance == 100)
        {
            Debug.Log("Spawning more spots");
            Vector3 pos = RandomCircle(center, 100f);
            var fishSpot = Instantiate(fishingSpot, pos, Quaternion.identity);
            fishSpot.transform.parent = transform;
        }
    }
}
