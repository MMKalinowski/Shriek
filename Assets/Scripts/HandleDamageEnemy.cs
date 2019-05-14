using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDamageEnemy : MonoBehaviour
{
    public int life = 1;
    public UIControl ui;
    public PlayerController pc;

    public void Hit()
    {
        life--;

        if(life <= 0)
        {
            ui.incrementScore(10);
            pc.curentKills++;
            Destroy(gameObject);
        }
    }
}
