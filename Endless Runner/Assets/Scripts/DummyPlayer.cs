using UnityEngine;
using System.Collections;

public class DummyPlayer : MonoBehaviour
{

    public GameObject text;


    [Range(1,100)]
    [Tooltip("The Players current speed from 0-100")] 
    public float m_speed;

    private float m_direction;

    [Tooltip("True is player is on the ceiling, False is player on the ground")]
    public bool m_inverted;


    private int tapcount;

    /// <summary>
    /// If true the player is jumping if false the palyer is not.
    /// this resets to false when they hit they hit a platform otherwise they will
    /// continue falling
    /// </summary>
    private bool m_playerjumping;

    TextMesh blah;


	// Use this for initialization
	void Start ()
    {
        tapcount = 0;
        blah = text.GetComponent<TextMesh>();
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
            tapcount++;
            blah.text = tapcount.ToString();
           
		}
	}

}
