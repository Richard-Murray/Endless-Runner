using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ProcedualGen : MonoBehaviour {


    public List<GameObject> _playerReference;
    public List<GameObject> _segmentPrefabs;
    public List<GameObject> _generatedSegments;

    //This is to keep track of the player distance from when the segment is generated.
    int _distance;


	// Use this for initialization
	void Start () 
    {
        _segmentPrefabs = new List<GameObject>();
        _generatedSegments = new List<GameObject>();
	}



    void GenerateSegment()
    {
        //This will generate a random segment from the generate segments list
        //Blah
    }

    void RemoveSegment()
    {
        //This will remove a segment when the player is about to leave the segment so that
        //It doesnt take up to much memory on the Phone 
    }



	// Update is called once per frame
	void Update ()
    {
	
	}
}
