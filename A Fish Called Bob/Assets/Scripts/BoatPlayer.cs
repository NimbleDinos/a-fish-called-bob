using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatPlayer : MonoBehaviour
{
    public GameObject Player, Boat;
    public bool controlBoat = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        



        if(controlBoat)
        {
            Player.SetActive(false);
            Boat.SetActive(true);
        }
        else
        {
            Boat.GetComponent<BoatController>().curSpeed = 0;
            Boat.GetComponent<BoatController>().ThrottleRef.Play("Throttle", 0, 0);
            Boat.GetComponent<BoatController>().throttle = 0;
            Player.SetActive(true);
            Boat.SetActive(false);
        }

        if (controlBoat && Input.GetKeyUp("e"))
        {
            controlBoat = false;
        }
    }
}
