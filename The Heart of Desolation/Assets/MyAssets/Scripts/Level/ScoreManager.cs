using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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


    // love meter % number
    private float m_loveMeterAmount = 100.0f;
    public Text m_loveMeterText;

    // the love meter and its value
    public Image m_loveMeter;
    private float m_tempMeterAmount = 1.0f;




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


        if(m_loveMeterAmount > 0)
        {
            // % goes down a little amount each second
            m_loveMeterAmount -= (0.05f * 100.0f) * Time.deltaTime;
            m_loveMeterText.text = m_loveMeterAmount.ToString("f0");

            // the love meter bar also has to go down
            m_tempMeterAmount -= (0.05f) * Time.deltaTime;
            m_loveMeter.fillAmount = m_tempMeterAmount;

        }
        if(m_loveMeterAmount >= 100.0f)
        {
            m_loveMeterAmount = 100.0f;

        }
        else if(m_loveMeterAmount <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        


    }

    public void AddScore(int daysToAdd)
    {
        m_currentDaysCount += daysToAdd;
    }

    public void AddLove(int loveToAdd)
    {
        m_loveMeterAmount += loveToAdd;
        m_loveMeterText.text = m_loveMeterAmount.ToString("f0");

    }
    public void AddLoveMetre(float metreToAdd)
    {
        m_tempMeterAmount += metreToAdd;
        m_loveMeter.fillAmount = m_tempMeterAmount;
    }



}
