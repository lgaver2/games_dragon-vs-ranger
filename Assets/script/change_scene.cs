using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class change_scene : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject score;
    GameObject bg;
    AudioSource aud;
    GameObject spd;
    [SerializeField] AudioClip sound;
    void Start()
    {
        score = GameObject.Find("scoredirector");
        bg = GameObject.Find("BGM");
        spd = GameObject.Find("spawndirecot");

        this.aud = GetComponent<AudioSource>();
        bg.GetComponent<sound>().stastop(false);
        bg.GetComponent<sound>().change_bgm(0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void change()
    {
        score.GetComponent<score>().zeor();
        bg.GetComponent<sound>().stastop(true);
        bg.GetComponent<sound>().change_bgm(1);
        PlayerPrefs.SetInt("restart", 3);
        Debug.Log("setter");
        PlayerPrefs.Save();
        if (PlayerPrefs.GetFloat("gs") <= 1)
        {
            PlayerPrefs.SetFloat("gs", 1);
        }
        if (PlayerPrefs.GetInt("armor_type") == 5 || PlayerPrefs.GetInt("armor_type") == 8) spd.GetComponent<spawnd>().controlhp(-80, 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("SampleScene");
    }
}
