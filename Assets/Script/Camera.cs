using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    
	public GameObject player;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		//offset = transform.position - new Vector3 (player.transform.position.x, 0, 0);   

	}

	// Update is called once per frame
	void LateUpdate () {
		//transform.position = new Vector3 (player.transform.position.x, 0, 0) + offset;
		offset =new Vector3 (player.transform.position.x, 0, 0); 
		transform.position += offset;
	}
    
}
