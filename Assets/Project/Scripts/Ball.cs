using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public ParticleSystem trailParticles;

	// Use this for initialization
	void Start () {
		ActivateTrail (false);
	}

    public void Reset()
    {
        UseGravity(false);
        ActivateTrail(false);
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

	public void ActivateTrail(bool activate) {
        if (activate)
            trailParticles.Play();
        else
        {
            trailParticles.Pause();
            trailParticles.Clear();
        }
	}

	public void UseGravity(bool isActive) {
		GetComponent<Rigidbody> ().useGravity = isActive;
	}
}
