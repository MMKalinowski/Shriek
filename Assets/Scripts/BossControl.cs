using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour
{
    public LayerMask ground;

    bool facingRight = true;
    Vector2 direction = new Vector2(-1, 0);
    float edge = 50f;
    public float speed = 5;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(transform.position.x > edge || transform.position.x < -edge)
        {
            direction *= -1;
        }

        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("attack"))
        {
            Destroy(gameObject);
            //win

            //Vector3 enemy = collision.transform.position;
            //if (Mathf.Abs(this.transform.position.x - enemy.x) < 10f && (this.transform.position.y - enemy.y < -20))
            //{
            //    Destroy(gameObject);
            //}
        }
    }
}
