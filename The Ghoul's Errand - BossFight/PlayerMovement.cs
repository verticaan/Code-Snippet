using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float dashDistance = 5f;
    public float dashTime = 0.2f;
    public float dashCooldown = 2f;

    private Rigidbody2D rb;
    private float dashTimer = 0f;
    private bool isDashing = false;
    private Vector2 dashDirection = Vector2.zero;


    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Update is called once per frame
    void Update()
    {
        // Check for input
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        // Handle dashing
        if (Input.GetKeyDown(KeyCode.Space) && dashTimer <= 0f)
        {
            isDashing = true;
            dashDirection = new Vector2(xInput, yInput).normalized;
            dashTimer = dashTime;
        }

        if (isDashing)
        {
            rb.velocity = dashDirection * dashDistance / dashTime;
            dashTimer -= Time.deltaTime;

            if (dashTimer <= 0f)
            {
                isDashing = false;
                rb.velocity = Vector2.zero;
            }
        }

        // Handle movement
        if (!isDashing)
        {
            rb.velocity = new Vector2(xInput, yInput).normalized * moveSpeed;
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); //used the mouse location to position the mouse

    }

    private void FixedUpdate() //since physics can be affected by change in framerate, I used a fixed update.
    {
        if (!isDashing)
        {
            rb.MovePosition(rb.position + rb.velocity * Time.fixedDeltaTime); //movement will be called here
        }


        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
