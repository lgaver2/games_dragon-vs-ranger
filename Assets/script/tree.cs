using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bak;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fire")
        {
            GameObject b = Instantiate(bak) as GameObject;
            b.transform.position = new Vector2(transform.position.x, transform.position.y);
            Destroy(b, 0.3f);
            Destroy(gameObject);

        }
    }
}
