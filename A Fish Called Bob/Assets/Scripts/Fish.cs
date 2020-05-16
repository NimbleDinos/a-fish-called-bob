using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public GameObject maxLineEndpoint;
    private bool isCast = false;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isCast);

        if (Input.GetKeyDown("space") && !isCast)
        {
            isCast = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, maxLineEndpoint.transform.position);
            return;
        }

        if (Input.anyKeyDown && isCast)
        {
            isCast = false;
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3.zero);
        } 
    }
}
