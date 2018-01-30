using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreReader : MonoBehaviour
{

    private ScoreManager m_manager;

    // the players last run and the players best run
    public Text m_last;
    public Text m_best;


	// Use this for initialization
	void Start ()
    {

        m_last.text = "Your current relationship lasted " + PlayerPrefs.GetFloat("CurrentRelationship",m_manager.m_currentDaysCount) + " Days.";
        m_best.text = "Your best relationship lasted " + PlayerPrefs.GetFloat("LongestRelationship", m_manager.m_longestDaysCount) + " Days.";



    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
