using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{

    private Image progress;
    public float current;
    public float max;
    
    void Start()
    {
        progress = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        progress.fillAmount = current / max;
    }
}
