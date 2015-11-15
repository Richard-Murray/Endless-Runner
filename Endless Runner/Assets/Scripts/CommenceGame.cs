using UnityEngine;
using System.Collections;

public class CommenceGame : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}

	public void StartGame()
	{
		//Application.LoadLevel ("EndlessRun");
        GameManager.Instance.SwitchToScene("EndlessRun");
	}
}
