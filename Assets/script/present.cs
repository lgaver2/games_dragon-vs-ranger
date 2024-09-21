using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class present : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource aud;
    GameObject spd;
    GameObject wing;
    GameObject blue;
    GameObject green;
    GameObject dragon;
    public List<AudioClip> se;
    int wingnum =1;
    int bluenum = 1;
    int greennum = 1;
    int dest = 0;
    void Start()
    {
        spd = GameObject.Find("presentnum");
        dragon = GameObject.Find("fantasy_dragon");
        wingnum = spd.GetComponent<presentnum>().w();
        bluenum = spd.GetComponent<presentnum>().b();
        greennum = spd.GetComponent<presentnum>().g();
        aud = GetComponent<AudioSource>();
        
       
        wing = GameObject.Find("wing");
        blue = GameObject.Find("blue");
        green = GameObject.Find("green");
        wing.GetComponent<TextMeshProUGUI>().text = "x" + wingnum.ToString("F0");
        blue.GetComponent<TextMeshProUGUI>().text = "x" + bluenum.ToString("F0");
        green.GetComponent<TextMeshProUGUI>().text = "x" + greennum.ToString("F0");
    }
    void presents()
    {
       
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
   
   
    public void wings()
    {
        if(wingnum > 0)
        {
            
           
            dragon.GetComponent<dragon_controller>().status(3,0,0,0,0);
            wingnum -= 1;
            wing.GetComponent<TextMeshProUGUI>().text = "x" + wingnum.ToString("F0");
            spd.GetComponent<presentnum>().number(wingnum, bluenum, greennum);
            aud.PlayOneShot(se[0]);
        }
    }
    public void blues()
    {
        if (bluenum > 0)
        {
            dragon.GetComponent<dragon_controller>().status(0, 1, 0,1,2);
            bluenum -= 1;
            blue.GetComponent<TextMeshProUGUI>().text = "x" + bluenum.ToString("F0");
            spd.GetComponent<presentnum>().number(wingnum, bluenum, greennum);
            aud.PlayOneShot(se[0]);
        }
    }
    public void greens()
    {
        if (greennum > 0)
        {
            dragon.GetComponent<dragon_controller>().status(0, 2, 1,0,0);
            greennum -= 1;
            green.GetComponent<TextMeshProUGUI>().text = "x" + greennum.ToString("F0");
            spd.GetComponent<presentnum>().number(wingnum, bluenum, greennum);
            aud.PlayOneShot(se[0]);
        }
    }
    public void wingplus()
    {
            wingnum += 3;
            wing.GetComponent<TextMeshProUGUI>().text = "x" + wingnum.ToString("F0");
            spd.GetComponent<presentnum>().number(wingnum, bluenum, greennum);
            
        
    }
    public void blueplus()
    {
       
            
            bluenum += 3;
            blue.GetComponent<TextMeshProUGUI>().text = "x" + bluenum.ToString("F0");
            spd.GetComponent<presentnum>().number(wingnum, bluenum, greennum);
            
        
    }
    public void greenplus()
    {
        
           
            greennum += 3;
            green.GetComponent<TextMeshProUGUI>().text = "x" + greennum.ToString("F0");
            spd.GetComponent<presentnum>().number(wingnum, bluenum, greennum);
           
       
    }
}
