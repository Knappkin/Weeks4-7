using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn_Character : MonoBehaviour
{
    //adding reference to the character prefab
    public GameObject character;

    //adding reference to the sliders for the horizontal and vertical pans, as well as zoom bar
    public Slider panH;
    public Slider panV;
    public Slider zoomBar;

    //creating sprite arrays for both neutral sprites and the smiling sprites. Made public so that the sprites can be added to the array in the inspector ahead of time
    public Sprite[] neutralSprites;
    public Sprite[] smileSprites;

    //declaring a list to keep track of the characters that exist in the scene
   public List<GameObject> currentFrogs;

    //Object to hold each individual instance of the prefab
    GameObject spriteInstance;
    


    // Start is called before the first frame update
    void Start()
    {
        //initializing the list
        currentFrogs = new List<GameObject>();

        //spawns the first frog when the program starts
        spawnFrog();
       
    }

    //this function is triggered by the picture button. It makes any frogs on the scene smile, and starts the smile timer, which will cause the events of smiling and then leaving on the character script
    //Goes through each one to be safe, even though the first will likely be destroyed before this function is called, meaning there should only be 1 in the scene (index[0])
    public void takePic()
    {
        for(int i = 0; i < currentFrogs.Count; i++)
        {
            currentFrogs[i].GetComponent<Character>().isSmiling = true;
            currentFrogs[i].GetComponent<Character>().smileTimer();
        }
    
    }

    //function to spawn the frog. it is called through the character script, which tells this script when the picture has been taken and a new frog needs to be created
    //it instantiates a new instance of the frog prefab, and adds it to the list
    //Then it sets the spawner script reference in the character script to this script (sorry for using script so much in one sentence)
    //The position is set to 0, but will be immediately changed to whatever it should actually be by the character script

    public void spawnFrog()
    {
        spriteInstance = Instantiate(character, new Vector3(0, 0, 0), Quaternion.identity);


        currentFrogs.Add(spriteInstance);

        Character characterScript = spriteInstance.GetComponent<Character>();
        characterScript.spawner = this;
    }
}
