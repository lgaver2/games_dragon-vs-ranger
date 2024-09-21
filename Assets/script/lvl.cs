using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class lvl : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject spw;
    public GameObject present;
    int lv;
    int num;
    void Start()
    {
        spw = GameObject.Find("spawndirecot");
        lv = spw.GetComponent<spawnd>().lvl();
        num = spw.GetComponent<spawnd>().nume();
        if (lv != 7 + 10 * (num-1))
        {
            present.SetActive(false);
        }
        this.gameObject.GetComponent<TextMeshProUGUI>().text = "Level " + lv.ToString("F0");
        Invoke("efface", 5f);
    }
    void efface()
    {
        this.gameObject.GetComponent<TextMeshProUGUI>().text = "";
        if (lv != 7 + 10 * (num-1))
        {
            GameObject p = GameObject.FindWithTag("present");
            Destroy(p);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
