using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {
	[HideInInspector]
	public int randNum;

	public float speed;
	public Transform ExplosionEffectPos;



	// Use this for initialization
	void Start () {
		Init ();
	}
		
	protected override void Init()
	{
		base.Init ();
		randNum = Random.Range (-9999,9999);
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
		transform.position += transform.forward * Time.deltaTime * speed;
	}
		
	private void EatEnemy(Enemy enemy)
	{
		if (enemy.randNum < this.randNum) {
			Destroy ();

		} else {
			RandomColor ();
		}
	}

	public void Killed()
	{
		ExplosionEffect (transform.position);
		StartCoroutine (WaitDestroyEnemy());
	}

	void OnCollisionEnter(Collision other) {

		if (CheckIfAEnemy(other.transform)) {
			EatEnemy (other.transform.GetComponent<Enemy> ());
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



}
