using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_arm : MonoBehaviour
{
    public GameObject fires;
    AudioSource aud;
    GameObject spd;
    public AudioClip se;
    int key = 1;
    float firetime;
    float speed;
    float deftime = 1;
    // Update is called once per frame
    private void Start()
    {
        aud = GetComponent<AudioSource>();
        Invoke("after", 1f);
    }
    void after()
    {
        spd = GameObject.Find("spawndirecot");
        speed = spd.GetComponent<spawnd>().speed();
    }
    void Update()
    {
        if (firetime >= 0.5f+deftime )
        {
            GameObject f = Instantiate(fires) as GameObject;
            f.transform.position = new Vector2(transform.position.x, transform.position.y);
            f.GetComponent<fire>().changehp(1, 2*speed, 0.7f, key);
            firetime = 0;
            deftime = 0;
            Destroy(f, 2f);
            aud.PlayOneShot(se);
        }
        firetime += Time.deltaTime;
    }
    public void changekey(int k)
    {
        key = k;
    }
}
