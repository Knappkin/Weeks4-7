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

   public List<GameObject> currentFrogs;
    GameObject spriteInstance;
    


    // Start is called before the first frame update
    void Start()
    {
        currentFrogs = new List<GameObject>();

        spawnFrog();
       
    }


    public void takePic()
    {
        for(int i = 0; i < currentFrogs.Count; i++)
        {
            currentFrogs[i].GetComponent<Character>().isSmiling = true;
            currentFrogs[i].GetComponent<Character>().smileTimer();
        }
    
    }

    public void spawnFrog()
    {
        spriteInstance = Instantiate(character, new Vector3(0, 0, 0), Quaternion.identity);


        currentFrogs.Add(spriteInstance);

        Character characterScript = spriteInstance.GetComponent<Character>();
        characterScript.spawner = this;
    }
}
