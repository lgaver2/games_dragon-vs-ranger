using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class settings : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    public List<GameObject> text;
    public Slider slider;
    void Start()
    {
        this.panel.SetActive(false);
        if (PlayerPrefs.GetInt("unique") == 0)
        {
            PlayerPrefs.SetFloat("sped", 1);
            PlayerPrefs.SetInt("unique", 1);
        }
        slider.maxValue=PlayerPrefs.GetFloat("sped");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void active(bool act)
    {
        text[0].GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("bestscore").ToString();
        text[1].GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("bestlevel").ToString();
        text[2].GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("ranger").ToString();
        text[3].GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("jump").ToString();
        text[4].GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("fire").ToString();
        text[5].GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("present").ToString();
        panel.SetActive(act);
    }
    public void gamespeed(float speed)
    {
        text[6].GetComponent<TextMeshProUGUI>().text = speed.ToString("F0");
        PlayerPrefs.SetFloat("gs", speed);
    }
}
