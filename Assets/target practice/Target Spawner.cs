using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{

    public GameObject targetPrefab;
    public int targetNum = 5;
    public GameObject egg;
    public List<GameObject> targets;
    // Start is called before the first frame update
    void Start()
    {
        targets = new List<GameObject>();

        for (int i = 0; i< targetNum; i++)
        {
            GameObject newTarget = Instantiate(targetPrefab);
            newTarget.transform.position = Random.insideUnitCircle * 5;
            
            target t = newTarget.GetComponent<target>();
            t.spawner = this;
            
            targets.Add(newTarget);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targets.Count == 0)
        {
           egg.SetActive(true);
        }
    }

    public void TargetHit(GameObject t)
    {
        targets.Remove(t);
    }
}
