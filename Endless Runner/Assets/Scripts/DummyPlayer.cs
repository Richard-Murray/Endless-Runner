using UnityEngine;
using System.Collections;

public class DummyPlayer : MonoBehaviour
{

    public GameObject _text;
    Rigidbody _dummyRigidBody;

    [Range(1,100)]
    [Tooltip("The Players current speed from 0-100")] 
    public float m_speed;

    private float m_direction;

    [Tooltip("True is player is on the ceiling, False is player on the ground")]
    public bool m_inverted;


    private int _tapcount;

    /// <summary>
    /// If true the player is jumping if false the palyer is not.
    /// this resets to false when they hit they hit a platform otherwise they will
    /// continue falling
    /// </summary>
    protected bool m_playerjumping;

    TextMesh _textMesh;


	// Use this for initialization
	void Start ()
    {
        _tapcount = 0;
        _textMesh = _text.GetComponent<TextMesh>();
        _dummyRigidBody = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        HelloAndroid();
	}
	
	void HelloAndroid()
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
		{
            _tapcount++;
            _textMesh.text = _tapcount.ToString();
           
		}
	}

    void PlayerJump()
    {
        
    }


    public void isPlayerJumping(bool val)
    {
        m_playerjumping = val;
    }

}
