using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Linq;

public class AudioManager : MonoBehaviour
{
	public Sound[] _sounds;


	// Use this for initialization
	void Start ()
	{
		foreach (Sound s in _sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s._clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
		}
	}

	public void Play(string name)
	{
		Sound s = _sounds.SingleOrDefault(x => x.name == name);
		s.source.Play();
	}
}
