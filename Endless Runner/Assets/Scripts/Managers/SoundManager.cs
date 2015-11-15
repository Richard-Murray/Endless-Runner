using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

    public static SoundManager Instance { get; private set; }

    public List<AudioClip> m_audioClipList;
    AudioSource m_audio;

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
        m_audio = GetComponent<AudioSource>();
        m_audio.clip = m_audioClipList[0];
        m_audio.loop = true;
        m_audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayClip(1);
        }

        //m_audio.Sto();
	}

    public void PlayClip(int a_clipNumber)
    {
        if (m_audioClipList[a_clipNumber])
        {
            m_audio.PlayOneShot(m_audioClipList[a_clipNumber]);
        }
    }
}
