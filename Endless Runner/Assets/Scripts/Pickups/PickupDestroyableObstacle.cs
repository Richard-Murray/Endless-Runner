using UnityEngine;
using System.Collections;

public class PickupDestroyableObstacle : BasePickup {

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
        if (!a_player.GetComponent<BaseCharacter>().m_shieldOn)
        {
            GameManager.Instance.ResetPlayer();
        }
    }
}
