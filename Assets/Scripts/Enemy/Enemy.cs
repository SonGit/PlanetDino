using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Cacheable {
	[HideInInspector]
	public int randNum;

	public float speed;

	public DinoType type;

	public enum DinoType
	{
		RED,
		GREEN,
		BLUE
	}

	protected Dictionary<DinoType,Color> colorDict = new Dictionary<DinoType, Color>
	{
		{DinoType.RED,Color.red},
		{DinoType.GREEN,Color.green},
		{DinoType.BLUE,Color.blue},
	};

	Renderer renderer;

	// Use this for initialization
	void Start () {
		Destroy ();
	}
		

	protected void Init()
	{
		renderer = GetComponent< Renderer > ();
		RandomAngle ();
		RandomColor ();
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

	private void RandomColor(bool exceptCurrentType = false)
	{
		System.Array values = System.Enum.GetValues(typeof(DinoType));
		DinoType newType = (DinoType)values.GetValue(Random.Range(0,values.Length));

		if (exceptCurrentType) {
			while (type == newType) {
				newType = (DinoType)values.GetValue (Random.Range (0, values.Length));
			}
		}
		type = newType;
		renderer.material.color = colorDict[type];
	}

	private void EatEnemy(Enemy enemy)
	{
		if (enemy.randNum < this.randNum) {
			Destroy ();
		} else {
			RandomColor (true);
		}
	}

	void OnTriggerEnter(Collider other) {

		if (CheckIfAEnemy(other.transform)) {
			EatEnemy (other.transform.GetComponent<Enemy> ());
		}
	}

	Enemy enemyCache;
	bool CheckIfAEnemy(Transform targetTransform)
	{
		enemyCache = targetTransform.GetComponent<Enemy> ();

		if (enemyCache != null)
			return true;

		return false;
	}

	public override void OnDestroy ()
	{
		gameObject.SetActive (false);
	}

	public override void OnLive ()
	{
		gameObject.SetActive (true);
		Init ();
	}


}
