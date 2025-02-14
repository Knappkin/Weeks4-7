using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_tank : MonoBehaviour
{
    
    Vector2 direction;
   public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
      
       direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = direction;
        direction = direction.normalized;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 pos = transform.position;
        pos += direction * speed * Time.deltaTime;
        transform.position = pos;

        Destroy(gameObject, 3);
    }
}
