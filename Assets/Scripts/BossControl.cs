using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossControl : MonoBehaviour
{
    public LayerMask ground;

    bool facingRight = true;
    Vector2 direction = new Vector2(-1, 0);
    float edge = 50f;
    public float speed = 5;

    bool toDie = false;

    private Rigidbody2D rb;
    AudioSource src;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        src = this.GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {

        if(toDie && !src.isPlaying)
        {
            SceneManager.LoadScene("end");
            Destroy(gameObject);
        }
        if (toDie)
        {
            direction *= 0;
        }

        if (transform.position.x > edge || transform.position.x < -edge)
        {
            direction *= -1;
        }

        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("attack"))
        {
            if (!toDie)
            {
                gameObject.GetComponent<AudioSource>().Play();
                toDie = true;
            }
        }
    }
}
