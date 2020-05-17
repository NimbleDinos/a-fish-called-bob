using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public Animator ThrottleRef, SteeringRef;
    public GameObject Boat;

    public float steeringAngle = 0, throttle = 0, speed = 15, curSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
       // AnimationRef = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        steeringAngle = (Input.GetAxis("Horizontal") + 1) / 2 ;

        ThrottleRef.Play("Throttle", 0, throttle);
        SteeringRef.Play("Steering", 0, steeringAngle);

        throttle += Input.GetAxis("Vertical") * Time.deltaTime;

        GetComponent<AudioSource>().volume = throttle;

        throttle = Mathf.Clamp(throttle, 0, .95f);

        curSpeed += (throttle - curSpeed) * Time.deltaTime;

        Boat.GetComponent<Transform>().position = Boat.GetComponent<Transform>().position + (Boat.transform.forward * -1 * speed * curSpeed * Time.deltaTime);

        Vector3 turn = Vector3.up * (steeringAngle - .5f) * curSpeed;
        Boat.GetComponent<Transform>().Rotate(turn);
    }
}
