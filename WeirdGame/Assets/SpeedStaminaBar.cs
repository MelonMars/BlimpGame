using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedStaminaBar : MonoBehaviour {

    public GameObject blimp;
    public BlimpController blimpController;
    private Image stamina;

    // Start is called before the first frame update
    void Start()
    {
        blimpController = blimp.GetComponent<BlimpController>();
        stamina = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        stamina.fillAmount = blimpController.privateStamina / blimpController.maxStamina;
    }
}
