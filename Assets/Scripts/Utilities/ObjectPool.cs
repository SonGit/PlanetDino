using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ATTACH TO ObjectPool gameObject

public class ObjectPool : MonoBehaviour {

	public static ObjectPool instance;

	GenericObject<Enemy> enemy;
	GenericObject<AudioSource_RB> audioSource;

	public FakeGravity fakeGravity;

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		enemy = new GenericObject<Enemy>(ObjectFactory.PrefabType.Enemy,25);
		audioSource = new GenericObject<AudioSource_RB>(ObjectFactory.PrefabType.AudioSource,1);
	}
		

	public Enemy GetEnemy()
	{
		return enemy.GetObj ();
	}

	public AudioSource_RB GetAudioSource()
	{
		return audioSource.GetObj ();
	}

}
