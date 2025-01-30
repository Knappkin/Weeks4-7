using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wiggle : MonoBehaviour
{
    public Image uiImage;
    public AnimationCurve wiggleCurve;
    public float t;
    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        t = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        t += Time.deltaTime;

        if(t> 1)
        {
            t = 0f;
        }

        if (uiImage.sprite.bounds.Contains(mousePos))
        {
            transform.localScale = Vector2.one * wiggleCurve.Evaluate(t) + new Vector2(0.5f,0.5f);
        }
    }
}
