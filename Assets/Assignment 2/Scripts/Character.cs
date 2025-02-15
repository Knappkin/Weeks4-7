using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{

    public Slider panH;
    public Slider panV;
    public Slider zoomBar;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 pos = transform.position;

        transform.localScale = Vector3.one * zoomBar.value;

        pos.x = Mathf.Lerp(-5,5,panH.value)*-1;

        pos.y = Mathf.Lerp(-3,3,panV.value)*-1;

        transform.position = pos;

    }



}
