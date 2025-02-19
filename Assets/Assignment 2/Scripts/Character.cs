using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{

    public Spawn_Character spawner;

    public float minHeight = 0.6f;
    public float maxHeight = 4;
    public float hPan;
    public float vPan;

    float t;
    float smileT;

    public bool isSmiling = false;

    int whichChar;

    public bool startMoving = false;

    public float moveDist;

    // Start is called before the first frame update
    void Start()
    {

        whichChar = Random.Range(0, 6);
        gameObject.GetComponent<SpriteRenderer>().sprite = spawner.neutralSprites[whichChar];
        print(whichChar);
    }

    // Update is called once per frame
    void Update()
    {
    
        if (!isSmiling)
        {
            smileT = t;
        }
        t += Time.deltaTime;
        Vector2 pos = transform.position;

        hPan = spawner.panH.value;
        vPan = spawner.panV.value;

        transform.localScale = Vector3.one * spawner.zoomBar.value;

        pos.x = Mathf.Lerp(-5,5,hPan)*-1 - moveDist;

        pos.y = Mathf.Lerp(minHeight,maxHeight,vPan)*-1;

        transform.position = pos;

        Vector2 screenPos = Camera.main.WorldToScreenPoint(pos);


        if (isSmiling )
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spawner.smileSprites[whichChar];
        }

        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spawner.neutralSprites[whichChar];
        }

        if (t-smileT > 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spawner.neutralSprites[whichChar];
            isSmiling = false;
            smileT = 0;
            startMoving = true;
            spawner.spawnFrog();
        }

        if (startMoving )
        {
            moveDist += 3 * Time.deltaTime;
        }

        if (screenPos.x < -50)
        {
            spawner.currentFrogs.Remove(gameObject);
            Destroy(gameObject);
        }

    }

    public void smileTimer()
    {
        smileT = t;
    }

}
