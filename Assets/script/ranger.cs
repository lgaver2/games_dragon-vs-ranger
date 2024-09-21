using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ranger : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource aud;
    GameObject dragon;
    GameObject spwnd;
    GameObject score;
    public GameObject las;
    public GameObject bak;
    Rigidbody2D rigid2D;
    [SerializeField] float jumpforce = 200f;
    [SerializeField] float walkforce = 30f;
    [SerializeField] float distances;
    [SerializeField] int hp;
    [SerializeField] float maxforce;
    [SerializeField] float lasertime;
    [SerializeField] bool move;
    [SerializeField] bool jump;
    [SerializeField] bool laser;
    [SerializeField] bool silver;
    [SerializeField] bool golden;
    [SerializeField] bool female;
    [SerializeField] int sc;
    [SerializeField] List<AudioClip> sound;
    float lt;
    float jt;
    float replace;
    int key = 1;
    int num;
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.aud = GetComponent<AudioSource>();
        dragon = GameObject.Find("fantasy_dragon");
        spwnd = GameObject.Find("spawndirecot");
        score = GameObject.Find("scoredirector");
        num = spwnd.GetComponent<spawnd>().nume();
        if(silver == true|golden == true)
        {
            key = -1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = dragon.transform.position.x;
        float y = dragon.transform.position.y;
        float distance = transform.position.x - x;
        if (distance < distances * (num+1))
        {
            moves();
            jumps();
            lasers();
            goldens();
        }
        if(distance < -10 | transform.position.y < -15)
        {
            if(silver == false)
            {
                Destroy(gameObject);

            }
        }
       
    }
    void moves()
    {
        float speedx = Mathf.Abs(rigid2D.velocity.x);
        if (speedx < maxforce* (num + 1) && move == true)
        {
            rigid2D.AddForce(transform.right * -walkforce *key* (num + 1));
            Debug.Log(key);
        }
    }
    void jumps()
    {
        if (rigid2D.velocity.y == 0 && jump == true )
        {
            /*if(silver == true |golden == true && jt >=10f )
            {
                rigid2D.AddForce(transform.up * jumpforce);
                jt = 0;
            }
            else
            {*/
                rigid2D.AddForce(transform.up * jumpforce);
            //}
            jt += Time.deltaTime;
        }
    }
    void lasers()
    {
        if(golden == true && lt >= lasertime)
        {
            GameObject l = Instantiate(las) as GameObject;
            float pos = Random.Range(0, 2);
            float pso = Random.Range(-4, 3);
            l.transform.position = new Vector2(transform.position.x+pos, transform.position.y+ pso);
            Destroy(l, 2f * (num + 1));
            lt = 0;
            aud.PlayOneShot(sound[2]);
        }
        else if (laser == true && lt >= lasertime)
        {
            GameObject l = Instantiate(las) as GameObject;
            l.transform.position = new Vector2(transform.position.x, transform.position.y);
            Destroy(l, 2f * (num + 1));
            lt = 0;
            aud.PlayOneShot(sound[2]);
        }
       
       
        lt += Time.deltaTime;
        
    }
    void goldens()
    {
        if(golden == true)
        {
            transform.position = new Vector2(dragon.transform.position.x + 10, transform.position.y);

        }

    }
    public void decrease(int damage)
    {
        float x = dragon.transform.position.x;
        float y = dragon.transform.position.y;
        float distance = transform.position.x - x;
        if (distance < 15)
        {
            GameObject b = Instantiate(bak) as GameObject;
            b.transform.position = new Vector2(transform.position.x, transform.position.y);
            Destroy(b, 0.3f);
            hp -= damage;
            if(silver == true | golden == true)
            {
                aud.PlayOneShot(sound[3]);

            }
           
            if (hp <= 0)
            {
                int rang = PlayerPrefs.GetInt("ranger");
                rang++;
                PlayerPrefs.SetInt("ranger", rang);
                score.GetComponent<score>().scplus(sc);
                if(silver == true|golden==true)
                {
                    spwnd.GetComponent<spawnd>().level(1);
                }
                Destroy(gameObject);
                
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "corner" && silver == true)
        {
            key *= -1;
            rigid2D.AddForce(transform.up * 500);
            rigid2D.velocity = new Vector2(0, transform.position.y);
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
    }

}
