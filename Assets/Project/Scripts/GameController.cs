using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Player player;

	public GameObject target;

	public GameObject floor;

    private float resetTimer;

    private float margin;

	private byte side;

	// Use this for initialization
	void Start () {
		resetTimer = 5f;
		side = 0;
        margin = 4f;
	}

    //Spawn the target pole at a new position for the next throw
	void SpawnTargetAtANewLocation() {

		float scaleX = floor.transform.localScale.x / 2;
		float scaleZ = floor.transform.localScale.z / 2;

		float randomX, randomZ;
		if (side == 0) {
			randomX = Random.Range (-scaleX, -scaleX + margin);
			randomZ = Random.Range (-scaleZ / 2, scaleZ / 2);
		} else if (side == 1) {
			randomX = Random.Range (-scaleX / 2, scaleX / 2);
			randomZ = Random.Range (scaleZ, scaleZ - margin);
		} else if (side == 2) {
			randomX = Random.Range (scaleX - margin, scaleX);
			randomZ = Random.Range (-scaleZ / 2, scaleZ / 2);
		} else {
			randomX = Random.Range (-scaleX / 2, scaleX / 2);
			randomZ = Random.Range (-scaleZ, -scaleZ + margin);
		}

		target.transform.position = new Vector3 (randomX, target.transform.position.y, randomZ);
	}

    //Rotate the target pole to face towards the center of the arena in its new position
	void RotateTargetFacingCenter() {
		float angle;
		
		if (side == 0)
			angle = 0;
		else if (side == 1)
			angle = 90;
		else if (side == 2)
			angle = 180;
		else
			angle = 270;

		side = (byte)(((byte)++side) % 4);

		target.transform.rotation = Quaternion.AngleAxis (angle, Vector3.up);
	}

	// Update is called once per frame
	void Update () {
		if (player.HoldingBall == false) {
			resetTimer -= Time.deltaTime;
			if (resetTimer <= 0) {
				//SceneManager.LoadScene ("Game");

				SpawnTargetAtANewLocation();
				RotateTargetFacingCenter ();

				resetTimer = 5f;
				player.Reset ();
			}
		}
	}
}
