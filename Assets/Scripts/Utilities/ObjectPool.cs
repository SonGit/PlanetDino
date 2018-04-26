using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ATTACH TO ObjectPool gameObject

public class ObjectPool : MonoBehaviour {

	public static ObjectPool instance;

	GenericObject<Enemy> enemy;
	GenericObject<AudioSource_RB> audioSource;

	GenericObject<Explosion> explosion1;
	GenericObject<Explosion> explosion2;
	GenericObject<Explosion> explosion3;
	GenericObject<Explosion> explosion4;
	GenericObject<AddScoreText> addScoreText;

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		enemy = new GenericObject<Enemy>(ObjectFactory.PrefabType.Enemy,20);
		audioSource = new GenericObject<AudioSource_RB>(ObjectFactory.PrefabType.AudioSource,1);

		explosion1 = new GenericObject<Explosion>(ObjectFactory.PrefabType.Explosion1,2);
		explosion2 = new GenericObject<Explosion>(ObjectFactory.PrefabType.Explosion2,2);
		explosion3 = new GenericObject<Explosion>(ObjectFactory.PrefabType.Explosion3,2);
		explosion4= new GenericObject<Explosion>(ObjectFactory.PrefabType.Explosion4,2);
		addScoreText= new GenericObject<AddScoreText>(ObjectFactory.PrefabType.ScoreAddText,1);
	}
		

	public Enemy GetEnemy()
	{
		return enemy.GetObj ();
	}

	public AudioSource_RB GetAudioSource()
	{
		return audioSource.GetObj ();
	}
		
	public Explosion GetExplosion1()
	{
		return explosion1.GetObj ();
	}

	public Explosion GetExplosion2()
	{
		return explosion2.GetObj ();
	}

	public Explosion GetExplosion3()
	{
		return explosion3.GetObj ();
	}

	public Explosion GetExplosion4()
	{
		return explosion4.GetObj ();
	}

	public AddScoreText GetAddScoreText()
	{
		return addScoreText.GetObj ();
	}
}
