using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    
    GameObject m_playerObject;

    int m_currentScore = 0;
    int m_currentCogs = 0;

    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this); //Not sure if this will work
        }
    }


	// Use this for initialization
	void Start () {
        m_currentScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ResetStatistics()
    {
        m_currentScore = 0;
        m_currentCogs = 0;
    }

    public void AddScore(int a_scoreToAdd)
    {
        m_currentScore += a_scoreToAdd;
        Debug.Log(m_currentScore);
    }

    public void AddShieldCog()
    {
        m_currentCogs++;
        if(m_currentCogs >= 5)
        {

        }
    }

    public void LinkPlayer(GameObject a_player)
    {
        m_playerObject = a_player;
    }
}