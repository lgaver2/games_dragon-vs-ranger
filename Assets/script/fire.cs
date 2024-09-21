using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource aud;
    Rigidbody2D rigid2D;
    [SerializeField] int firehp = 2;
    [SerializeField] AudioClip sound;
    float speed;
    float size;
    int key =1;
    void Start()
    {

        this.rigid2D = GetComponent<Rigidbody2D>();
        aud = GetComponent<AudioSource>();
        rigid2D.AddForce(transform.up * -800 * speed * key);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changehp(int news,float sp, float sz,int k)
    {
        firehp = news;
        speed = sp;
        size = sz;
        key = k;
        transform.localScale = new Vector2(size * key, size  *key);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ranger")
        {
            try
            {
                collision.gameObject.GetComponent<ranger>().decrease(1);
                firehp -= 1;
                if (firehp <= 0)
                {
                    Destroy(gameObject);
                }
            }
            catch
            {
                Debug.Log("error");
            }

        }
       /* if (collision.gameObject.tag != "Untagged")
        {
            aud.PlayOneShot(sound);
        }*/
       
    }
}
