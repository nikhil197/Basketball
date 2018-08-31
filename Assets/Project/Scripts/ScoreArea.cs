using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour {

	public ParticleSystem effectObject;

    void Start()
    {
        effectObject.Pause();
    }

    private void OnTriggerEnter(Collider otherCollider) {
		if (otherCollider.GetComponent<Ball> () != null && otherCollider.GetComponent<Rigidbody>().useGravity) {
			effectObject.Play ();
			Debug.Log ("Score");
		}
	}
}
