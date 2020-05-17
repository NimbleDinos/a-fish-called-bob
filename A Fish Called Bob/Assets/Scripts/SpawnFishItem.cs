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
            Debug.Log(GameObject.FindGameObjectWithTag("Player").transform.position);
            obj.GetComponent<Rigidbody>().AddForce((GameObject.FindGameObjectWithTag("Player").transform.forward * -1 +  (Vector3.up * 2.5f)) * 15);//(Vector3.MoveTowards(obj.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position + Vector3.up, 30))*10);
            return obj.gameObject;
        }
        else {
            GameObject obj = Instantiate(bigFishPrefab, position, Quaternion.identity);
            return obj.gameObject;
        }
    }
}
