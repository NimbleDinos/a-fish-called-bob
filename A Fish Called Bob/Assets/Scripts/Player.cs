using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpawnFishItem spawner;
    public float moveSpeed = 5.0f;

    GameObject player;
    public CharacterController controller;

    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown("space"))
        //{
        //    Debug.Log("Space pressed");

        //    spawner.CatchFish(player.transform.position);
        //}

        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, Input.GetAxis("Vertical") * moveSpeed);
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), 0.15f);
        }

        moveDirection.y += Physics.gravity.y;

        controller.Move(moveDirection * Time.deltaTime);
    }
}
