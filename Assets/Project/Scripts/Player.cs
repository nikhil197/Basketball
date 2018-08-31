using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//Object to represent the ball
	public Ball ball;

	//Object to represent the controller(Camera) of the player
	public GameObject playerCamera;

	//Distance between the ball the player camera / controller
	private const float ballDistance = 1.75f;

    //Maximum force that can be applied to the ball
    private const float maxBallThrowingForce = 650f;

    //Default force that will be applied on simple click
	private float ballThrowingForce;

    //Whether the player is holding the ball or not
	public bool HoldingBall { get; set; }

    //Time when user clicks the mouse button
    private float mouseButtonClickTime;

    //Time when user releases the mouse button
    private float mouseButtonReleaseTime;

	// Use this for initialization
	void Start () {
        Reset();
	}

    //Reset the data for next throw
	public void Reset() {
		HoldingBall = true;
        ballThrowingForce = 450f;
        ball.Reset();
	}

	// Update is called once per frame
	void Update () {
		if (HoldingBall) {
			ball.transform.position = playerCamera.transform.position + playerCamera.transform.forward * ballDistance;

            if(Input.GetMouseButtonDown(0))
            {
                mouseButtonClickTime = Time.time;
            }

			else if (Input.GetMouseButtonUp (0)) {
                mouseButtonReleaseTime = Time.time;
				HoldingBall = false;
				ball.ActivateTrail (true);
				ball.UseGravity(true);

                float mouseButtonHoldTime = mouseButtonReleaseTime - mouseButtonClickTime;
                mouseButtonHoldTime = mouseButtonHoldTime > 1 ? mouseButtonHoldTime : 1;

                ballThrowingForce *= mouseButtonHoldTime;
                ballThrowingForce = ballThrowingForce > maxBallThrowingForce ? maxBallThrowingForce : ballThrowingForce;

                Debug.Log(ballThrowingForce);

				ball.GetComponent<Rigidbody> ().AddForce(playerCamera.transform.forward * ballThrowingForce, ForceMode.Force);
			}
		}
	}
}
