using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Code : MonoBehaviour
{

    public GameObject filter;
    public GameObject parentCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addFilter()
    {
        Instantiate(filter, parentCanvas.transform);
    }
}
