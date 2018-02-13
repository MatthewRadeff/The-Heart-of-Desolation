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

    // amount to subtract from love metre text and bar
    public int m_loveToSubtract;
    public float m_tempLoveToSubtract;

    // reference to manager
    private ScoreManager m_theScoreManager;

    // love pickup clip
    public AudioClip m_lovePickupClip;

    // memory hit clip
    public AudioClip m_memoryPickupClip;

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

        if(other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Love"))
        {
            // add value to score..bar and text
            m_theScoreManager.AddScore(m_loveToGive);
            m_theScoreManager.AddLove(m_loveToGive);
            m_theScoreManager.AddLoveMetre(m_tempLoveToGive);
            // because the object will be pooled we are setting it to set active false
            gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(m_lovePickupClip,transform.position);
        }
        if(other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Memory"))
        {
            m_theScoreManager.SubtractLove(m_loveToSubtract);
            m_theScoreManager.SubtractLoveMeter(m_tempLoveToSubtract);
            gameObject.SetActive(false);  
            AudioSource.PlayClipAtPoint(m_memoryPickupClip,transform.position);
            
        }
        
    }


}
