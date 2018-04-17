using UnityEngine;
using System.Collections;

public class CameraDrive : MonoBehaviour
{
	public GameObject
	targetObject;

	public Transform
	camPivot,
	camTarget,
	camRoot,

	relcamdirDebug;

	float
	rot = 0;
	//----------------------------------------------------------------------------------------------------------
	void Start()
	{
		this.transform.position = targetObject.transform.position;
		this.transform.rotation = targetObject.transform.rotation;
	}

	void FixedUpdate()
	{       
		//the pivot system
		camRoot.position    = targetObject.transform.position;

		//input on pivot orientation
		rot = 0;
		float mouse_x       = Input.GetAxisRaw( "camera_analog_X" );                //
		rot                 = rot + ( 0.1f * Time.deltaTime * mouse_x );            //
		wrapAngle( rot );                                                           //

		//when the target object rotate, it rotate too, this should not happen


		UpdateOrientation(this.transform.forward,targetObject.transform.up);

		camRoot.transform.RotateAround(camRoot.transform.up,rot);


		//this camera
		this.transform.position = camPivot.position;
		//set the camera to the pivot
		//Quaternion target = Quaternion.LookRotation(targetObject.transform.position - this.transform.position, targetObject.transform.up);

		//this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target, 0.1f);

		//relcam dir
		RelativeCamDirection();

		this.transform.LookAt( camTarget.position );                            //
	}
	//----------------------------------------------------------------------------------------------------------
	public float wrapAngle ( float Degree )
	{
		while (Degree < 0.0f)
		{
			Degree = Degree + 360.0f;
		}
		while (Degree >= 360.0f)
		{
			Degree = Degree - 360.0f;
		}
		return Degree;
	}

	private void UpdateOrientation( Vector3 forward_vector, Vector3 ground_normal )
	{
		Vector3
		projected_forward_to_normal_surface = forward_vector - ( Vector3.Dot( forward_vector, ground_normal ) ) * ground_normal;

		camRoot.transform.rotation = Quaternion.LookRotation( projected_forward_to_normal_surface, ground_normal );
	}

	float GetOffsetAngle( float targetAngle, float DestAngle )
	{
		return ((targetAngle - DestAngle + 180)% 360)  - 180; 
	}
	//----------------------------------------------------------------------------------------------------------
	void OnDrawGizmos()
	{
		Gizmos.DrawCube(
			camPivot.transform.position,
			new Vector3(1,1,1)
		);

		Gizmos.DrawCube(
			camTarget.transform.position,
			new Vector3(1,5,1)
		);

		Gizmos.DrawCube(
			camRoot.transform.position,
			new Vector3(1,1,1)
		);
	}

	void OnGUI()
	{
		GUI.Label(new Rect(0,80,1000,20*10), "targetObject.transform.up : " + targetObject.transform.up.ToString());
		GUI.Label(new Rect(0,100,1000,20*10), "target euler : " + targetObject.transform.eulerAngles.y.ToString());
		GUI.Label(new Rect(0,100,1000,20*10), "rot : " + rot.ToString());

	}
	//----------------------------------------------------------------------------------------------------------
	void RelativeCamDirection()
	{   


	}
}