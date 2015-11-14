using UnityEngine;
using System.Collections;

public class BaseCharacter : MonoBehaviour
{

    [Header("Base Character Attributes")]
    public float m_initialSpeed;
    public float m_jumpSpeed;
    public float m_antiGravBoostSpeed;
    public float m_rayDistance;

    public float m_initialGravity;

    int m_currentDirection; //1 is on the ground, -1 is on the roof

    float m_postJumpBoostFrames; //for mario-style jump influence

    RaycastHit2D m_rayBelow;
    RaycastHit2D m_rayAbove;

    Vector2 m_velocity;

    // Use this for initialization
    void Start()
    {
        m_currentDirection = 1;
        m_velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        DetectCollisions();
        CalculateMovement();

        //Debug.Log(m_velocity);

    }

    void DetectCollisions()
    {
        Vector2 rayStart = new Vector2(transform.position.x, transform.position.y);
        Vector2 rayDirection = new Vector2(0, -1);
        m_rayBelow = Physics2D.Raycast(rayStart, rayDirection, m_rayDistance + (Mathf.Abs(m_velocity.y) * Time.deltaTime)); //This uses the previous frame's velocity to match up the collision boundary
        rayDirection.y = 1;
        m_rayAbove = Physics2D.Raycast(rayStart, rayDirection, m_rayDistance + (Mathf.Abs(m_velocity.y) * Time.deltaTime));

    }

    void CalculateMovement() //will move inputs out later
    {
        if (Input.GetKeyDown(KeyCode.Space) && (m_rayBelow || m_rayAbove))
        {
            m_velocity.y = m_antiGravBoostSpeed * m_currentDirection;
            m_currentDirection *= -1;
        }

        //Vertical
        m_velocity.y += m_initialGravity * -m_currentDirection * Time.deltaTime;

        if (Input.GetKey(KeyCode.B) || InputManager.Instance.m_tapped)
        {
            if (m_rayBelow || m_rayAbove)
            {
                m_postJumpBoostFrames = 0.25f;
            }
            if (m_postJumpBoostFrames > 0)
            {
                m_velocity.y = m_jumpSpeed * m_currentDirection;
            }
        }
        else
        {
            if (m_rayBelow && m_velocity.y <= 0)
            {
                transform.position = new Vector3(transform.position.x, m_rayBelow.point.y + 0.5f, 0);
                m_velocity.y = 0;
            }
            if (m_rayAbove && m_velocity.y >= 0)
            {
                transform.position = new Vector3(transform.position.x, m_rayAbove.point.y - 0.5f, 0);
                m_velocity.y = 0;
            }
        }

        m_postJumpBoostFrames -= Time.deltaTime;

        //Horizontal
        m_velocity.x = m_initialSpeed;

        transform.position += new Vector3(m_velocity.x, m_velocity.y, 0) * Time.deltaTime;
    }
}
