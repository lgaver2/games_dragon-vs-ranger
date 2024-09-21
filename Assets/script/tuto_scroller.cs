using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuto_scroller : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> img;
    public GameObject panel;
    int img_pos;
    void Start()
    {
        panel.SetActive(false);
        img_pos = 0;
        for (int i = 1; i <5; i++)
        {
            img[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void scroller(int num)
    {
        if ((img_pos + num)>=0&& (img_pos + num) <= 4)
        {
            img[img_pos].SetActive(false);
            img_pos += num;
            img[img_pos].SetActive(true);
        }
        
    }
    public void open(bool act)
    {
        panel.SetActive(act);
    }
}
