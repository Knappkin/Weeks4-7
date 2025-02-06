using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float speed = 10f;
    public GameObject bubble;
    public Image reaction;
    public GameObject item;
    public Sprite[] reactionOptions;
    bool check = false;
    bool lastCheck;

    // Start is called before the first frame update
    void Start()
    {
       bubble.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);

        if((item.transform.position - transform.position).magnitude < 2)
        {
            check = true;
            if(check != lastCheck)
            {
                setReaction();
            }
            bubble.SetActive(true);
        }
        else
        {
            bubble.SetActive(false);
            check = false;
        }

        lastCheck = check;
    }

    void setReaction()
    {
        reaction.sprite = reactionOptions[Random.Range(0, reactionOptions.Length)];

    }
}
