using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float walkSpeed = 4;
	public float runSpeed = 6;
	public float gravity = -9.81f;
	public float jumpHeight = 2f;
	[Range(0,1)]
	public float airControlPercent;

	public float turnSmoothTime = 0.5f;
	float turnSmoothVelocity;

	public float speedSmoothTime = 0.5f;
	float speedSmoothVelocity;
	float currentSpeed;
	float velocityY;

	Animator animator;
	Transform cameraT;
	CharacterController controller;

	// joystick 
    protected Joystick joystick;
    protected Joybutton joybutton;

    protected bool jump;


	void Start () {
		animator = GetComponent<Animator> ();
		cameraT = Camera.main.transform;
		controller = GetComponent<CharacterController> ();
		// joysticks
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
	}

	void Update () {
		// input
			Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal") + (joystick.Horizontal * 50f), Input.GetAxisRaw ("Vertical") + (joystick.Vertical * 50f));
			Vector2 inputDir = input.normalized;
			bool running = Input.GetKey (KeyCode.LeftShift);

			Move (inputDir, running);
		if (Input.GetKeyDown (KeyCode.Space) || (joybutton.Pressed || Input.GetButton("Fire2"))) {
			Jump ();
		}
			// animator - only works well for keyboard
			float animationSpeedPercent;
			animationSpeedPercent = ((running) ? currentSpeed / runSpeed : currentSpeed / walkSpeed * 0.5f);
			if ((joystick.Horizontal > 0.01) || (joystick.Vertical > 0.01)) {
				animationSpeedPercent = currentSpeed / (walkSpeed * 0.5f);
			}
			animator.SetBool ("walk", true);
			animator.SetFloat ("velocity", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
			if (animationSpeedPercent < 0.01) animator.SetBool ("walk", false);
		

	}

	void Move(Vector2 inputDir, bool running) {
		// rotation
		if (inputDir != Vector2.zero) {
			float targetRotation = Mathf.Atan2 (inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime));
		}
		float targetSpeed;
		if ((joystick.Horizontal > 0.01) || (joystick.Vertical > 0.01)) {
			targetSpeed = walkSpeed;
		} else {
			targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
		}
		currentSpeed = Mathf.SmoothDamp (currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothTime));

		velocityY += Time.deltaTime * gravity;
		Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;

		controller.Move (velocity * Time.deltaTime);
		currentSpeed = new Vector2 (controller.velocity.x, controller.velocity.z).magnitude;

		if (controller.isGrounded) {
			velocityY = 0;
		}

	}

	void Jump() {
		if (controller.isGrounded) {
			float jumpVelocity = Mathf.Sqrt (-2 * gravity * jumpHeight);
			velocityY = jumpVelocity;
		}
	}

	float GetModifiedSmoothTime(float smoothTime) {
		if (controller.isGrounded) {
			return smoothTime;
		}

		if (airControlPercent == 0) {
			return float.MaxValue;
		}
		return smoothTime / airControlPercent;
	}
}

// To be use without player controller
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     public FixedJoystick moveJoystick;
//     public FixedJoystick lookJoystick;
//     // Update is called once per frame
//     void Update()
//     {
//         UpdateMoveJoystick();
//         UpdateLookJoystick();
//     }

//     void UpdateMoveJoystick()
//     {
//         float hoz = moveJoystick.Horizontal;
//         float ver = moveJoystick.Vertical;
//         Vector2 convertedXY = ConvertWithCamera(Camera.main.transform.position, hoz, ver);
//         Vector3 direction = new Vector3(convertedXY.x, 0, convertedXY.y).normalized;
//         transform.Translate(direction * 2.0f, Space.World);
//     }

//     void UpdateLookJoystick()
//     {
//         float hoz = lookJoystick.Horizontal;
//         float ver = lookJoystick.Vertical;
//         Vector2 convertedXY = ConvertWithCamera(Camera.main.transform.position, hoz, ver);
//         Vector3 direction = new Vector3(convertedXY.x, 0, convertedXY.y).normalized;
//         Vector3 lookAtPosition = transform.position + direction;
//         transform.LookAt(lookAtPosition);
//     }


//     private Vector2 ConvertWithCamera(Vector3 cameraPos, float hor, float ver)
//     {
//         Vector2 joyDirection = new Vector2(hor, ver).normalized;
//         Vector2 camera2DPos = new Vector2(cameraPos.x, cameraPos.z);
//         Vector2 playerPos = new Vector2(transform.position.x, transform.position.z);
//         Vector2 cameraToPlayerDirection = (Vector2.zero - camera2DPos).normalized;
//         float angle = Vector2.SignedAngle(cameraToPlayerDirection, new Vector2(0, 1));
//         Vector2 finalDirection = RotateVector(joyDirection, -angle);
//         return finalDirection;
//     }

//     public Vector2 RotateVector(Vector2 v, float angle)
//     {
//         float radian = angle * Mathf.Deg2Rad;
//         float _x = v.x * Mathf.Cos(radian) - v.y * Mathf.Sin(radian);
//         float _y = v.x * Mathf.Sin(radian) + v.y * Mathf.Cos(radian);
//         return new Vector2(_x, _y);
//     }
// }