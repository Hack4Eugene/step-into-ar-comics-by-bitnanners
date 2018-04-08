using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SpeechBubAudio : MonoBehaviour {

	private AudioSource AudSrc;
	public List<AudioClip> clips = new List<AudioClip>();
	public bool rando = true;
	void Start () {
		AudSrc = GetComponent<AudioSource>();
		if(AudSrc != null && clips.Count > 0)
		{

			if (rando)
				AudSrc.clip = clips[Random.Range(0, clips.Count)];
			else
				AudSrc.clip = clips[0];
			AudSrc.loop = false;
			AudSrc.spatialBlend = 0;
			AudSrc.playOnAwake = false;
		}
	}
	

	public void playSound()
	{
		AudSrc.Stop();

		if (rando)
			AudSrc.clip = clips[Random.Range(0, clips.Count)];
		else
			AudSrc.clip = clips[0];
	}

	

	private void OnEnable()
	{
		playSound();
	}
}
