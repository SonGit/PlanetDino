using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_RB : MonoBehaviour {

	public static AudioManager_RB instance;

	private Dictionary<SoundFX,AudioClip> clips;

	void Awake()
	{
		instance = this;
	}

	IEnumerator Start()
	{
		clips = new Dictionary<SoundFX, AudioClip> {

			{ SoundFX.None, null },
			{ SoundFX.Click, Resources.Load<AudioClip>("Sounds/Click") },
		};

		yield return new WaitForSeconds (1);
	}

	public enum SoundFX
	{
		None,
		Click
	}

	public void PlayClip(SoundFX soundFX,Vector3 worldPos,float volume = 1)
	{
		AudioClip clip;
		if (clips.TryGetValue (soundFX, out clip)) {
			
			AudioSource_RB audio = ObjectPool.instance.GetAudioSource ();
			audio.audioSource.clip = clip;
			audio.audioSource.volume = volume;
			audio.transform.position = worldPos;
			audio.Live ();

		}
	}
}
