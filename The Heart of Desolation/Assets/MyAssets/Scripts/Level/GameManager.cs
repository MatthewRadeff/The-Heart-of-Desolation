using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // score manager
    private ScoreManager m_theScoreManager;

	// Use this for initialization
	void Start ()
    {
        m_theScoreManager = FindObjectOfType<ScoreManager>();


		
	}

    //m_theScoreManager.m_scoreIncreasing = false;

	// Update is called once per frame
	void Update ()
    {
	
	}
}
