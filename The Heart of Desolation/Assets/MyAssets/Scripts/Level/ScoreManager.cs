using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // the score of the game the player is playing
    public Text m_currentDays;
    public float m_currentDaysCount;
    
    // the highest score
    public Text m_longestDays;
    public float m_longestDaysCount;

    // everysecond the player is getting points
    public float m_pointsPerSecond;

    // checks if the score should be increasing or not
    public bool m_scoreIncreasing = true;


	// Use this for initialization
	void Start ()
    {
        //m_currentDaysCount = 0;

        if (PlayerPrefs.HasKey("LongestRelationship"))
        {
            m_longestDaysCount = PlayerPrefs.GetFloat("LongestRelationship");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(m_scoreIncreasing)
        {
            // updating the score points each second
            m_currentDaysCount += m_pointsPerSecond * Time.deltaTime;
            //PlayerPrefs.SetFloat("CurrentRelationship", m_currentDaysCount);
        }

       

        if(m_currentDaysCount > m_longestDaysCount)
        {

            m_longestDaysCount = m_currentDaysCount;
            PlayerPrefs.SetFloat("LongestRelationship", m_longestDaysCount);

        }


        // updating text
        m_currentDays.text = "Days in relationship: " + Mathf.Round(m_currentDaysCount) + " Days";
        m_longestDays.text = "Longest relationship: " + Mathf.Round(m_longestDaysCount) + " Days";


    }
}
