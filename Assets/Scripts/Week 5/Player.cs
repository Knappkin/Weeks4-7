using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 10f;
    public GameObject reaction;
    public GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        reaction.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);

        if((item.transform.position - transform.position).magnitude < 2)
        {
            reaction.SetActive(true);
        }
        else
        {
            reaction.SetActive(false);
        }
    }
}
