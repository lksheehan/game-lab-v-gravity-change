using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    public float JumpSpeed;
    public bool onGround;
    public float force;

    public bool gravity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed, 0, 0);
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed, 0, 0);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround)
            {
                print("jump!");
                rb.AddForce(new Vector3(0f, -JumpSpeed, 0f), ForceMode2D.Impulse);
                //rb.AddTorque(Random.Range(-50, 50));
                onGround = false;
                //AudioSource.PlayOneShot(Jump);
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (gravity == true)
            {
                rb.gravityScale *= -1;
                gravity = false;
            }
            if (gravity == false)
            {
                rb.gravityScale *= 1;
                gravity = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("colliding");
          onGround = true;
        }
    }

}
