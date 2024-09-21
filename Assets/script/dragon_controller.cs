using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class dragon_controller : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource aud;
    public GameObject dir;
    public List<GameObject> fires;
    public GameObject ground;
    public GameObject life;
    public GameObject cam;
    public GameObject cont;
    public List<AudioClip> sound;
    public List<Sprite> dr_img;
    public GameObject firearm;
    GameObject grounde;
    GameObject sky;
    GameObject spd;
    Rigidbody2D rigid2D;
   
    float jumpforce = 450f;
    float walkforce = 30f;
    float maxforce = 4f;
    float firetime=0.5f;
    float hp = 20;
    int jumptime = 3;
    int jumpboost = 0;
    int firenum;
    int firehp = 2;
    int key = 1;
    int lv, NUM;
    float firespeed = 1;
    float speed;
    float firesize = 0.5f;
    bool move = true;
    bool muteki = false;
    bool jumpe = true;
    float posx_1;
    float posx_2;
    float tim;
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.aud = GetComponent<AudioSource>();
        jumptime += jumpboost;
        Invoke("spds", 0.1f);
       
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void FixedUpdate()
    {
        float speedx = Mathf.Abs(rigid2D.velocity.x);
        if (speedx < maxforce * speed && move == true)
        {
            rigid2D.AddForce(transform.right * walkforce * speed * key);
        }
        firetime += Time.deltaTime;
        if (transform.position.y <= -10)
        {
            gameover();

        }
        dontcheat();

       


    }
    void dontcheat()
    {
        if(tim <= 1)
        {
            posx_1 = transform.position.x;
        }
        if (tim >= 2)
        {
            posx_2 = transform.position.x;
            tim = 0;
            if (posx_1 == posx_2)
            {
                gameover();
            }
        }
       
        tim += Time.deltaTime;
    }
    void spds()
    {
        dr_armor();
        spd = GameObject.Find("spawndirecot");
        speed = spd.GetComponent<spawnd>().speed();
        hp = spd.GetComponent<spawnd>().hps();
        life.GetComponent<TextMeshProUGUI>().text =  hp.ToString("F0");
        grounde = GameObject.Find("ground");
        sky = GameObject.Find("sky");
        lv = spd.GetComponent<spawnd>().lvl();
        NUM = spd.GetComponent<spawnd>().NUMS();

        try
        {
            grounde.GetComponent<size>().sise(speed);
            sky.GetComponent<size>().sise(speed);
        }
        catch
        {
            Debug.Log("Error Field50");
        }

    }
    public void jump()
    {
        if(jumptime > 0 && move == true && jumpe == true)
        {
            dir.GetComponent<director>().jpc();
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, 0);
            rigid2D.AddForce(transform.up * jumpforce);
            jumptime -= 1;
            aud.PlayOneShot(sound[0]);
            int j = PlayerPrefs.GetInt("jump");
            PlayerPrefs.SetInt("jump", j + 1);
        }
       
    }
    public void fire()
    {
        dir.GetComponent<director>().fir();
        if(firetime >= 0.5f/firespeed)
        {
            GameObject f = Instantiate(fires[firenum]) as GameObject;
            f.transform.position = new Vector2(transform.position.x + 1, transform.position.y-0.5f);
            f.GetComponent<fire>().changehp(firehp, speed * firespeed, firesize,key);
            firetime = 0;
            Destroy(f, 2f);
            aud.PlayOneShot(sound[1]);
            int j = PlayerPrefs.GetInt("fire");
            PlayerPrefs.SetInt("fire", j + 1);
        }
       
     }
    public void hpplus(int plus)
    {
        hp += plus;
        spd.GetComponent<spawnd>().controlhp(-plus, 1);
        life.GetComponent<TextMeshProUGUI>().text = hp.ToString("F0");
    }
    public void status(int jb,int firen,float fires,float firez,int fireh)
    {
        jumpboost += jb;
        firenum = firen;
        firespeed += fires;
        firesize += firez;
        firehp *= fireh;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            jumptime = 3 + jumpboost;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ranger")
        {
            if(muteki == false)
            {
                aud.PlayOneShot(sound[2]);
                hp -= 1;
                spd.GetComponent<spawnd>().controlhp(1, 1);
                life.GetComponent<TextMeshProUGUI>().text = hp.ToString("F0");
                if (hp <= 0)
                {
                    gameover();
                }
            }
           
        }
        if (collision.gameObject.tag == "Finish")
        {
            GameObject go = GameObject.Find("google");
            /*int i = PlayerPrefs.GetInt("ads");
            if (i >= 5)
            {*/
                go.GetComponent<GoogleAds>().ShowInterstitialAd();
                /*i = 0;
            }
            else
            {
                i++;
                spd = GameObject.Find("spawndirecot");
                spd.GetComponent<spawnd>().level(1);
            }
            PlayerPrefs.SetInt("ads", i);*/
            
            
        }
        if (collision.gameObject.tag == "corner")
        {
            key *= -1;
           
            rigid2D.velocity = new Vector2(0, transform.position.y);
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            cam.GetComponent<camera_con>().change();
            firearm.GetComponent<fire_arm>().changekey(key);
        }
        if (collision.gameObject.tag == "rest")
        {
            rigid2D.gravityScale = 3;
            jumpe = true;
        }
    }
    void gameover()
    {
       
        move = false;
        rigid2D.velocity = new Vector2(0, 0);
        ground.GetComponent<gameover>().go();
        //Invoke("end", 1f);
        cont.GetComponent<restart>().open();
        
    }
    public void restart()
    {
        jumptime *= jumpboost;
        move = true;
        ground.GetComponent<gameover>().start();
        spd.GetComponent<spawnd>().controlhp(-30, 0);
        hp = 30;
        life.GetComponent<TextMeshProUGUI>().text = hp.ToString("F0");
        transform.position = new Vector2(transform.position.x, 4);
        if(lv != 50 + NUM && lv != 100 + NUM)
        {
            
            jumpe = false;

            rigid2D.gravityScale = 0;
            rigid2D.velocity = new Vector2(0, 0);
        }

        muteki = true;
        Invoke("mut", 5f);
    }
    void mut()
    {
        muteki = false;
    }

    /*void end()
    {
        SceneManager.LoadScene("SampleScene");
    }*/
    void dr_armor()
    {
        int tp = PlayerPrefs.GetInt("armor_type");
        this.GetComponent<SpriteRenderer>().sprite = dr_img[tp];
        
    }
}
