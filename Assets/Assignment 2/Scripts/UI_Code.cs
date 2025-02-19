using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Code : MonoBehaviour
{
    public AnimationCurve flashCurve;
    public GameObject filter;
    public GameObject flash;
    public GameObject parentCanvas;
    public GameObject picTimer;
    public GameObject filterDrop;
    GameObject filterUsed;
    GameObject picTimerUsed;
    GameObject flashUsed;
    float flashOpacity;

    bool isOn;
    bool canFlash;

    float t;
    float startT;
    float flashT;
    float timedT;

    void Start()
    {
        isOn = false;

        filterDrop.SetActive(false);
        flashOpacity = 1;

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        if (picTimerUsed != null )
        {
            picTimerUsed.GetComponent<Slider>().value = t - startT;

            if(picTimerUsed.GetComponent<Slider>().value >= 3 )
            {

                Destroy(picTimerUsed);
            }
        }

        if (flashUsed != null )
        {
            flashOpacity = flashCurve.Evaluate(t-flashT);
           Image flashImage = flashUsed.GetComponent<Image>();
            flashImage.color = new Color(255, 255, 255, flashOpacity);
           
        }

        if (flashOpacity <= 0)
        {
            Destroy(flashUsed);
        }
        {
            
        }
        if (canFlash && picTimerUsed.GetComponent<Slider>().value >= 3)
        {
            createFlash();
            canFlash = false;
        }
    }


    public void addFilter()
    {
        if (!isOn)
        {
         filterUsed = Instantiate(filter, parentCanvas.transform);
            isOn = true;
            filterDrop.SetActive (true);
        }
        else
        {
            Destroy(filterUsed);
            isOn = false;
            filterDrop.SetActive (false);
        }
    }

    public void startTimer()
    {
        canFlash = true;
        startT = t;
        picTimerUsed = Instantiate (picTimer, parentCanvas.transform);

    }

    void createFlash()
    {
        flashT = t;
        flashUsed = Instantiate(flash, parentCanvas.transform);
        Destroy(flashUsed, 1);
    }
}
