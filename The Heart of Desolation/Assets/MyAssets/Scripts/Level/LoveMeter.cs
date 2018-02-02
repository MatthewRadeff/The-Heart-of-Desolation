using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoveMeter : MonoBehaviour
{
    // amount of love given to the meter when player hits the heart/rose
    public int m_loveToGive;

    // for the metre bar
    public float m_tempLoveToGive;

    // reference to manager
    private ScoreManager m_theScoreManager;




	// Use this for initialization
	void Start ()
    {
        m_theScoreManager = FindObjectOfType<ScoreManager>();

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.CompareTag("Player"))
        {
            // add value to meter....?
            m_theScoreManager.AddScore(m_loveToGive);
            m_theScoreManager.AddLove(m_loveToGive);
            m_theScoreManager.AddLoveMetre(m_tempLoveToGive);
            gameObject.SetActive(false);
        }
        
    }


}
