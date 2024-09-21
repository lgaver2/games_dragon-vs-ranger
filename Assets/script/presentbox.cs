using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class presentbox : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource aud;
    GameObject present;
    GameObject dragon;
    public List<GameObject> pre;
    public List<AudioClip> se;
    void Start()
    {
        present = GameObject.Find("presentdirector");
        dragon = GameObject.Find("fantasy_dragon");
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fire")
        {
            int j = PlayerPrefs.GetInt("present");
            PlayerPrefs.SetInt("present", j + 1);
            float rand = Random.Range(1, 100);
            if(rand >= 61)
            {
                GameObject p = Instantiate(pre[0]) as GameObject;
                p.transform.position = transform.position;
                dragon.GetComponent<dragon_controller>().hpplus(10);
                Destroy(p, 0.3f);
                aud.PlayOneShot(se[0]);

            }
            else if(rand >= 41 && rand <61)
            {
                GameObject p = Instantiate(pre[2]) as GameObject;
                p.transform.position = transform.position;
                present.GetComponent<present>().wingplus();
                Destroy(p, 0.3f);
                aud.PlayOneShot(se[1]);

            }
            else if (rand >= 21 && rand < 41)
            {
                GameObject p = Instantiate(pre[4]) as GameObject;
                p.transform.position = transform.position;
                present.GetComponent<present>().greenplus();
                Destroy(p, 0.3f);
                aud.PlayOneShot(se[1]);

            }
            else if (rand > 1 && rand < 21)
            {
                GameObject p = Instantiate(pre[3]) as GameObject;
                p.transform.position = transform.position;
                present.GetComponent<present>().blueplus();
                Destroy(p, 0.3f);
                aud.PlayOneShot(se[1]);

            }
            else
            {
                GameObject p = Instantiate(pre[1]) as GameObject;
                p.transform.position = transform.position;
                dragon.GetComponent<dragon_controller>().hpplus(1000);
                Destroy(p, 0.3f);
                aud.PlayOneShot(se[2]);

            }
            Destroy(gameObject,0.1f);
        }
    }
}

