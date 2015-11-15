using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseCharacter : MonoBehaviour
{
    [Header("Base Character Attributes")]
    public float m_initialSpeed;
    public float m_maxSpeed;
    public float m_speedMultiplierPerSecond;
    public float m_jumpSpeed;
    public float m_antiGravBoostSpeed;
    public float m_rayDistance;
    public float m_shieldMaxTime;
    public float m_zOffset;

    public LayerMask m_collideMask;

    public float m_initialGravity;

    //None of these variables are aligned but who cares about optimisation
    float m_currentSpeed;
    int m_currentDirection; //1 is on the ground, -1 is on the roof
    //float m_postJumpBoostFrames; //for mario-style jump influence
    float m_shieldTimer;
    [HideInInspector]
    public bool m_shieldOn;


    List<RaycastHit2D> m_rayBelow;
    List<RaycastHit2D> m_rayAbove;
    bool m_collidingAbove;
    bool m_collidingBelow;
    bool m_collidingInFront;

    Vector2 m_velocity;

    Vector3 m_eRotation = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start()
    {
        m_currentDirection = 1;
        m_velocity = new Vector2(0, 0);

        m_rayBelow = new List<RaycastHit2D>();
        m_rayAbove = new List<RaycastHit2D>();

        m_collidingAbove = false;
        m_collidingBelow = false;

        m_currentSpeed = m_initialSpeed;

        GameManager.Instance.LinkPlayer(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        DetectCollisions();
        CalculateMovement();
        HandleShield();

        m_currentSpeed *= 1 + m_speedMultiplierPerSecond;

        CheckForDeath();

        CalculateRotation();
    }

    void DetectCollisions()
    {
        m_rayAbove.Clear();
        m_rayBelow.Clear();

        m_collidingAbove = false;
        m_collidingBelow = false;

        m_collidingInFront = false;

        Vector2 rayStart;
        Vector2 rayDirection;
        RaycastHit2D ray;

        //vertical collision
        for (int i = 0; i < 2; i++)
        {
            rayStart = new Vector2(transform.position.x - 0.5f + i * 1, transform.position.y);
            rayDirection = new Vector2(0, -1);
            ray = Physics2D.Raycast(rayStart, rayDirection, m_rayDistance + (Mathf.Abs(m_velocity.y) * Time.deltaTime), m_collideMask);
            if(ray)
            {
                m_rayBelow.Add(ray);
                m_collidingBelow = true;
            }
             //This uses the previous frame's velocity to match up the collision boundary
            rayDirection.y = 1;
            ray = Physics2D.Raycast(rayStart, rayDirection, m_rayDistance + (Mathf.Abs(m_velocity.y) * Time.deltaTime), m_collideMask);
            if(ray)
            {
                m_rayAbove.Add(ray);
                m_collidingAbove = true;
            }
        }

        //horizontal collision
        rayStart = new Vector2(transform.position.x, transform.position.y);
        rayDirection = new Vector2(1, 0);
        Debug.DrawRay(rayStart, rayDirection, Color.red);
        ray = Physics2D.Raycast(rayStart, rayDirection, m_rayDistance + (Mathf.Abs(m_velocity.x) * Time.deltaTime), m_collideMask);
        if (ray)
        {
            m_collidingInFront = true;
        }

    }

    void CalculateMovement() //will move inputs out later
    {
        if ((Input.GetKeyDown(KeyCode.Space) || ((InputManager.Instance.m_swipeUp && m_currentDirection == 1) || (InputManager.Instance.m_swipeDown && m_currentDirection == -1))) && (m_collidingBelow || m_collidingAbove))
        {
            SoundManager.Instance.PlayClip(5);
            m_velocity.y = m_antiGravBoostSpeed * m_currentDirection;
            m_currentDirection *= -1;
        }

        //Vertical
        m_velocity.y += m_initialGravity * -m_currentDirection * Time.deltaTime;

        if (Input.GetKey(KeyCode.B) || InputManager.Instance.m_tapped)
        {
            //if (m_collidingBelow || m_collidingAbove)
            //{
            //    m_postJumpBoostFrames = 0.25f;
            //}
            //if (m_postJumpBoostFrames > 0)
            //{
            if (m_collidingBelow || m_collidingAbove)
            {
                SoundManager.Instance.PlayClip(6);
                m_velocity.y = m_jumpSpeed * m_currentDirection;
            }
            //}
        }
        else
        {
            //m_postJumpBoostFrames = 0;

            if (m_collidingBelow && m_velocity.y <= 0)
            {
                transform.position = new Vector3(transform.position.x, m_rayBelow[0].point.y + 0.5f, m_zOffset);
                m_velocity.y = 0;
            }
            if (m_collidingAbove && m_velocity.y >= 0)
            {
                transform.position = new Vector3(transform.position.x, m_rayAbove[0].point.y - 0.5f, m_zOffset);
                m_velocity.y = 0;
            }
        }

        //m_postJumpBoostFrames -= Time.deltaTime;

        //Horizontal
        if(m_currentSpeed > m_maxSpeed)
        {
            m_currentSpeed = m_maxSpeed;
        }
        m_velocity.x = m_currentSpeed;

        transform.position += new Vector3(m_velocity.x, m_velocity.y, 0) * Time.deltaTime;
    }

    void CalculateRotation()
    {
        float rot;
        if (m_currentDirection == -1)
        {
            rot = 180;
        }
        else
        {
            rot = 0;
        }
        m_eRotation.x = Mathf.Lerp(m_eRotation.x, rot, 5 * Time.deltaTime);
        transform.rotation = Quaternion.Euler(m_eRotation);
    }

    void HandleShield()
    {
        if(m_shieldTimer > 0)
        {
            m_shieldTimer -= Time.deltaTime;
            m_shieldOn = true;
        }
        else
        {
            m_shieldTimer = 0;
            m_shieldOn = false;
        }
    }

    void CheckForDeath()
    {
        if (m_collidingInFront)// || transform.position.y > 11 || transform.position.y < -1)
        {
            GameManager.Instance.ResetPlayer();
        }
    }

    public void TurnOnShield()
    {
        m_shieldTimer = m_shieldMaxTime;
        SoundManager.Instance.PlayClip(3);
    }
}
