using UnityEngine;
using System.Collections;

public class CommenceMenu : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
	
	}
	
	public void ReturnToMenu()
	{
		Application.LoadLevel (0);
	}
}
