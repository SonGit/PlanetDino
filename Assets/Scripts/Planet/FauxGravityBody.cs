using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FauxGravityBody : MonoBehaviour {

	private FauxGravityAttractor attractor;
	public Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		attractor = FauxGravityAttractor.instance;
		rb.constraints = RigidbodyConstraints.FreezeRotation;
		rb.useGravity = false;
	}

	void Update ()
	{
		attractor.Attract(transform);
	}

}
