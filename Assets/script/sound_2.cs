using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_2 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool DontDstroyEnabled = true;
    AudioSource aud;
    GameObject bgms;
   
    bool dest = false;
    void Start()
    {
        DontDestroyOnLoad(this);
        bgms = GameObject.Find("BGM_2");
        dest = bgms.GetComponent<sound_2>().RD();
        if (dest == true)
        {
            Destroy(gameObject);
        }
        else
        {
            dest = true;
        }
        this.aud = GetComponent<AudioSource>();
        Time.timeScale = PlayerPrefs.GetFloat("gs");
    }
    public bool RD()
    {
        return dest;
    }
  
    public void stastop(bool stop)
    {
        if (stop == true)
        {
            aud.Stop();
        }
        else
        {
            aud.Play();
        }
    }
}
