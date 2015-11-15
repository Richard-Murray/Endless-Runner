using UnityEngine;
using System.Collections;

public class PickupScore : BasePickup {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(new Vector3(0, 1, 0), 30 * Time.deltaTime);
	}

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    public override void PlayerCollision(GameObject a_player)
    {
        //base.PlayerCollision(a_player);
        GameManager.Instance.AddScore(2000);
        //SoundManager.Instance.PlayClip(m_soundKey);
        //GameManager.Instance.ResetPlayer();
    }
}
