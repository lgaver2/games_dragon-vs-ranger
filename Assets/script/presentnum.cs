using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class presentnum : MonoBehaviour
{
    // Start is called before the first frame update
    public bool DontDstroyEnabled = true;
    int wingnum = 1;
    int bluenum = 1;
    int greennum = 1;
    bool dest = false;
    GameObject spd;
    void Start()
    {
        DontDestroyOnLoad(this);
        spd = GameObject.Find("presentnum");
        dest = spd.GetComponent<presentnum>().RD();
        if (dest == true)
        {
            Destroy(gameObject);
        }
        else
        {
            dest = true;
        }
    }
    public int w()
    {
        return wingnum;
    }
    public int b()
    {
        return bluenum;
    }
    public int g()
    {
        return greennum;
    }
    public bool RD()
    {
        return dest;
    }
    public void number(int w,int b,int g)
    {
        wingnum = w;
        bluenum = b;
        greennum = g;
    }
    public void add(int w, int b ,int g)
    {
        wingnum += w;
        bluenum += b;
        greennum += g;
    }
   
}
