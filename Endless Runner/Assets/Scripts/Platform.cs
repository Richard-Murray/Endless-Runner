using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnCollisionEnter(Collision collision) 
    {
       DummyPlayer player = collision.gameObject.GetComponent<DummyPlayer>();
       if (player == null)
           return;

       player.isPlayerJumping(false);
    }

}
