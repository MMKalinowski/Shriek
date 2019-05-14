using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float maxX, minX, maxY, minY;

    bool zoomedOut = false;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name.Equals("boss") && !zoomedOut)
        {
            if (gameObject.GetComponent<Camera>())
            {
                gameObject.GetComponent<Camera>().orthographicSize += 5;
            }
            zoomedOut = !zoomedOut;
        }

        transform.localPosition = target.localPosition + offset;
    }

    bool InBounds()
    {
        return true;
    }
}
