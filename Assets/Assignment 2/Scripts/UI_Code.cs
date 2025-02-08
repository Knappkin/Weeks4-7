using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Code : MonoBehaviour
{

    public GameObject filter;
    public GameObject parentCanvas;
    GameObject filterUsed;
    bool isOn;
    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addFilter()
    {
        if (!isOn)
        {
         filterUsed = Instantiate(filter, parentCanvas.transform);
            isOn = true;
        }
        else
        {
            Destroy(filterUsed);
            isOn = false;
        }
    }

    public void startTimer()
    {

    }
}
