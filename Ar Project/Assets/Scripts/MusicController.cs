using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

	private List<AudioSource> Sources = new List<AudioSource>();

	public List<AudioInfo> clips = new List<AudioInfo>();


	void Awake () {
		for(int i = 0; i < clips.Count; i++)
		{
			AudioSource AsS = gameObject.AddComponent<AudioSource>();
			AsS.loop = clips[i].loop;
			AsS.spatialBlend = clips[i].blend;
			AsS.clip = clips[i].clip;
			AsS.playOnAwake = false;
			Sources.Add(AsS);
		}
	}
	
	private void setUpSound(AudioClip clip)
	{

	}

	public void PlaySound(int Index)
	{
		if(Index < Sources.Count && Index >= 0)
		{
			Sources[Index].Stop();
			Sources[Index].Play();
		}
		else
		{
			Debug.LogError("Bad Index");
		}
	}
	public void StopSound(int Index)
	{
		if (Index < Sources.Count && Index >= 0)
		{
			Sources[Index].Stop();
		}
		else
		{
			Debug.LogError("Bad Index");
		}
	}
}

[System.Serializable]
public class AudioInfo
{
	public AudioClip clip;
	public bool loop = false;
	public float blend = 0;

	public AudioInfo(AudioClip Clip)
	{
		clip = Clip;
	}
	public AudioInfo(AudioClip Clip, bool Loop, float Blend)
	{
		clip = Clip;
		loop = Loop;
		blend = Blend;
	}
}

