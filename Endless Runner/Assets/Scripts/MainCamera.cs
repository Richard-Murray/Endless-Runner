using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour
{

    [Header("Camera Attributes")]
    public GameObject m_primaryObject;
    public float m_baseDistance;
    public float m_baseYPosition;
    public float m_distanceAhead;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(m_primaryObject.transform.position.x + m_distanceAhead, m_baseYPosition, -m_baseDistance);

        //targetPosition.x = Mathf.Lerp(transform.position.x, targetPosition.x, Time.deltaTime * 10);
        //targetPosition.y = Mathf.Lerp(transform.position.y, targetPosition.y, Time.deltaTime * 10);

        transform.position = targetPosition;
    }
}
