using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ATTACH TO ObjectFactory gameObject
public class ObjectFactory: MonoBehaviour {

	public static ObjectFactory instance;

	void Awake()
	{
		instance = this;
	}

	public enum PrefabType
	{
		None,
		Enemy,
		AudioSource,
		Explosion,
		ExplosionLightBlue,
		ExplosionPink,
		ExplosionBlue,
		ExplosionBabyBlue
	}

	public Dictionary<PrefabType,string> PrefabPaths = new Dictionary<PrefabType, string> {
		
		{ PrefabType.None, "" },
		{ PrefabType.Enemy, "Prefabs/Enemy" },
		{ PrefabType.AudioSource, "Prefabs/AudioSource" },
		{ PrefabType.Explosion, "Prefabs/Explosion" },
		{ PrefabType.ExplosionPink, "Prefabs/ExplosionPink" },
		{ PrefabType.ExplosionLightBlue, "Prefabs/ExplosionLightBlue" },
		{ PrefabType.ExplosionBlue, "Prefabs/ExplosionBlue" },
		{ PrefabType.ExplosionBabyBlue, "Prefabs/ExplosionBabyBlue" },
	};

	public GameObject MakeObject(PrefabType type)
	{
		string path;
		if (PrefabPaths.TryGetValue (type, out path)) {
			return (Instantiate (Resources.Load (path, typeof(GameObject))) as GameObject);
		}
		print ("NULL");
		return null;
	}

}
