using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishJump : MonoBehaviour {
    public int height = 100;
    public GameObject fish;
    public int calculate = 5;
    public int strength = 5;
	// Use this for initialization
	void Start () {
        StartCoroutine(jump());
    }

    void Update()
    {
        //Jumping
        Rigidbody rigidbody = fish.GetComponent<Rigidbody>();
       // transform.Rotate(Vector3.up * (Time.deltaTime * 5 * strength));
    }

    IEnumerator jump()
    {
        while (true)
        {
            Rigidbody rigidbody = fish.GetComponent<Rigidbody>();
            rigidbody.velocity = new Vector3(0, 2 * height, 0);
            yield return new WaitForSeconds(calculate);
        }
    }

}
