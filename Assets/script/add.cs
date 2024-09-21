using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ground;
    bool create = true;
    void Start()
    {
        Destroy(gameObject, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="ranger"&&create == true)
        {
            create = false;
            GameObject g = Instantiate(ground) as GameObject;
            g.transform.position = new Vector2(transform.position.x + 20, transform.position.y-9.56f);
           
        }
    }
}
