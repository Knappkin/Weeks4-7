using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn_Character : MonoBehaviour
{
    public GameObject character;

    public Slider panH;
    public Slider panV;
    public Slider zoomBar;
    public Sprite[] neutralSprites;
    public Sprite[] smileSprites;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(character, new Vector3(3,0,0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
