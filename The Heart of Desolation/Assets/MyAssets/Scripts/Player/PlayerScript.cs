using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // speed of player
    public float m_playerSpeed = 5.0f;

    // force of player jump
    public float m_jumpForce = 10.0f;

    // how long player can jump for
    public float m_jumpTime;
    private float m_jumpTimeCounter;


    // rigidbody of the player 
    private Rigidbody2D m_rb;

    // collider of player
    private Collider2D m_collider2D;

    // check if on the ground
    public bool m_isGrounded;

    // selection of layers available ...player, ground, background
    public LayerMask m_whatIsGround;


	// Use this for initialization
	void Start ()
    {
        // find rigidbody on player
        m_rb = GetComponent<Rigidbody2D>();

        // finds collider 2d on player
        m_collider2D = GetComponent<Collider2D>();

        m_jumpTimeCounter = m_jumpTime;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        // checks if player colllider is touching the ground collider, then sets isgrounded to true or false
        m_isGrounded = Physics2D.IsTouchingLayers(m_collider2D, m_whatIsGround);



        // the constant speed of the character moving right
        m_rb.velocity = new Vector2(m_playerSpeed,m_rb.velocity.y);

        // character jumps when space is hit
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // checks if grounded.. if true u can jump..if not then u cant jump again 
            if(m_isGrounded)
            {
                // values for jumping
                m_rb.velocity = new Vector2(m_rb.velocity.x, m_jumpForce);
                Debug.Log("Player jumped!");
            }

            Debug.Log("Player cant jump!");

        }

        if(Input.GetKey(KeyCode.Space))
        {
            if(m_jumpTimeCounter > 0)
            {
                m_rb.velocity = new Vector2(m_rb.velocity.x, m_jumpForce);
                m_jumpTimeCounter -= Time.deltaTime;
            }

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            m_jumpTimeCounter = 0;
        }

        if(m_isGrounded)
        {
            m_jumpTimeCounter = m_jumpTime;
        }


    }


}
