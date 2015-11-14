using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{

    public static InputManager Instance { get; private set; }

    [HideInInspector]
    public bool m_tapped;

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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount != 0)//!Input.GetTouch(0).Equals(null))
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                m_tapped = true;
            }
            m_tapped = false;
        }
        else
        {
            m_tapped = false;
        }

    }
}

