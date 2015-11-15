using UnityEngine;
using System.Collections;

public class PickupShieldCog : BasePickup {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(new Vector3(0, 0, 1), 30 * Time.deltaTime);
	}

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    public override void PlayerCollision(GameObject a_player)
    {
        GameManager.Instance.AddShieldCog();
    }

}
