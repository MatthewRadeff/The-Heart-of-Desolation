using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveGenerator : MonoBehaviour
{

    public ObjectPooler m_lovePool;
    

    // distance between each pickup
    public float m_distanceBetweenPickups;

    // where pickups will be generated from 
    public void SpawnLovePickups(Vector3 startPosition)
    {
        // generating the pickup in the middle
        GameObject lovePickup = m_lovePool.GetPooledObject();
        lovePickup.transform.position = new Vector3(startPosition.x, startPosition.y + (m_distanceBetweenPickups / 1.5f), startPosition.z);
        lovePickup.SetActive(true);
        lovePickup.SetActiveRecursively(true);
        
        // generating the pickup on the left
        GameObject lovePickup2 = m_lovePool.GetPooledObject();
        lovePickup2.transform.position = new Vector3(startPosition.x - m_distanceBetweenPickups, startPosition.y, startPosition.z);
        lovePickup2.SetActive(true);
        lovePickup2.SetActiveRecursively(true);
       // generating the pickup on the right
        GameObject lovePickup3 = m_lovePool.GetPooledObject();
        lovePickup3.transform.position = new Vector3(startPosition.x + m_distanceBetweenPickups, startPosition.y, startPosition.z);
        lovePickup3.SetActive(true);
        lovePickup3.SetActiveRecursively(true);
        

    }

}
