using UnityEngine;
using System.Collections;

public class PickupShieldCog : BasePickup {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    public override void PlayerCollision(GameObject a_player)
    {
        
    }

}
