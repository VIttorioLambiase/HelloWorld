using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    PlayerLife pl;
    int objective = 0;
    public TextMeshProUGUI textWin;
    public TextMeshProUGUI textWinUltimate;
    public Image sfondo;
    public Image sfondo2;

    void Start()
    {
        pl = GameObject.Find("Player").GetComponent<PlayerLife>();
    }

    void Update()
    {
        if (objective == 1 && pl.objCount != 3)
        {
            textWin.gameObject.SetActive(true);
            sfondo2.gameObject.SetActive(true);
            Time.timeScale = 0;
            if (Input.GetKeyUp("space"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        }
        else
        {
            if (objective == 1 && pl.objCount == 3)
            {
                textWinUltimate.gameObject.SetActive(true);
                sfondo.gameObject.SetActive(true);
                Time.timeScale = 0;
                if (Input.GetKeyUp("space"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Objective")
        {
            objective = objective + 1;
        }
    }
}
