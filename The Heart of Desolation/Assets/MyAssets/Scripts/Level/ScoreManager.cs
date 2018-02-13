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
    public float m_loveMeterAmount = 100.0f;
    public Text m_loveMeterText;

    // the love meter and its value
    public Image m_loveMeter;
    public float m_tempMeterAmount = 1.0f;


    public AudioClip m_deathClip;
    public GameObject m_deathScreen;

    // getting all objects with audio sources in the game..in this case 1
    public AudioSource[] mainSource;
   


    // Use this for initialization
    void Start ()
    {
        //m_currentDaysCount = 0;

        if (PlayerPrefs.HasKey("LongestRelationship"))
        {
            m_longestDaysCount = PlayerPrefs.GetFloat("LongestRelationship");
        }

        m_deathScreen.SetActive(false);
        mainSource = AudioSource.FindObjectsOfType<AudioSource>() as AudioSource[];
        Time.timeScale = 1;
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
            m_loveMeterAmount -= (0.03f * 100.0f) * Time.deltaTime;
            m_loveMeterText.text = m_loveMeterAmount.ToString("f0");

            // the love meter bar also has to go down
            m_tempMeterAmount -= (0.03f) * Time.deltaTime;
            m_loveMeter.fillAmount = m_tempMeterAmount;

            //Debug.Log(m_loveMeterAmount);
            //Debug.Log(m_tempMeterAmount);

        }
        if(m_loveMeterAmount >= 100.0f)
        {
            m_loveMeterAmount = 100.0f;
            m_loveMeterText.text = m_loveMeterAmount.ToString("f0");

        }
        if(m_tempMeterAmount >= 1.0f)
        {
            m_tempMeterAmount = 1.0f;
            m_loveMeter.fillAmount = m_tempMeterAmount;
        }
        else if(m_tempMeterAmount <= 0)
        {
            //SceneManager.LoadScene("GameOver");
            foreach (AudioSource AS in mainSource)
            {
                AS.Stop();
             
            }
            AudioSource.PlayClipAtPoint(m_deathClip,transform.position);
            Time.timeScale = 0;
            m_deathScreen.SetActive(true);
        }


    }

    // adding to score when player hits a love pickup
    // fn takes in an int for the amount of points to give
    public void AddScore(int daysToAdd)
    {
        m_currentDaysCount += daysToAdd;
    }

    // when love is picked up add to the text
    public void AddLove(int loveToAdd)
    {
        m_loveMeterAmount += loveToAdd;
        m_loveMeterText.text = m_loveMeterAmount.ToString("f0");

    }
    // when love is picked up update the metre
    public void AddLoveMetre(float meterToAdd)
    {
        m_tempMeterAmount += meterToAdd;
        m_loveMeter.fillAmount = m_tempMeterAmount;
    }

    // when memory is picked up update text
    public void SubtractLove(int loveToSubtract)
    {
        m_loveMeterAmount -= loveToSubtract;
        m_loveMeterText.text = m_loveMeterAmount.ToString("f0");
    }
    // when memory is picked up update the love metre
    public void SubtractLoveMeter(float meterToSubtract)
    {
        m_tempMeterAmount -= meterToSubtract;
        m_loveMeter.fillAmount = m_tempMeterAmount;

    }

}
