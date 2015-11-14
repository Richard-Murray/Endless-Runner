using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{

    public static InputManager Instance { get; private set; }

    [HideInInspector]
    public bool m_tapped;
    [HideInInspector]
    public bool m_swiped;
    [HideInInspector]
    public bool m_swipeRight;
    [HideInInspector]
    public bool m_swipeLeft;
    [HideInInspector]
    public bool m_swipeDown;
    [HideInInspector]
    public bool m_swipeUp;

    float m_fingerStartTime = 0.0f;
    Vector2 m_fingerStartPosition = Vector2.zero;

    //bool m_isSwipe = false;
    float m_minSwipeDist = 30.0f;
    float m_maxSwipeTime = 0.5f;

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
            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    {
                        /* this is a new touch */
                        //m_isSwipe = true;
                        m_fingerStartTime = Time.time;
                        m_fingerStartPosition = Input.GetTouch(0).position;
                        break;
                    }

                case TouchPhase.Canceled:
                    {
                        /* The touch is being canceled */
                        //m_isSwipe = false;
                        break;
                    }

                case TouchPhase.Ended:
                    {
                        float fingerEndTime = Time.time;
                        Vector2 fingerEndPosition = Input.GetTouch(0).position;
                        float distanceBetweenFingerPoints = (fingerEndPosition - m_fingerStartPosition).magnitude;
                        //Debug.Log()

                        if (fingerEndTime < m_fingerStartTime + m_maxSwipeTime)
                        {
                            if (distanceBetweenFingerPoints > m_minSwipeDist)
                            {
                                m_swiped = true;
                                if(Mathf.Abs(fingerEndPosition.y - m_fingerStartPosition.y) > Mathf.Abs(fingerEndPosition.x - m_fingerStartPosition.x))
                                {
                                    if(fingerEndPosition.y > m_fingerStartPosition.y)
                                    {
                                        m_swipeUp = true;
                                    }
                                    else
                                    {
                                        m_swipeDown = true;
                                    }
                                }
                                else
                                {
                                    if (fingerEndPosition.x > m_fingerStartPosition.x)
                                    {
                                        m_swipeRight = true;
                                    }
                                    else
                                    {
                                        m_swipeLeft = true;
                                    }
                                }
                            }
                            else
                            {
                                m_tapped = true;
                            }
                        }

                        break;
                    }

            }
        }
        else
        {
            m_swiped = false;
            m_swipeRight = false;
            m_swipeLeft = false;
            m_swipeDown = false;
            m_swipeUp = false;
            m_tapped = false;
        }


        //    if (Input.GetTouch(0).phase == TouchPhase.Ended)
        //    {
        //        m_tapped = true;
        //    }
        //    else
        //    {
        //        m_tapped = false;
        //    }
        //}
        //else
        //{
        //    m_tapped = false;
        //}

    }
}

