using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{

    public Image Objective1;
    public Image Objective2;
    public Image Objective3;
    public int objCount = 0;

    public ForcePlayer dash;

    public int HP = 5;
    
    public Text textHP;

    public TextMeshProUGUI textLose;
    public GameObject player;

    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("HP :" + HP);
        textHP.text = "HP " + HP;
        if (HP <= 0)
        {
            isDead = true;
        }
        if (isDead)
        {
            player.SetActive(false);
            textLose.gameObject.SetActive(true);
            Time.timeScale = 0;
            if (Input.GetKeyUp("space"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
            }
        }

        if (objCount == 1)
        {
            Objective1.gameObject.SetActive(true);
        }
        if (objCount == 2)
        {
            Objective2.gameObject.SetActive(true);
        }
        if (objCount == 3)
        {
            Objective3.gameObject.SetActive(true);
        }
    }
 
    void OnCollisionEnter(Collision Collision) {
        if (Collision.gameObject.tag == "Enemy" && dash.isDashing == false) 
        {
            Debug.Log("Collision");
            HP = HP-1;
        }

        if (Collision.gameObject.tag == "Spines" || Collision.gameObject.tag == "DeathZone")
        {
            HP = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeathZone")
        {
            HP = 0;
        }
    }
}
