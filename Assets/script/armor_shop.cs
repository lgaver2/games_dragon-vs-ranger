using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class armor_shop : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI price_txt;
    public GameObject panel;
    public GameObject dr;
    public TextMeshProUGUI info_text;
    public List<GameObject> Buttons;
    public List<AudioClip> se;
    AudioSource aud;
    int totpoint;
    int[] buyed = new int[9];
    void Start()
    {
        aud = GetComponent<AudioSource>();
        panel.SetActive(false);
        totpoint = PlayerPrefs.GetInt("totalscore");
        price_txt.text = totpoint.ToString()+"P";
        PlayerPrefs.SetInt("buy_armor" + 0, 1);
        for(int i = 0; i < buyed.Length; i++)
        {
            buyed[i] = PlayerPrefs.GetInt("buy_armor" + i);
            if (buyed[i] != 0) Buttons[i].SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pen(bool opn)
    {
        panel.SetActive(opn);
        totpoint = PlayerPrefs.GetInt("totalscore");
        price_txt.text = totpoint.ToString() + "P";
        aud.PlayOneShot(se[0]);
    }
    public void purchase(int price)
    {
        if (price <= totpoint)
        {
            totpoint -= price;
            PlayerPrefs.SetInt("totalscore", totpoint);
            price_txt.text = totpoint.ToString() + "P";
            types(price);
            aud.PlayOneShot(se[1]);
        }
        else aud.PlayOneShot(se[3]);

    }
    public void artpye(int t)
    {
        if (buyed[t] != 0)
        {
            PlayerPrefs.SetInt("armor_type", t);
            dr.GetComponent<start_dragon>().changeskin();
            aud.PlayOneShot(se[2]);
        }else aud.PlayOneShot(se[3]);
    }
    int at;
    void types(int p)
    {
        switch (p)
        {
            case 500:
                at = 1;
                break;
            case 1000:
                at = 2;
                break;
            case 1500:
                at = 3;
                break;
            case 2000:
                at = special();
                break;
            case 5000:
                at = 5;
                break;
            case 10000:
                at = 6;
                break;
            case 20000:
                at = 7;
                break;
            case 1000000:
                at = sp2();
                break;
            default:
                break;
        }
        buyed[at] = 1;
        PlayerPrefs.SetInt("buy_armor" + at, buyed[at]);
        Buttons[at].SetActive(false);
    }
    public void info(int number)
    {
        switch (number)
        {
            case 0:
                info_text.text = "Jumptime+1";
                break;
            case 1:
                info_text.text = "GreenFire";
                break;
            case 2:
                info_text.text = "BlueFire";
                break;
            case 3:
                info_text.text = "JumpTime+1,Green-BlueFire";
                break;
            case 4:
                info_text.text = "Begun with 100HP";
                break;
            case 5:
                info_text.text = "Auto laser";
                break;
            case 6:
                info_text.text = "Don't fall";
                break;
            case 7:
                info_text.text = "All armor power+buff";
                break;
        }
    }
    int num;
    int special()
    {

        if (buyed[1] == 1 && buyed[2] == 1 && buyed[3] == 1) num = 4;
        return num;
        
    }
    int sp2()
    {
        if (buyed[1] == 1 && buyed[2] == 1 && buyed[3] == 1 && buyed[4] == 1 && buyed[5] == 1 && buyed[6] == 1 && buyed[7] == 1) num = 8;
        return num;
    }
}
