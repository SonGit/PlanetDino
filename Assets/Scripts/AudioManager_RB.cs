using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_RB : MonoBehaviour {

	public static AudioManager_RB instance;

	private Dictionary<SoundFX,AudioClip> clips;

	public string isOnSound = "t";

	void Awake()
	{
		instance = this;
	}

	IEnumerator Start()
	{
		

		DontDestroyOnLoad (gameObject);

		clips = new Dictionary<SoundFX, AudioClip> {

			{ SoundFX.None, null },
			{ SoundFX.Click, Resources.Load<AudioClip>("Sounds/Click") },
			{ SoundFX.PlayerInjured, Resources.Load<AudioClip>("Sounds/PlayerInjured") },
			{ SoundFX.PlayerDeath, Resources.Load<AudioClip>("Sounds/PlayerDeath") },
			{ SoundFX.EnemyHit, Resources.Load<AudioClip>("Sounds/EnemyHit") },
		};

		yield return new WaitForSeconds (1);
	}

	public enum SoundFX
	{
		None,
		Click,
		PlayerInjured,
		PlayerDeath,
		EnemyHit,
	}

	public void PlayClip(SoundFX soundFX,Vector3 worldPos)
	{
		AudioClip clip;
		if (clips.TryGetValue (soundFX, out clip)) {
			
			AudioSource_RB audio = ObjectPoolSound.instance.GetAudioSource ();
			audio.audioSource.clip = clip;

			if (isOnSound == "t") {
				audio.audioSource.volume = 1;
			} else if (isOnSound == "f"){
				audio.audioSource.volume = 0;
			}
		
			audio.transform.position = worldPos;
			audio.Live ();

		}
	}
}
