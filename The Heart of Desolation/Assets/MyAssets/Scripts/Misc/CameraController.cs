using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // getting player script to know the last position of it
    public PlayerScript m_thePlayer;

    // players last position
    private Vector3 m_lastPlayerPosition;

    // camera distance to move
    private float m_distanceToMove;





	// Use this for initialization
	void Start ()
    {
        // finding the player script on the player
        m_thePlayer = FindObjectOfType<PlayerScript>();

        // initiallizes the position of the player and stores it 
        m_lastPlayerPosition = m_thePlayer.transform.position;


    }
	



	// Update is called once per frame
	void Update ()
    {
        // distance to move camera is .. our current position - our last position
        m_distanceToMove = m_thePlayer.transform.position.x - m_lastPlayerPosition.x;

        // we can say transform.position because this is already tied to the camera object
        // so we take our transform we already have and add the new distance to move
        // the y and z values will stay the same, not jumping with the player
        transform.position = new Vector3(transform.position.x + m_distanceToMove, transform.position.y, transform.position.z);


        // the position of player gets updated
        m_lastPlayerPosition = m_thePlayer.transform.position;

	}





}
