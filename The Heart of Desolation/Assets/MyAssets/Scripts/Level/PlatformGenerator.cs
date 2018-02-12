using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    // platform being generated ahead of player
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

    // array of platforms
    //public GameObject[] m_thePlatforms;
    // which platform to use in array
    private int m_platformSelector;

    //widths between platforms
    private float[] m_platformWidths;

    // referencing the object pooler script
    public ObjectPooler[] m_theObjectPools;


    // height range to raise platforms
    private float m_minHeight;
    public Transform m_maxHeightPoint;
    private float m_maxHeight;
    public float m_maxHeightChange;
    private float m_heightChange;


    private LoveGenerator m_theLoveGenerator;
    private MemoryGenerator m_theMemoryGenerator;

    // determines whether or not to spawn the pickups...for randomness
    public float m_randomLovePickupThreshold;

    // determines whether or not to spawn the memories..random
    public float m_randomMemoryPickupThreshold;

	// Use this for initialization
	void Start ()
    {
        // finds how wide the platform is getting the box collider size
        //m_platformWidth = m_thePlatform.GetComponent<BoxCollider2D>().size.x;

        m_platformWidths = new float[m_theObjectPools.Length];

        for(int i = 0; i < m_theObjectPools.Length; i++)
        {
            // getting width of the pooled object
            m_platformWidths[i] = m_theObjectPools[i].m_pooledObject.GetComponent<BoxCollider2D>().size.x;

        }

        // getting min and max height to use for placement of platforms
        m_minHeight = transform.position.y;
        m_maxHeight = m_maxHeightPoint.position.y;

        // finding the only thing with the pickup generator
        m_theLoveGenerator = FindObjectOfType<LoveGenerator>();
        m_theMemoryGenerator = FindObjectOfType<MemoryGenerator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(transform.position.x < m_generationPoint.position.x)
        {
            // calculating a random distance to choose for the distance between platforms
            m_distanceBetween = Random.Range(m_distanceBetweenMin,m_distanceBetweenMax);

            // selecting a random platform in array
            m_platformSelector = Random.Range(0, m_theObjectPools.Length);

            // getting the random height change 
            m_heightChange = transform.position.y + Random.Range(m_maxHeightChange, -m_maxHeightChange);

            // making sure the platforms arent spawning off the screen
            if(m_heightChange > m_maxHeight)
            {
                // making sure its not too high
                m_heightChange = m_maxHeight;
            }
            else if(m_heightChange < m_minHeight)
            {
                // making sure its not too low
                m_heightChange = m_minHeight;
            }


            // moving platform spawn location a certain distance from the last position taking in all the distances 
            // dividing by 2 makes the spawn location occur at the end of the platform, so at least no overlapping happens
            transform.position = new Vector3(transform.position.x + (m_platformWidths[m_platformSelector] / 2) + m_distanceBetween, m_heightChange, transform.position.z);


            // creating the platform
            //Instantiate(/*m_thePlatform*/m_theObjectPools[m_platformSelector], transform.position, transform.rotation);
            //Debug.Log("Long platform created!");

            // creating "new platform" from using the pooling
            // setting position rotation 
            GameObject m_newPlatform = m_theObjectPools[m_platformSelector].GetPooledObject();
            m_newPlatform.transform.position = transform.position;
            m_newPlatform.transform.rotation = transform.rotation;
            // also setting it to true because up until now it has been not active
            m_newPlatform.SetActive(true);



            if(Random.Range(0f,100f) < m_randomLovePickupThreshold)
            {
                m_theLoveGenerator.SpawnLovePickups(new Vector3(transform.position.x,transform.position.y + 2.0f, transform.position.z));

            }
            else if(Random.Range(0f, 100f) < m_randomMemoryPickupThreshold)
            {
                m_theMemoryGenerator.SpawnMemoryPickups(new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z));
            }
            

            // adding on half the distance from where the last platform was so the platforms dont overlap
            transform.position = new Vector3(transform.position.x + (m_platformWidths[m_platformSelector] / 2), transform.position.y, transform.position.z);


        }

    }

}