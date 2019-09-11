using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float acceleration;
    public float jumpForce;
    public float jumpCooldown;

    bool isGrounded;

    private float timerJumpCooldown = 0f;

    private Rigidbody2D rb;
    private Collider2D col;
    private GroundDetector gd;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        gd = GetComponentInChildren<GroundDetector>();
        gd.Grounded += OnGrounded;
        gd.MovingPlatform += OnMovingPlatform;
    }

    private void OnMovingPlatform(bool on, GameObject go)
    {
        if (on)
            this.transform.SetParent(go.transform);
        else
            this.transform.SetParent(null);
    }

    private void OnGrounded(bool grounded)
    {
        if (grounded && rb.velocity.y <= 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
        isGrounded = grounded;
    }

    // Update is called once per frame
    private void Update()
    {
        var x = Time.deltaTime * acceleration * Input.GetAxis("Horizontal");
        if (Input.GetAxisRaw("Horizontal") == 0)
            x = 0;
        var y = Input.GetAxisRaw("Vertical");

        timerJumpCooldown += Time.deltaTime;
        if (y > 0 && isGrounded && timerJumpCooldown > jumpCooldown)
        {
            Jump();
        }

        var horizontalVelocity = Mathf.Clamp(x, -speed, speed);
        rb.velocity = new Vector3(horizontalVelocity, rb.velocity.y, 0);      
    }

    private void Jump() {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        timerJumpCooldown = 0;
    }
}
