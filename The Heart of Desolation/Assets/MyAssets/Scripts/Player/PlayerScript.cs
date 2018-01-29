using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // speed of player
    public float m_playerSpeed;

    // amount multiplied to the current speed
    public float m_speedMultiplier;

    // distance to increase speed
    public float m_speedIncreaseMilestone;
    
    // used to keep track of every hit milestone
    private float m_speedMilestoneCount;

    // force of player jump
    public float m_jumpForce;

    // how long player can jump for
    public float m_jumpTime;
    private float m_jumpTimeCounter;


    // rigidbody of the player 
    private Rigidbody2D m_rb;

    // collider of player
    //private Collider2D m_collider2D;

    // check if on the ground
    public bool m_isGrounded;

    // selection of layers available ...player, ground, background
    public LayerMask m_whatIsGround;

    // the ground check
    public Transform m_groundCheck;

    // little circle at the bottom of the character to see if the player is grounded 
    // this helps check that the player can only jump if the feet are on top of the platform
    public float m_groundCheckRadius;

	// Use this for initialization
	void Start ()
    {
        // find rigidbody on player
        m_rb = GetComponent<Rigidbody2D>();

        // finds collider 2d on player
        //m_collider2D = GetComponent<Collider2D>();

        m_jumpTimeCounter = m_jumpTime;

        m_speedMilestoneCount = m_speedIncreaseMilestone;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        // checks if player colllider is touching the ground collider, then sets isgrounded to true or false
        //m_isGrounded = Physics2D.IsTouchingLayers(m_collider2D, m_whatIsGround);

        m_isGrounded = Physics2D.OverlapCircle(m_groundCheck.position, m_groundCheckRadius, m_whatIsGround);


        if (transform.position.x > m_speedMilestoneCount)
        {
            // increase speed when target point is reached
            m_speedMilestoneCount += m_speedIncreaseMilestone;

            // every new milestone will be able to match the speed multiplier
            // otherwise the player would be getting faster and faster and run out of platforms
            m_speedIncreaseMilestone = m_speedIncreaseMilestone * m_speedMultiplier;


            // increase speed by multiplier
            m_playerSpeed = m_playerSpeed * m_speedMultiplier;

        }

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
