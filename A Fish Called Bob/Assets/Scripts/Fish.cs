using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public bool Increasing = true, Relaseed = false;
    public GameObject aim;
    public float dist = 5, min = 5, max = 15, castSpeed = 1;

    private LineRenderer lineRenderer;
    public GameObject maxLineEndpoint;
    public GameObject bob;
    private bool isCast = false;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && !isCast)
        {
            if (Increasing)
            {
                dist += Time.deltaTime * castSpeed;
                if (dist >= max)
                    Increasing = false;
            }
            else
            {
                dist -= Time.deltaTime * castSpeed;
                if (dist <= min)
                    Increasing = true;
            }

            aim.transform.position = transform.position + (transform.TransformDirection(Vector3.forward) * dist);
            aim.transform.position = new Vector3(aim.transform.position.x, 0, aim.transform.position.z);
        }


        if (Input.GetKeyUp("space") && !isCast)
        {
            isCast = true;
            Vector3 maxLineEnd = aim.transform.position; // maxLineEndpoint.transform.position;
            maxLineEnd.y = 0.1f;

            bob.transform.position = maxLineEnd;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, maxLineEnd);
            aim.transform.position = new Vector3(0, -5, 0);
            return;
        }

        if (Input.anyKeyDown && isCast)
        {
            ResetLine();
        } 
    }

    public void ResetLine()
    {
        isCast = false;
        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, Vector3.zero);
        bob.transform.position = transform.position;
    }
}
