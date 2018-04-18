using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerController_RB : MonoBehaviour {

    // movement
    public float speed = 15.0f;
    private Vector3 moveDirection;
    private Rigidbody playerRigidBody;
    private Transform playerMesh;

    public int currentWorld = 0;
	public VirtualJoystick joystick;

    // Use this for initialization
    void Start() {
        playerRigidBody = GetComponent<Rigidbody>();
        playerMesh = transform.GetChild(0).transform;
    }

    // Update is called once per frame
    void Update() {
        // update move direction
		moveDirection = new Vector3(joystick.Horizontal(), 0, joystick.Vertical()).normalized;
    }

    void FixedUpdate()
    {
        // update movement
        playerRigidBody.MovePosition(playerRigidBody.position + transform.TransformDirection(moveDirection * speed * Time.fixedDeltaTime));
        // rotate player to face the right direction
        RotatePlayer();
    }

    // Rotate player to face direction of movement
    void RotatePlayer()
    {
        Vector3 dir = moveDirection;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.up);
        if (Vector3.Magnitude(dir) > 0.0f)
        {
            playerMesh.localRotation = targetRotation;
        }
    }
		
}
