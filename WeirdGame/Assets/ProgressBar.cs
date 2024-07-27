using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{

    private Image progress;
    private float current;
    private float max;
    public GameObject blimp;
    private BlimpController blimpController;
    
    void Start()
    {
        progress = this.GetComponent<Image>();
        blimpController = blimp.GetComponent<BlimpController>();
        max = blimpController.topSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        current = blimpController.speed;
        if (current / max > 0.7 && current/max < 0.95) {
            progress.color = Color.yellow;
        } else if (current / max > 0.95)
        {
            progress.color = Color.red;
        } else
        {
            progress.color = Color.green;
        }
        progress.fillAmount = current / max;
    }
}
