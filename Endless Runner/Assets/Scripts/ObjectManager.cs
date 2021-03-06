﻿using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour 
{
    public static ObjectManager Instance { get; private set; }
    
    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this); //Not sure if this will work
        }
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
