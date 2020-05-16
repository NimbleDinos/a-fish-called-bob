using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFishItem : MonoBehaviour
{
    public GameObject fishPrefab, bigFishPrefab;
    int rand;

    public void CatchFish(Vector3 position)
    {
        ChoosePrefab(position);
    }

    private void ChoosePrefab(Vector3 position)
    {
        rand = Random.Range(0, 100);

        if (rand >= 0 && rand <= 80) Instantiate(fishPrefab, position, Quaternion.identity);
        else Instantiate(bigFishPrefab, position, Quaternion.identity);
    }
}
