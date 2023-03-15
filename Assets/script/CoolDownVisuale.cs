using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CoolDownVisuale : MonoBehaviour
{
    [SerializeField]
    private Image imageCooldown;

    private ForcePlayer cD;
    private float cooldownTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        cD = GameObject.Find("Player").GetComponent<ForcePlayer>();
        imageCooldown.fillAmount= 0f;

    }

    // Update is called once per frame
    void Update()
    {

        if (cD.canDash == true)
        {   
            cooldownTimer = cD.dashingCooldown;
        }
        else
        {
            gondolo();
        }
    }

    private void gondolo()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer < 0.0f)
        {
            imageCooldown.fillAmount = 0.0f;
        } 
        else
        {
            imageCooldown.fillAmount = cooldownTimer / cD.dashingCooldown;
        }
    }
}
