using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour
{
    public SpawnFishItem objectSpawner;
    public GameObject player;
    public GameObject rodTip;
    public float moveSpeed = 10.0f;
    private Fish fish;

    private GameObject obj;
    private bool collision = false;

    // Start is called before the first frame update
    void Start()
    {
        fish = rodTip.GetComponent<Fish>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collision)
        {
            Debug.Log("Colliding");
            //obj.transform.position = Vector3.MoveTowards(obj.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            obj.GetComponent<Rigidbody>().AddForce(Vector3.MoveTowards(player.transform.position, obj.transform.position + Vector3.up, moveSpeed * Time.deltaTime));
            if (Vector3.Distance(obj.transform.position, player.transform.position) <= 1.0f)
            {
                collision = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log("Collision between bob and fishing spot");
        Debug.Log(other.gameObject.tag.ToString());
        if (other.gameObject.tag == "FishingSpot")
        {
            fish.ResetLine();
            Debug.Log("STUFF");
            obj = objectSpawner.CatchFish(other.transform.position);
            collision = true;
        }
    }
}
