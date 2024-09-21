using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid2D;
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        rigid2D.AddForce(transform.up * 300);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
