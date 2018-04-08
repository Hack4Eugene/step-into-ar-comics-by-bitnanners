using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SpeechBubAudio : MonoBehaviour {

	public AudioSource AudSrc;
	public List<AudioClip> clips = new List<AudioClip>();
	public bool rando = true;

   public bool ck = false;

	void Awake () {
		AudSrc = GetComponent<AudioSource>();
        
		if(AudSrc != null && clips.Count > 0)
		{

			if (rando)
				AudSrc.clip = clips[Random.Range(0, clips.Count)];
			else
				AudSrc.clip = clips[0];
			AudSrc.loop = false;
			AudSrc.spatialBlend = 0;
			AudSrc.playOnAwake = true;
		}
        ck = true;

    }

    //private void Update()
    //{
    //    if(ck)
    //    {
    //        if (gameObject.activeSelf)
    //        {
    //            playSound();
    //            ck = false;
    //        }
    //    }
    //}

    public void playSound()
	{
		AudSrc.Stop();

		if (rando)
			AudSrc.clip = clips[Random.Range(0, clips.Count)];
		else
			AudSrc.clip = clips[0];

        AudSrc.Play();
    }

	private void OnBecameVisible()
	{
		playSound();
	}

    private void OnDisable()
    {
        ck = true;
    }
}
