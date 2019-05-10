using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCount : MonoBehaviour
{
    public Text fpstxt;

    float deltaTime = 0f;
    float fps = 0f;

    public void Update()
    {
        deltaTime += Time.deltaTime;
        deltaTime /= 2.0f;
        fps = 1.0f / deltaTime;

        fpstxt.text = ((int)fps).ToString();
    }
}
