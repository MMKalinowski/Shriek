using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float jumpForce = 500f;
    public LayerMask ground;
    public Transform groundCheck;
    public Transform spawnPoint;
    public Transform smug;
    public CoinControl ctrl;

    Animator anim;

    bool facingRight = true;
    bool isDead = false;
    bool crossed = false;
    int rightFace = -1;
    uint jumpsLeft = 1;

    bool airborne = true;
    float groundRad = 0.2f;

    float currentJump = .0f;

    private Rigidbody2D rb;
    private string bonusText = "";
    private string scoreText = "Score: ";

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckIfKilled(collision);
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector2(0, currentJump)); //possibly add an if
        currentJump = 0;

        airborne = !Physics2D.OverlapCircle(groundCheck.position, groundRad, ground);
        anim.SetBool("Air", airborne);
        anim.SetFloat("vSpeed", rb.velocity.y);

        if (!airborne)
            jumpsLeft = 1;

        float speed = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(speed));
        
        rb.velocity = new Vector2(speed * maxSpeed, rb.velocity.y);

        if (speed > 0 && !facingRight)
            Turn();
        else if (speed < 0 && facingRight)
            Turn();

        if(transform.position.y < -25f || /*transform.position.x < -34f ||*/ isDead)
        {
            rb.velocity = Vector2.zero;
            transform.position = spawnPoint.position;
            isDead = false;
        }
    }

    void Turn()
    {
        facingRight = !facingRight;
        Vector3 scale = this.transform.localScale;
        scale.x *= -1;
        this.transform.localScale = scale;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (!airborne || jumpsLeft > 0))
        {
            if(airborne)
                jumpsLeft--;

            anim.SetBool("Air", true);
            currentJump = jumpForce;
        }
    }

    void CheckIfKilled(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector3 enemy = collision.transform.position;
            if (Mathf.Abs(this.transform.position.x - enemy.x) < 1.5f && (this.transform.position.y - enemy.y < -2))
            {
                crossed = false;
                isDead = !isDead;
                bonusText = "";
            }
        }
    }

    //TODO: MOVE IT SOMEWHERE ELSE
    private void OnGUI()
    {
        if (transform.position.x < -34f && !crossed)
        {
            bonusText = "Please don't go there.";
        }

        if (transform.position.x < -81f)
        {
            crossed = true;
            bonusText = "Wow, well done, good luck getting back.";
            smug.gameObject.SetActive(true);
        }

        if(crossed && transform.position.x > -29f)
        {
            bonusText = "I'm impressed, grab some bonus points.";
            ctrl.bonus(100);
            crossed = !crossed;
        }

        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), bonusText);
        GUI.Label(new Rect(Screen.width - 150, 0, Screen.width, Screen.height), scoreText + ctrl.score);
    }
}
