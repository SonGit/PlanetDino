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
		Destroy ();
		ExplosionEffect (transform.position);
	}

	void OnCollisionEnter(Collision other) {

		if (CheckIfAEnemy(other.transform)) {
			EatEnemy (other.transform.GetComponent<Enemy> ());
		}

	}

	public void ComboButton ()
	{
		ComboScoreManager.instance.isActiveComboScore = true;
		ComboScoreManager.instance.comboScoreCount += 1;
		ComboScoreManager.instance.comboScoreTimeCount = 0;
	}
		
	public void ExplosionEffect (Vector3 pos)
	{
		Explosion explosion = ObjectPool.instance.GetExplosion ();
		if (explosion != null) {
			explosion.transform.position = pos;
			explosion.Live ();
		}

	}






}
