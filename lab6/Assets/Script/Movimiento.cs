using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public Sprite thiefMoney;
    int money = 0;
    public float jumpForce = 6.5f;
    
   


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0.0f)
            newScale.x = -1.0f;
        else if (Input.GetAxis("Horizontal") > 0.0f)
            newScale.x = 1.0f; //Para voltearlo

        transform.localScale = newScale;

        if (Input.GetButtonDown("Jump"))
            Jump();
    }

    private void FixedUpdate()
    {

        if (rb)
        {
            rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * 10, 0));
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
            Destroy(collision.gameObject);
            money = 1;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = thiefMoney;

        }
        else if (collision.CompareTag("Police") && money >= 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = thiefMoney;
            Destroy(collision.gameObject);
            
        }

        else if (collision.CompareTag("Police") && money < 1)
        {   
            Destroy(gameObject);
        }
            
    }

    private void Jump()
    {
        if (rb)
            if (Mathf.Abs(rb.velocity.y) < 0.05f)
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

 }

    
