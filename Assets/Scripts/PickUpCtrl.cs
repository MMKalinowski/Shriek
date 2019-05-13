using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCtrl : MonoBehaviour
{
    public UIControl ctrl;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            ctrl.incrementScore(45);
            collision.gameObject.GetComponent<PlayerController>().GainLife();
            Destroy(gameObject);
        }
    }
}
