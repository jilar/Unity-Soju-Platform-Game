using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour {

   
    //public Image checkpointImage;
  
    public GameObject flagWavy;
    public double target = 4.156;
    public int liftSpeed = 5;
    public bool activate = false;
 
    void start()
    {
        //checkpointImage = checkpointImage.GetComponent<Image>();

    }

    void Update()
    {
        if (activate == true)
        {
            if (flagWavy.transform.position.y < 4.85)
            {
                flagWavy.transform.Translate(Vector3.right * 2 * Time.deltaTime);
            }
        }
    }

            void OnTriggerEnter (Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            DeclaredVariables.checkpoints = transform.position;
            // flagWavy.transform.position = Vector3.Lerp(flagWavy.transform.position, target, Time.deltaTime * liftSpeed);
            //  while (flagWavy.transform.position.y != 4.156)
            // {
            activate = true;


            // }
            
        }
    }


}