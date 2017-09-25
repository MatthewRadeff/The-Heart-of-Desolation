using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestruction : MonoBehaviour
{
    // point where platforms will be destroyed
    public GameObject m_platformDestructionPoint;


	// Use this for initialization
	void Start ()
    {
        m_platformDestructionPoint = GameObject.Find("DestructionPoint");


	}
	
	// Update is called once per frame
	void Update ()
    {
		if(transform.position.x < m_platformDestructionPoint.transform.position.x)
        {
            Destroy(gameObject);
            Debug.Log("Platform destroyed!");


        }


	}

}
