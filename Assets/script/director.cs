using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class director : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject jumpb;
    public GameObject fireb;
    void Start()
    {
        
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void jpc()
    {
        jumpb.GetComponent<imagecolor>().imagec();
        
    }
   public void fir()
    {
        fireb.GetComponent<imagecolor>().imagec();
    }
}
