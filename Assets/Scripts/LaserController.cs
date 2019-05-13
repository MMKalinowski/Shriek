using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public static float speed = 20;
    Vector2 dir;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    public void SetDir(Vector2 direction)
    {
        this.dir = direction;
    }

    private void FixedUpdate()
    {
        rb.velocity = dir * speed;

        if (transform.position.x > 95)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("pickup") && !collision.gameObject.CompareTag("Coin"))
        {
            if (collision.gameObject.GetComponent<HandleDamage>())
            {
                collision.gameObject.GetComponent<HandleDamage>().Hit();
            }
            if (collision.gameObject.GetComponent<HandleDamageEnemy>())
            {
                collision.gameObject.GetComponent<HandleDamageEnemy>().Hit();

            }

            Destroy(gameObject);
        }
    }
}
