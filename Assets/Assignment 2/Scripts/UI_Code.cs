using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Code : MonoBehaviour
{

    public GameObject filter;
    public GameObject parentCanvas;
    public GameObject picTimer;
    GameObject filterUsed;
    GameObject picTimerUsed;

    bool isOn;

    float t;
    float startT;
    float timedT;

    void Start()
    {
        isOn = false;

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        if (picTimerUsed != null )
        {
            picTimerUsed.GetComponent<Slider>().value = t - startT;
        }
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
        startT = t;
        picTimerUsed = Instantiate (picTimer, parentCanvas.transform);
        Destroy(picTimerUsed, 3);
        //timer.enabled = true;
    }
}
