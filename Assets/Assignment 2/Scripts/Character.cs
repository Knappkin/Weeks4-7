using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    // Getting reference to the script from the character spawner
    public Spawn_Character spawner;

    //setting the max/min height and width for the character position (will be lerped to through slider)
    public float minHeight = 0.6f;
    public float maxHeight = 4;
    public float hPan;
    public float vPan;

    //t to get delta time // smile t to get time that smile starts
    float t;
    float smileT;

    //boolean for controlling whether to show smiling sprite
    public bool isSmiling = false;

    //boolean to control the initial movement onto the screen. Once the character is far enough, it is set to false, stops moving
    bool firstMove;

    //int to keep track of which sprite to use, so the matching one can be found in the other sprite array. Arrays contain the matching sprites at the same index values, so the value can be saved and used
    int whichChar;

    //bool to control whether or not to move the character (specifically for second movement)
    public bool startMoving = false;

    //an amount added to the position to offset it by how much the character has moved
    public float moveDist;


    void Start()
    {
    // When a character is created, they are set to move at the beginning, and are given a random sprite out of the array.
    // Then the sprite is set to the neutral version
    //Initial offset is set to start the character off the right side of the screen
        firstMove = true;
        whichChar = Random.Range(0, 6);
        gameObject.GetComponent<SpriteRenderer>().sprite = spawner.neutralSprites[whichChar];
          moveDist = -10;
    }

    // Update is called once per frame
    void Update()
    {
        //adding delta time to t
        t += Time.deltaTime;

        //sets the smile t to t whenever the character is not smiling, so that the difference will not reach 3, which would trigger movement
        if (!isSmiling)
        {
            smileT = t;
        }

        //creating a pos variable to change the x and y positions of the character
        Vector2 pos = transform.position;

        //setting the horizontal and vertical pan values to the slider values being sent to the spawner script
        hPan = spawner.panH.value;
        vPan = spawner.panV.value;

        //setting the scale of the character to the value of the zoom bar, which it gets by accessing the spawner script (where the zoom bar sends its value)
        transform.localScale = Vector3.one * spawner.zoomBar.value;

        //setting the x position of the character. It is based on the horizontal pan slider value, which is the lerped to be between 2 points.
        //It is multiplied by -1 so that it moves in the opposite direction of the slider being dragged
        //moveDist subtracted to add the offset of movement

        pos.x = Mathf.Lerp(-4,4,hPan)*-1 - moveDist;

        //setting the y position as a lerp of the min and max height. Stored as public variables so that I could find a good number in the inspector that makes sure the leg cut-off is never shown on screen.
        // also multiplied by -1 to move in opposite direction, but no offset is needed
        pos.y = Mathf.Lerp(minHeight,maxHeight,vPan)*-1;

        transform.position = pos;

        //getting the screen position of the character, so that it knows when it has left screen and should be destroyed
        Vector2 screenPos = Camera.main.WorldToScreenPoint(pos);
       

        //if the smiling boolean is true, then set the sprite to the smiling version
        if (isSmiling )
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spawner.smileSprites[whichChar];
        }


        //making it so that once the character has been smiling for 3 seconds, they stop smiling, and start walking left (off screen).
        //At the same time, the spawner script is accessed and told to spawn the next frog
        if (t-smileT > 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spawner.neutralSprites[whichChar];
            isSmiling = false;
            smileT = 0;
            startMoving = true;
            spawner.spawnFrog();
        }

        //moves the frog to the left over time, eventually leaving the screen
        if (startMoving )
        {
            moveDist += 3 * Time.deltaTime;
        }

        //if the character leaves the screen, they are removed from the array in the spawner script, and then destroyed
        // added padding so that the character will fully leave the screen before being destroyed, no matter the zoom level
        if (screenPos.x < -100)
        {
            spawner.currentFrogs.Remove(gameObject);
            Destroy(gameObject);
        }

        //Moves from right edge onto screen after being spawned. Will stop halfway across screen
        if (firstMove && screenPos.x > Screen.width/2)
        {
            moveDist += 3 * Time.deltaTime;
        } 



    }
    
    
    //function called by the spawner script when the picture button is pressed. Will set the smile time to current t, so the script can track once its been 3 seconds
    public void smileTimer()
    {
        smileT = t;
    }

}
