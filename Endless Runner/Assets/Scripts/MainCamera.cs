using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour
{

    [Header("Camera Attributes")]
    GameObject m_primaryObject;
    public float m_baseDistance;
    public float m_baseYPosition;
    public float m_distanceAhead;

    bool m_locked = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_primaryObject = GameManager.Instance.m_playerObject;

        if (m_primaryObject)
        {
            Vector3 targetPosition = new Vector3(m_primaryObject.transform.position.x + m_distanceAhead, m_baseYPosition, -m_baseDistance);


            if (Mathf.Abs(transform.position.x - targetPosition.x) < 0.1f)
            {
                m_locked = true;
            }

            if(!m_locked)
            {
                targetPosition.x = Mathf.Lerp(transform.position.x, targetPosition.x, Time.deltaTime * 10);
            }

            //targetPosition.x = Mathf.Lerp(transform.position.x, targetPosition.x, Time.deltaTime * 10);
            //targetPosition.y = Mathf.Lerp(transform.position.y, targetPosition.y, Time.deltaTime * 10);


            
            
            transform.position = targetPosition;
        }
        else
        {
            m_locked = false;
        }
    }

    public void UnlockCamera()
    {
        m_locked = false;
    }
}
