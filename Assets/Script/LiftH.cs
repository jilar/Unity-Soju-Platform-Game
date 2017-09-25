using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftH : MonoBehaviour {

	public float height;
	public float offset;

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (Mathf.PingPong (2*Time.time, height)+offset, transform.position.y, transform.position.z);
	}

}
