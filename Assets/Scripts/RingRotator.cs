using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RingRotator : MonoBehaviour
{
    float timeLeft;
    Color targetColor;

    public bool rainbowColors;
    public float rotationSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed);
        if (rainbowColors)
        {
            if (timeLeft <= Time.deltaTime)
            {
                // transition complete
                // assign the target color
                GetComponent<Image>().color = targetColor;

                // start a new transition
                targetColor = new Color(Random.value, Random.value, Random.value);
                timeLeft = 1.0f;
            }
            else
            {
                // transition in progress
                // calculate interpolated color
                GetComponent<Image>().color = Color.Lerp(GetComponent<Image>().color, targetColor, Time.deltaTime / timeLeft);

                // update the timer
                timeLeft -= Time.deltaTime;
            }
        }



    }
}
