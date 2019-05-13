using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float maxX, minX, maxY, minY;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localPosition = target.localPosition + offset;
    }

    bool InBounds()
    {
        return true;
    }
}
