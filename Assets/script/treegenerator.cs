using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treegenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tree;
    [SerializeField] float time = 4f;
    void Start()
    {
        Invoke("st", time);
    }
    void st()
    {
        GameObject t = Instantiate(tree) as GameObject;
        t.transform.position = new Vector2(transform.position.x, transform.position.y);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
