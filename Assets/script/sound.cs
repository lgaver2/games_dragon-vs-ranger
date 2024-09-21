using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    // Start is called before the first frame update
    
    AudioSource aud;
    GameObject bgms;
    public List<AudioClip> bgm;
    int bgmnum;
  
    void Start()
    {
        Time.timeScale = 1f;
        bgms = GameObject.Find("BGM_2");
        Destroy(bgms);
        aud = GetComponent<AudioSource>();
        aud.PlayOneShot(bgm[0]);
    }
   
   public void change_bgm(int num)
    {
        bgmnum = num;
        aud.PlayOneShot(bgm[bgmnum]);
        
    }
    public void stastop(bool stop)
    {
        if(stop == true)
        {
            aud.Stop();
        }
        else
        {
            
                aud.Play();
            
            
        }
    }
}
