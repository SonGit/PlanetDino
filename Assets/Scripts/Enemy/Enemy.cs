using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

	public float speed;
	public Transform ExplosionEffectPos;
	public GameObject mesh;

	// Use this for initialization
	void Start () {
		Destroy ();
	}
		
	protected override void Init()
	{
		base.Init ();
		Rigidbody rb = this.GetComponent<Rigidbody> ();
		rb.velocity = Vector3.zero;;
	}
	
	// Update is called once per frame
	void Update () {
		MoveForward ();
	}

	private void RandomAngle()
	{
		transform.eulerAngles = new Vector3 (Random.Range(-180,180),Random.Range(-180,180),Random.Range(-180,180));
	}

	private void MoveForward()
	{
		transform.position += mesh.transform.forward * Time.deltaTime * speed;
	}

	public void Killed()
	{
		ExplosionEffect (transform.position);
		StartCoroutine (WaitDestroyEnemy());

	}

	void OnCollisionEnter(Collision other) {

		if (CheckIfAEnemy(other.transform)) {
			StartCoroutine (TurnAround());
		}

	}

	IEnumerator TurnAround()
	{
		float targetRot = mesh.transform.localEulerAngles.y + 180;
		while (mesh.transform.localEulerAngles.y != targetRot) {
			mesh.transform.localRotation = Quaternion.Lerp(mesh.transform.localRotation,Quaternion.Euler(0,targetRot,0), Time.deltaTime * .5f);
			yield return new WaitForEndOfFrame ();
		}

	}
		
	public void ExplosionEffect (Vector3 pos)
	{
		Explosion explosion;

		switch (currentColor.name) {

		case "Character_1":
			explosion = ObjectPool.instance.GetExplosion1 ();
			break;
		case "Character_2":
			explosion = ObjectPool.instance.GetExplosion2 ();
			break;
		case "Character_3":
			explosion = ObjectPool.instance.GetExplosion3 ();
			break;
		case "Character_4":
			explosion = ObjectPool.instance.GetExplosion4 ();
			break;

		default:
			explosion = ObjectPool.instance.GetExplosion4 ();
			break;
		}

		if (explosion != null) {
			explosion.transform.position = pos;
			explosion.Live ();
			explosion.Play ();
		}

	}


	private IEnumerator WaitDestroyEnemy ()
	{
		yield return new WaitForSeconds (0.05f);
		Destroy ();
	}

	public void RandomColor(int col)
	{
		currentColor = colorTextures [col];
		foreach (Renderer render in playerRenderers) {
			render.material.mainTexture = currentColor;
		}
	}


}
