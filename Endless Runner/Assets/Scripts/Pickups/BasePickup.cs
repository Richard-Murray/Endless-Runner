using UnityEngine;
using System.Collections;

public class BasePickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collision");
        BaseCharacter player = collision.GetComponent<BaseCharacter>();
        if(player)
        {
            PlayerCollision(collision.gameObject);
        }
        Destroy(this.gameObject);
    }

    public virtual void PlayerCollision(GameObject a_player)
    {
        Destroy(this.gameObject);
    }
}
