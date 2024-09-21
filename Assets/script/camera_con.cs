using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_con : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dragon;
    int key = 1;
    void Start()
    {
        float x = dragon.transform.position.x;
        float y = dragon.transform.position.y;
        float xc = transform.position.x;
        float yc = transform.position.y;
        if (x > -5)
        {
            transform.position = new Vector3(x + 5, 1, -10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float x = dragon.transform.position.x;
        float y = dragon.transform.position.y;
        float xc = transform.position.x;
        float yc = transform.position.y;
        if (x>-5)
        {
            transform.position = new Vector3(x+5*key, 1,-10);
        }
    }
    public void change()
    {
        key *= -1;
    }
}
