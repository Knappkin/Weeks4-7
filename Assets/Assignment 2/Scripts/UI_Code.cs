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
    TMP_Dropdown dropdown;
    public Image filtercolourUsed;
    GameObject filterUsed;
    GameObject picTimerUsed;
    GameObject flashUsed;
    float flashOpacity;
    public Color[] filtercolours;
    bool isOn;
    bool canFlash;

    float t;
    float startT;
    float flashT;
    float timedT;

    void Start()
    {
        filtercolours[0] = new Color(255, 0, 0, 0.1f);
        filtercolours[1] = new Color(0, 255, 0, 0.1f);
        filtercolours[2] = new Color(0, 0, 255, 0.1f);
        filtercolours[3] = new Color(255,255,0,0.1f);
        isOn = false;
        filter.SetActive(false);
        filtercolourUsed.color = filtercolours[0];
        filterDrop.SetActive(false);
        flashOpacity = 1;
        dropdown = filterDrop.GetComponent<TMP_Dropdown>();

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
            filter.SetActive(true);
            isOn = true;
            filterDrop.SetActive (true);
        }
        else
        {
            Destroy(filterUsed);
            isOn = false;
            filter.SetActive(false);
            filterDrop.SetActive (false);
        }
    }

    public void startTimer()
    {
        if (picTimerUsed == null)
        {
            canFlash = true;
            startT = t;
            picTimerUsed = Instantiate(picTimer, parentCanvas.transform);
        }

    }

    void createFlash()
    {
        flashT = t;
        flashUsed = Instantiate(flash, parentCanvas.transform);
        Destroy(flashUsed, 1);
    }

    public void changeFilter(int index)
    {
        filtercolourUsed.color = filtercolours[index];
        print(index);
        print(filtercolourUsed.color);

    }
}
