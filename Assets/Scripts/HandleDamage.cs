using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDamage : MonoBehaviour
{
    public PlayerController pc;

    public void Hit()
    {
        pc.LoseLife();
    }
}
