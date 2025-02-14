using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{

    public Slider speedSlider;

    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
            speed = speedSlider.value;

        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
    }
}
