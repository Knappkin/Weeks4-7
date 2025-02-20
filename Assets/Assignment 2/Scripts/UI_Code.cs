using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Code : MonoBehaviour
{
    //adding an animation curve to control the fading of the flash after a picture is taken
    public AnimationCurve flashCurve;

    //reference to ui filter image object
    public GameObject filter;

    //adding reference to the flash image prefab, so that it can be created by this script when the timer ends
    public GameObject flash;

    //getting the ui canvas so that timer and flash can later be created and specified as children of the ui
    public GameObject parentCanvas;

    //reference to the timer prefab, so it can be created by the script when the picture button is clicked
    public GameObject picTimer;

    //reference to the dropdown object so that it can be enabled and disabled when the filter button is clicked
    public GameObject filterDrop;

    //reference to the ui image image component
    public Image filtercolourUsed;

    //gameobject for each instance of the timer prefab being created
    GameObject picTimerUsed;

    //gameobject for each instance of the flash prefab being created
    GameObject flashUsed;

    //float value for the opacity of the flash image. The opacity is based on a value between 0 and 1
    float flashOpacity;

    //array of the colour values that the filter dropdown stores
    public Color[] filtercolours;

    //boolean to check if the filter is on or not. This is so that the filter will turn off it is already on, or on if it is off
    bool isOn;

    //boolean to control if the camera can flash. This is to prevent a looping flash when the timer goes off, instead only hapening once
    bool canFlash;

    //float t for time
    float t;

    //float to hold the time that the timer buttons is pressed and the timer starts. this controls the value of the timer slider
    float startT;
  
    //float to hold the time of when the flash starts, so that the animation curve will start at 0 once it goes off
    float flashT;


    void Start()
    {
        //Adding the colours of the filter to the array
        filtercolours[0] = new Color(255, 0, 0, 0.1f);//red
        filtercolours[1] = new Color(0, 255, 0, 0.1f);//green
        filtercolours[2] = new Color(0, 0, 255, 0.1f);//blue
        filtercolours[3] = new Color(255,255,0,0.1f);//yellow

        //set the filter to off at the start
        isOn = false;

        //disabling the filter at the start
        filter.SetActive(false);

        //setting the default filter colour to the first in the array (red)
        filtercolourUsed.color = filtercolours[0];

        //disabling the drop down at the start, so that it only shows when a filter is actually being applied
        filterDrop.SetActive(false);

        //setting the base flash opacity to 1 (fully opaque)
        flashOpacity = 1;

    }

    // Update is called once per frame
    void Update()
    {

        //adding time to the t variable
        t += Time.deltaTime;


        //an if statement to check if there is a picture timer currently in the scene
        if (picTimerUsed != null )
        {
            //if there is, set the value to time - the time that it was created
            picTimerUsed.GetComponent<Slider>().value = t - startT;


            //if the value reaches 3(seconds), then destroy the timer
            if(picTimerUsed.GetComponent<Slider>().value >= 3 )
            {

                Destroy(picTimerUsed);
            }
        }

        //if statement to check if an instance of flash exists
        if (flashUsed != null )
        {
            //if it does, set the opacity to the value of the animation curve at the time since the instance was created
            flashOpacity = flashCurve.Evaluate(t-flashT);

            //set the flash image object to the image component of the flash instance, so that the color value can then be accessed. It is white, with an opacity of the flashOpacity value
           Image flashImage = flashUsed.GetComponent<Image>();
            flashImage.color = new Color(255, 255, 255, flashOpacity);
           
        }

      //if the camera can flash and the time since the pic button was pressed reaches 3 seconds
        if (canFlash && picTimerUsed.GetComponent<Slider>().value >= 3)
        {
            //create an instance of the flash. then set can flash to false so only one instance can be created
            createFlash();
            canFlash = false;
        }
    }


    //a function to turn the filter on/off. Is triggered by the filter button
    public void addFilter()
    {
        //if the filter is off, then turn it on and activate the dropdown to show as well
        if (!isOn)
        {
            filter.SetActive(true);
            isOn = true;
            filterDrop.SetActive (true);
        }
        else
        {
            //if it is already on, turn it off and hide the dropdown
            isOn = false;
            filter.SetActive(false);
            filterDrop.SetActive (false);
        }
    }

    //a function to start the timer. Triggered by the take picture button
    public void startTimer()
    {
        //if there is no pic timer already (prevents overlapping, or multiple countdowns at once
        if (picTimerUsed == null)
        {
            //set it so that the camera can flash once the timer goes off
            canFlash = true;
            //set the time that the button was pressed
            startT = t;
            //create an instance of the timer prefab, create it as a child of the ui canvas so that it is visible in scene
            picTimerUsed = Instantiate(picTimer, parentCanvas.transform);
        }

    }

    //a function that is called once the timer finishes
    void createFlash()
    {
        //sets the flash start time to current time
        flashT = t;

        //creates an instance of the flash prefab, also as a child of the ui canvas
        flashUsed = Instantiate(flash, parentCanvas.transform);

        //set it to destroy after one second (aka the length of the animation curve)
        Destroy(flashUsed, 1);
    }

    //a function triggered by the dropdown. It is given the index value of the dropdown object selected, which then sets the filter colour to the corresponding item in the colour array
    public void changeFilter(int index)
    {
        filtercolourUsed.color = filtercolours[index];

    }
}
