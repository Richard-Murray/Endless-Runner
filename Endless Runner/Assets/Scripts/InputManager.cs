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
        //Debug.Log("0");
        if (Input.touchCount != 0)//!Input.GetTouch(0).Equals(null))
        {
            Debug.Log("1");
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Debug.Log("2");
                m_tapped = true;
            }
            else
            {
                m_tapped = false;
            }
        }
        else
        {
            m_tapped = false;
        }

    }
}

