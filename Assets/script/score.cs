using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class score : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject scoretext;
    GameObject sd;
    int scores;
    float tim;
    bool dest;
    bool socr = true;
    public bool DontDstroyEnabled = true;
    void Start()
    {
        DontDestroyOnLoad(this);
        scoretext = GameObject.Find("Score");
        sd = GameObject.Find("scoredirector");
        scores = sd.GetComponent<score>().sc();
        scoretext.GetComponent<TextMeshProUGUI>().text = "SCORE:" + scores.ToString("F0");
        dest = sd.GetComponent<score>().des();
        if(dest == false)
        {
            dest = true;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(tim >= 1 && socr == true)
        {
            scoretext = GameObject.Find("Score");
            scores += 1;
            scoretext.GetComponent<TextMeshProUGUI>().text = "SCORE:" + scores.ToString("F0");
            tim = 0;
        }
        tim += Time.deltaTime;
    }
   
    public void scplus(int scor)
    {
        scores += scor;
        scoretext.GetComponent<TextMeshProUGUI>().text = "SCORE:" + scores.ToString("F0");
    }
    public void zero()
    {
        scores = 0;
        scoretext.GetComponent<TextMeshProUGUI>().text = "SCORE:" + scores.ToString("F0");
    }
    public void zeor()
    {
        scores = 0;
    }
    public int sc()
    {
        return scores;
    }
    public bool des()
    {
        return dest;
    }
    public void stop()
    {
            socr = false;
    }
    public void start()
    {
        socr = true;
    }

}
