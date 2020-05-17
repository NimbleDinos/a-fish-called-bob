using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFishItem : MonoBehaviour
{
    public GameObject fishPrefab, bigFishPrefab;
    int rand;

    public GameObject CatchFish(Vector3 position)
    {
        return ChoosePrefab(position);
    }

    private GameObject ChoosePrefab(Vector3 position)
    {
        rand = Random.Range(0, 100);
        if (rand >= 0 && rand <= 80)
        {
            GameObject obj = Instantiate(fishPrefab, position, Quaternion.identity);
            return obj.gameObject;
        }
        else {
            GameObject obj = Instantiate(bigFishPrefab, position, Quaternion.identity);
            return obj.gameObject;
        }
    }
}
