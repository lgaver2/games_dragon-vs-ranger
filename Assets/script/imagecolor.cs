using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imagecolor : MonoBehaviour
{
    // Start is called before the first frame update
    Image image;
    void Start()
    {
        image = GetComponent<Image>();

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void imagec()
    {
        Color c = image.color;
        c.a = 0.2f;
        image.color = c;
        Invoke("retur", 0.2f);
    }
    void retur()
    {

        Color c = image.color;
        c.a = 0f;
        image.color = c;
    }
}
