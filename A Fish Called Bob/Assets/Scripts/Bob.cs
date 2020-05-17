using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour
{
    public SpawnFishItem objectSpawner;
    public GameObject player;
    public GameObject rodTip;
    public float moveSpeed = 1000.0f;

    private Fish fish;
    private GameObject obj;
    private bool timeWaited = false;
    private float startTime;
    private int randTime;

    // Start is called before the first frame update
    void Start()
    {
        fish = rodTip.GetComponent<Fish>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        startTime = Time.realtimeSinceStartup;
        randTime = Random.Range(1, 10);
        timeWaited = false;
    }

    void OnTriggerStay(Collider other)
    {
        if ((Time.realtimeSinceStartup >= startTime + randTime) && timeWaited == false)
        {
            if (other.gameObject.tag == "FishingSpot")
            {
                timeWaited = true;
                fish.ResetLine();
                Debug.Log("STUFF");
                obj = objectSpawner.CatchFish(other.transform.position);
                obj.GetComponent<Rigidbody>().AddForce(Vector3.MoveTowards(obj.transform.position, player.transform.position + Vector3.up, moveSpeed));
                Destroy(other.gameObject);
            }
        }
    }
}
