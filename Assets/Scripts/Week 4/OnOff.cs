using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : MonoBehaviour

{

    public SpriteRenderer sr;
    public OnOff script;
    public GameObject go;
    public AudioSource audioS;
    public AudioClip clip;
  
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            sr.enabled = false;
            //script.enabled = false;
            go.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            sr.enabled = true;
            //script.enabled = true;
            go.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if(audioS.isPlaying == false)
            {
                audioS.PlayOneShot(clip);
            }
          
        }
    }
}
