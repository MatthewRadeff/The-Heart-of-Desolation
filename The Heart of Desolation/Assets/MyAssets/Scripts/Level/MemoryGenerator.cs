using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGenerator : MonoBehaviour
{

    public ObjectPooler m_memoryPool;


    // distance between each pickup
    public float m_distanceBetweenPickups;


    public void SpawnMemoryPickups(Vector3 startPosition)
    {
        // generating the pickup in the middle
        GameObject m_memoryPickup = m_memoryPool.GetPooledObject();
        m_memoryPickup.transform.position = startPosition;
        m_memoryPickup.SetActive(true);
        m_memoryPickup.SetActiveRecursively(true);

       /* // generating the pickup on the left
        GameObject m_memoryPickup2 = m_memoryPool.GetPooledObject();
        m_memoryPickup2.transform.position = new Vector3(startPosition.x - m_distanceBetweenPickups, startPosition.y, startPosition.z);
        m_memoryPickup2.SetActive(true);

        // generating the pickup on the right
        GameObject m_memoryPickup3 = m_memoryPool.GetPooledObject();
        m_memoryPickup3.transform.position = new Vector3(startPosition.x + m_distanceBetweenPickups, startPosition.y, startPosition.z);
        m_memoryPickup3.SetActive(true);
        */
    }



}
