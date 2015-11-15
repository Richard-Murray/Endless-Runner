using UnityEngine;
using System.Collections;

public enum STATE
{
    MENU_MAIN,
    GAME_SIMULATION
}

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }

    public bool DEBUG_THIS_LEVEL;

    public Vector3 m_playerStartPosition;
    [HideInInspector]
    public GameObject m_playerObject;
    GameObject m_playerObjectSource;

    STATE m_gameState;

    [HideInInspector]
    public int m_currentScore = 0;
    [HideInInspector]
    public int m_currentCogs = 0;

    bool m_gameStarted = false;

    float m_doubleScoreTimer = 0;
    int m_chainedScoreCollection = 0;
    [HideInInspector]
    public bool m_doubleScore = false;

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
        m_gameState = STATE.MENU_MAIN;
        m_currentScore = 0;
        m_playerObjectSource = (GameObject)Resources.Load("Player");
        //ResetPlayer();
	}
	
	// Update is called once per frame
	void Update () {
	    
        //debug
        if (DEBUG_THIS_LEVEL)
        {
            m_gameState = STATE.GAME_SIMULATION;
        }

        if(!m_gameStarted && !m_playerObject && m_gameState == STATE.GAME_SIMULATION)
        {
            StartGameSimulation();
            ResetStatistics();
            m_gameStarted = false;

        }

        HandleScoreChaining();
	}

    void ResetStatistics()
    {
        m_currentScore = 0;
        m_currentCogs = 0;
    }

    void HandleScoreChaining()
    {
        m_doubleScoreTimer -= Time.deltaTime;

        if(m_doubleScoreTimer <= 0)
        {
            m_doubleScore = false;
            m_chainedScoreCollection = 0;
        }
    }

    public void AddScore(int a_scoreToAdd)
    {
        SoundManager.Instance.PlayClip(1);
        m_doubleScoreTimer = 5;
        m_chainedScoreCollection++;

        if(m_chainedScoreCollection == 5)
        {
            m_doubleScore = true;
        }

        if (m_doubleScoreTimer > 0 && m_doubleScore)
        {
            m_currentScore += (a_scoreToAdd * 2);
        }
        else
        {
            m_currentScore += a_scoreToAdd;
        }
    }

    public void AddShieldCog()
    {
        m_currentCogs++;
        if(m_currentCogs >= 5)
        {
            m_playerObject.GetComponent<BaseCharacter>().TurnOnShield();
            SoundManager.Instance.PlayClip(3);
            //tell GUI to activate effect            
        }
        else
        {
            SoundManager.Instance.PlayClip(2);
        }
    }

    public void LinkPlayer(GameObject a_player)
    {
        m_playerObject = a_player;
    }

    public void SwitchToScene(string a_levelName)
    { 
        m_gameStarted = false;
        GetComponent<ScreenTransition>().TransitionToScene(a_levelName);
    }

    public void StartGameSimulation()
    {
        ResetPlayer();
    }

    public void ResetPlayer()
    {
        if (m_playerObject)
        {
            Destroy(m_playerObject);
        }
        m_playerObject = Instantiate(m_playerObjectSource);
        m_playerObject.transform.position = m_playerStartPosition;

        var cam = GameObject.Find("Main Camera");
        if (cam.GetComponent<MainCamera>())
        {
            cam.GetComponent<MainCamera>().UnlockCamera();
        }
    }

    public void SetState(STATE a_state)
    {
        m_gameState = a_state;
    }
}