using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class size : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void sise(float newsize)
    {
        transform.localScale = new Vector3(newsize, 1,1);
        Debug.Log(newsize);
    }
}
