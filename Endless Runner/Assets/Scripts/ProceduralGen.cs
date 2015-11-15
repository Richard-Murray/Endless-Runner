using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ProceduralGen : MonoBehaviour {


    /// <summary>
    /// Segment pieces are just the prefab segments 
    /// </summary>
    public List<GameObject> _segmentPieces;

    /// <summary>
    /// The managed segments are the instantiated segments that will be generated as well as
    /// deleted when they are either about to leave a area or go into a new area
    /// </summary>

    public List<GameObject> _managedSegments;

    /// <summary>
    /// The player is the player obviously
    /// </summary>
    protected GameObject _player;

    /// <summary>
    /// the float distance is for calculating when to generate a new chunk (segment)
    /// or removing a previously existing segment from the manged segments list.
    /// </summary>
    public float _distance;


    /// <summary>
    /// This is just the generated location for the segment 
    /// where it should spawn when you are entering a new chunk
    /// </summary>
    private Vector3 _generatelocation;

    /// <summary>
    /// The player start position is the inital start location and will only update when
    /// a new segment is generated
    /// </summary>
    private Vector3 _PlayerstartPosition;

    /// <summary>
    /// The player update position is the updated position each frame
    /// </summary>
    private Vector3 _PlayerUpdatePosition;

    /// <summary>
    /// We dont want the first segment to be deleted for the first time we launch the code
    /// </summary>
    private bool _IgnoreTwice;


    //Crappy thing rather not explain
    int _numofTimes;

	// Use this for initialization
	void Start ()
    {
        SetPlayerStartPosition(_player.transform.position);
        _PlayerUpdatePosition = _player.transform.position;
        _numofTimes = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        _player = GameManager.Instance.m_playerObject;

        _PlayerUpdatePosition = _player.transform.position;


        _distance = _PlayerUpdatePosition.x - _PlayerstartPosition.x;
       

        if(_distance > 66)
        {

            Vector3 incrimentx = new Vector3(88,0,0);
            _numofTimes++;

            Vector3 spawnpos = new Vector3(_PlayerstartPosition.x, 0, 0);


            if (_numofTimes == 2)
                _IgnoreTwice = true;

            _generatelocation = spawnpos + incrimentx;
            CreateSegment();
            SetPlayerStartPosition(_PlayerUpdatePosition);


        }


        if (_IgnoreTwice)
        {
            RemoveSegment();
        }
        


	}

    void RemoveSegment()
    {
        if(_distance > 25 && _distance < 30)
        {
            Destroy(_managedSegments[0].gameObject);
            _managedSegments.RemoveAt(1);
        }
    }

    void CreateSegment()
    {
        int seed = Random.Range(0, _segmentPieces.Count);

        GameObject segment = Instantiate(_segmentPieces[seed], _generatelocation,Quaternion.identity) as GameObject;
        _managedSegments.Add(segment);

    }


    void SetPlayerStartPosition(Vector3 Location)
    {
        _PlayerstartPosition = Location;
    }

}
