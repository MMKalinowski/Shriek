﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCtrl : MonoBehaviour
{
    public CoinControl ctrl;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision detected");
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Destroy(gameObject);
            ctrl.score += 30;
        }
    }
}