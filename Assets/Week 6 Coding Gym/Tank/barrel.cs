using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel : MonoBehaviour
{
    public GameObject bulletPrefab;
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector2 direction = mousePos - transform.position;
        transform.up = direction;

        if (Input.GetMouseButtonDown(0))
        {
            SpawnBullet();
        }
    }

    void SpawnBullet()
    {

        GameObject bullet =  Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        bullet_tank bulletScript = bullet.GetComponent<bullet_tank>();

        bulletScript.speed = 3;
    }
}
