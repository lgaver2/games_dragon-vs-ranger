using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easteregg : MonoBehaviour
{
    // Start is called before the first frame update
    int num = 0;
    public GameObject pnum;
    AudioSource aud;
    public AudioClip se;
    void Start()
    {
        aud=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void tap()
    {
        num++;
        if (num == 7)
        {
            aud.PlayOneShot(se);
            /*pnum.GetComponent<presentnum>().add(2, 2, 2);*/
            PlayerPrefs.SetInt("totalscore", PlayerPrefs.GetInt("totalscore")+50);
        }
    }
}
