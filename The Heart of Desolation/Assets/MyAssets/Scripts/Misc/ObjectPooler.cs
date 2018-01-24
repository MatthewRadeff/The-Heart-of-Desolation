using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    // object being pooled
    public GameObject m_pooledObject;

    // amount of objects being pooled
    public int m_pooledAmount;

    // list of objects to be pooled
    public List<GameObject> m_pooledObjects;
    


	// Use this for initialization
	void Start ()
    {
        // new empty list
        m_pooledObjects = new List<GameObject>();

        for(int i = 0; i < m_pooledAmount; i++)
        {
            // want to fill list with the objects
            // using a GameObject cast to make sure the object going in is a game object
            GameObject m_obj = (GameObject)Instantiate(m_pooledObject);
            m_obj.SetActive(false);
            // adding object to our list
            m_pooledObjects.Add(m_obj);
        }

	}


    public GameObject GetPooledObject()
    {
        // loops through and finds object not active
        for(int i = 0; i < m_pooledObjects.Count; i++ )
        {
            if(!m_pooledObjects[i].activeInHierarchy)
            {
                // grab from list because is not active
                return m_pooledObjects[i];
            }
        }

        // created new free object
        GameObject m_obj = (GameObject)Instantiate(m_pooledObject);
        m_obj.SetActive(false);
        m_pooledObjects.Add(m_obj);

        return m_obj;

    }




}
