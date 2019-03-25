using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRobotControl : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float jumpForce = 300f;
    public LayerMask ground;
    public Transform groundCheck;
    public float timeVar = 1;

    bool facingRight = true;
    bool isDead = false;
    int rightFace = -1;

    float currentJump = .0f;
    bool airborne = true;
    float groundRad = 0.2f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        if (!airborne && (int)Time.time % timeVar == 0)
        {
            //anim.SetBool("Air", true);
            currentJump = jumpForce;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector2(0, currentJump)); //possibly add an if
        currentJump = 0;

        airborne = !Physics2D.OverlapCircle(groundCheck.position, groundRad, ground);

        if (rb.velocity.SqrMagnitude() > 0 && !facingRight)
            Turn();
        else if (rb.velocity.SqrMagnitude() < 0 && facingRight)
            Turn();
    }

    void Turn()
    {
        facingRight = !facingRight;
        Vector3 scale = this.transform.localScale;
        scale.x *= -1;
        this.transform.localScale = scale;
    }
}
