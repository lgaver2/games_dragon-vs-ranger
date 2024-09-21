using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwnp : MonoBehaviour
{
    // Start is called before the first frame update
    int lv;
    public List<GameObject> ranger;
    GameObject spwd;
    int[] rang = { 1, 1, 1, 1, 1, 1, 1 };
    int stlv = 1;
    int stlv_2 = 1;
    int data = 10;
    int number = 1;
    int loop;
    float num = 0.5f;
    [SerializeField]  bool st = true;
    private void Start()
    {
        Invoke("Starts", 0.4f);
    }
    void Starts()
    {
        Invoke("flasestart", 0.2f);
        spwd = GameObject.Find("spawndirecot");
        lv = spwd.GetComponent<spawnd>().lvl();
        stlv = lv;
        number = spwd.GetComponent<spawnd>().nume();
        
        if (lv <=6 && st == true)
        {
            GameObject r = Instantiate(ranger[stlv -1]) as GameObject;
            r.transform.position = new Vector2(transform.position.x, transform.position.y);
            
           
        }
        if(lv >= 7 && lv <=9)
        {
            stlv = lv - 6;
            GameObject r = Instantiate(ranger[stlv - 1]) as GameObject;
            r.transform.position = new Vector2(transform.position.x, transform.position.y);
        }
        if(lv == 10 && st == true)
        {
            GameObject r = Instantiate(ranger[6]) as GameObject;
            r.transform.position = new Vector2(transform.position.x, transform.position.y);
        }
        if (lv <= 6+data*number && lv>=data*number+1 && st == true)
        {
            stlv = lv - data * number;
            stlv_2 = stlv + 1;
            for (int i = 0; i < number * 2; i++)
            {
                
                if(number >=2 && i > number)
                {
                    
                    GameObject r = Instantiate(ranger[stlv_2 - 1]) as GameObject;
                    r.transform.position = new Vector2(transform.position.x + num, transform.position.y);
                    num += 3f;
                    loop += 1;
                }
                else
                {
                    GameObject r = Instantiate(ranger[stlv - 1]) as GameObject;
                    r.transform.position = new Vector2(transform.position.x + num, transform.position.y);
                    num += 3f;
                }
                if (loop >= 2)
                {
                    stlv_2 += 1;
                    loop = 0;
                    if(stlv_2 > 6)
                    {
                        stlv_2 =1;
                    }
                }
            }
            


        }
        if (lv >= 7 + data * number && lv <= data * number + 9)
        {
            stlv = lv - data * number -7;
            stlv_2 = stlv + 1;
            for (int i = 0; i < number * 2; i++)
            {

                if (number >= 2 && i > number)
                {

                    GameObject r = Instantiate(ranger[stlv_2 - 1]) as GameObject;
                    r.transform.position = new Vector2(transform.position.x + num, transform.position.y);
                    num += 3f;
                    loop += 1;
                }
                else
                {
                    GameObject r = Instantiate(ranger[stlv - 1]) as GameObject;
                    r.transform.position = new Vector2(transform.position.x + num, transform.position.y);
                    num += 3f;
                }
                if (loop >= 2)
                {
                    stlv_2 += 1;
                    loop = 0;
                    if (stlv_2 > 6)
                    {
                        stlv_2 = 1;
                    }
                }
                


            }
        }
        if (lv == 10 + data * number && st == true)
        {
            for (int i = 0; i < number * 2-1; i++)
            {
                GameObject r = Instantiate(ranger[6]) as GameObject;
                r.transform.position = new Vector2(transform.position.x + num, transform.position.y);
                num += 1f;
            }
            
        }
    }
  
    // Update is called once per frame
    void Update()
    {
        
    }
   
}
