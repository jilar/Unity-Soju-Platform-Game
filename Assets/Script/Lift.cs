using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour {

	public float height;
	public float offset;

    // Update is called once per frame
    void Update () {
		transform.position = new Vector3 (transform.position.x, Mathf.PingPong (2*Time.time, height)+offset, transform.position.z);
	}



}
