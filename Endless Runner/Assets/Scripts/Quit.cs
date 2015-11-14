using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour {
	// Use this for initialization
	void Start () 
	{
		
	}
	
	public void QuitApplication()
	{
		if(Application.platform == RuntimePlatform.Android)
		{
			Application.Quit();
		}
	}
}
