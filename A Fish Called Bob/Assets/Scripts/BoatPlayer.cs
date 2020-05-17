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
            Player.SetActive(true);
            Boat.SetActive(false);
        }
    }
}
