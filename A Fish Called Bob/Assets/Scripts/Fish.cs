using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
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
        if (Input.GetKeyDown("space") && !isCast)
        {
            isCast = true;
            Vector3 maxLineEnd = maxLineEndpoint.transform.position;
            maxLineEnd.y = 0.1f;

            bob.transform.position = maxLineEnd;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, maxLineEnd);
            return;
        }

        if (Input.anyKeyDown && isCast)
        {
            isCast = false;
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3.zero);
            bob.transform.position = transform.position;
        } 
    }
}
