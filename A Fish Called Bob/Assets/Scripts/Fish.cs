using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public GameObject maxLineEndpoint;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log(transform.position);
            Debug.Log(maxLineEndpoint.transform.position);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, maxLineEndpoint.transform.position);
        }
    }
}
