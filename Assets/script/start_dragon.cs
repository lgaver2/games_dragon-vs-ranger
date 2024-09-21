using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_dragon : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Sprite> dr_img;
    Rigidbody2D rigid2D;
    float walkforce = 30f;
    float maxforce = 4f;
    int key = 1;
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        changeskin();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float speedx = Mathf.Abs(rigid2D.velocity.x);
        if (speedx < maxforce)
        {
            rigid2D.AddForce(transform.right * walkforce * key);
        }
        if(rigid2D.velocity.y == 0)
        {
            rigid2D.AddForce(transform.up * 400);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "corner")
        {
            key *= -1;

            rigid2D.velocity = new Vector2(0, transform.position.y);
           
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
    }
    public void changeskin()
    {
        this.GetComponent<SpriteRenderer>().sprite = dr_img[PlayerPrefs.GetInt("armor_type")];
    }
}
