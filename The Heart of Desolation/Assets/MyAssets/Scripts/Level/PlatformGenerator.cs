using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    // platform being generated ahead oof player
    public GameObject m_thePlatform;

    // point in front of us that objects will be starting to generate
    public Transform m_generationPoint;

    // distance between each platform
    public float m_distanceBetween;

    // how wide platform is so a new platform doesnt spawn on top
    private float m_platformWidth;


    // the min and max of distance between each platform spawning
    public float m_distanceBetweenMin;
    public float m_distanceBetweenMax;



	// Use this for initialization
	void Start ()
    {
        // finds how wide the platform is getting the box collider size
        m_platformWidth = m_thePlatform.GetComponent<BoxCollider2D>().size.x;
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(transform.position.x < m_generationPoint.position.x)
        {
            // calculating a random distance to choose for the distance between platforms
            m_distanceBetween = Random.Range(m_distanceBetweenMin,m_distanceBetweenMax);

            // moving platform spawn location a certain distance from the last position taking in all the distances 
            transform.position = new Vector3(transform.position.x + m_platformWidth + m_distanceBetween, transform.position.y, transform.position.z);

            // creating the platform
            Instantiate(m_thePlatform, transform.position, transform.rotation);
            Debug.Log("Long platform created!");

        }

    }

}
