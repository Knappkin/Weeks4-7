using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Character : MonoBehaviour
{
    public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(character, new Vector3(3,0,0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
