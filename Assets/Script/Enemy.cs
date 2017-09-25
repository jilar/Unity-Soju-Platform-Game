using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject player;
	public float speed;

	// Update is called once per frame
	void Update () {
		float spd = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, player.transform.position, spd);
	}
}
