using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public GameObject BoatSwitcher, CameraObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("e"))
        {
            Ray ray = new Ray();
            RaycastHit hit;

            ray.direction = CameraObj.transform.TransformDirection(Vector3.forward);
            ray.origin = transform.position;

            if (Physics.Raycast(ray, out hit, 10))
            {
                Debug.DrawRay(CameraObj.transform.position, CameraObj.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log(hit.collider.name);
                if(hit.collider.name == "Door")
                {
                    hit.collider.GetComponent<Animator>().SetBool("Open", !hit.collider.GetComponent<Animator>().GetBool("Open"));
                }
                if(hit.collider.name == "Wheel")
                {
                    BoatSwitcher.GetComponent<BoatPlayer>().controlBoat = true;
                }
            }
        }

        

        Vector3 motion = new Vector3();
        if (Input.GetKey("w"))
            motion += CameraObj.transform.TransformDirection(Vector3.forward);
        else if (Input.GetKey("s"))
            motion += CameraObj.transform.TransformDirection(Vector3.forward * -1);

        if (Input.GetKey("a"))
            motion += CameraObj.transform.TransformDirection(Vector3.right * -1 );
        else if (Input.GetKey("d"))
            motion += CameraObj.transform.TransformDirection(Vector3.right );

        motion.y = Physics.gravity.y;
        motion *= Time.deltaTime * 5;
        GetComponent<CharacterController>().Move(motion);



    }
}