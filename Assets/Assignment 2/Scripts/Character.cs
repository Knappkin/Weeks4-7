using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    float zoomLevel = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // zoom_Pic();
        transform.localScale = Vector3.one * zoomLevel;
    }

    public void zoom_Pic(float s)
    {
        zoomLevel = s;
 
    }
}
