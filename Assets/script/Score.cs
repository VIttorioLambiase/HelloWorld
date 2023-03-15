using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int money = 0;

    public Text textMoney;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Money :" + money);
        textMoney.text = "Score: " + money;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Money")
        {
            money = money + 100;
        }
    }

}
