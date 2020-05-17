using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFishItem : MonoBehaviour
{
    public GameObject[] fishPrefab, bigFishPrefab;
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
            GameObject obj = Instantiate(fishPrefab[Random.Range(0, fishPrefab.Length)], position, Quaternion.identity);
            obj.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(0, 3, 0);
            obj.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255), 1f);
            Debug.Log(GameObject.FindGameObjectWithTag("Player").transform.position);
            return obj.gameObject;

        }
        else {
            GameObject obj = Instantiate(bigFishPrefab[Random.Range(0, bigFishPrefab.Length)], position, Quaternion.identity);
            obj.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(0, 3, 0);
            obj.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255), 1f);
            //obj.GetComponent<Rigidbody>().AddForce(((GameObject.FindGameObjectWithTag("Player").transform.TransformDirection(Vector3.forward) * -1 * 20) )); ;//(Vector3.MoveTowards(obj.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position + Vector3.up, 30))*10);
            return obj.gameObject;
        }
    }
}
