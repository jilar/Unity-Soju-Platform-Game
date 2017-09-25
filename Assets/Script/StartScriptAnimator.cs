using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScriptAnimator : MonoBehaviour {

    public GameObject otherObject;
    public GameObject playerObject;
    public Canvas WinScreen;
    // Use this for initialization
    void Start () {
        StartCoroutine("EnableScript");
        WinScreen = WinScreen.GetComponent<Canvas>();
        WinScreen.enabled = false;
    }

    IEnumerator EnableScript()
    {
        yield return new WaitForSeconds(4f);
        otherObject.GetComponent<Camera>().enabled = true;
        playerObject.GetComponent<Player>().enabled = true;
        //Camera.enabled = true;
    }
}
