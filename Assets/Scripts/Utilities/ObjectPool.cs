using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ATTACH TO ObjectPool gameObject

public class ObjectPool : MonoBehaviour {

	public static ObjectPool instance;

	GenericObject<Enemy> enemy;
	GenericObject<AudioSource_RB> audioSource;
	GenericObject<Explosion> explosion;
	GenericObject<Explosion> explosionPink;
	GenericObject<Explosion> explosionGreen;
	GenericObject<Explosion> explosionBlue;
	GenericObject<Explosion> explosionBabyBlue;
	public FakeGravity fakeGravity;

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		enemy = new GenericObject<Enemy>(ObjectFactory.PrefabType.Enemy,3);
		audioSource = new GenericObject<AudioSource_RB>(ObjectFactory.PrefabType.AudioSource,1);
		explosion = new GenericObject<Explosion>(ObjectFactory.PrefabType.Explosion,2);
		explosionPink = new GenericObject<Explosion>(ObjectFactory.PrefabType.ExplosionPink,2);
		explosionGreen = new GenericObject<Explosion>(ObjectFactory.PrefabType.ExplosionLightBlue,2);
		explosionBlue = new GenericObject<Explosion>(ObjectFactory.PrefabType.ExplosionBlue,2);
		explosionBabyBlue= new GenericObject<Explosion>(ObjectFactory.PrefabType.ExplosionBabyBlue,2);
	}
		

	public Enemy GetEnemy()
	{
		return enemy.GetObj ();
	}

	public AudioSource_RB GetAudioSource()
	{
		return audioSource.GetObj ();
	}

	public Explosion GetExplosion()
	{
		return explosion.GetObj ();
	}

	public Explosion GetExplosionPink()
	{
		return explosionPink.GetObj ();
	}

	public Explosion GetExplosionGreen()
	{
		return explosionGreen.GetObj ();
	}

	public Explosion GetExplosionBlue()
	{
		return explosionBlue.GetObj ();
	}

	public Explosion GetExplosionBabyBlue()
	{
		return explosionBabyBlue.GetObj ();
	}
}
