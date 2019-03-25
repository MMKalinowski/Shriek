using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera playerCam;
    public Transform target;
    public Vector3 offset;
    public float maxX, minX, maxY, minY;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerCam.transform.localPosition = target.localPosition + offset;
    }

    bool InBounds()
    {
        return true;
    }
}
