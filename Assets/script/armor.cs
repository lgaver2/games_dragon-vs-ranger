using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armor : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject prenum;
    public GameObject las;
    public GameObject ufo;
    int type;
    void Start()
    {
        prenum = GameObject.Find("presentnum");
        type = PlayerPrefs.GetInt("armor_type");
        default_mod(type);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void default_mod(int tp)
    {
        switch (tp)
        {
            case 0:
                break;
            case 1:
                this.GetComponent<dragon_controller>().status(1, 0, 0, 0,0);
                break;
            case 2:
                this.GetComponent<dragon_controller>().status(0, 2, 1, 0, 0);
                break;
            case 3:
                this.GetComponent<dragon_controller>().status(0, 1, 0, 1, 2);
                break;
            case 4:
                this.GetComponent<dragon_controller>().status(1, 0, 1, 1, 2);
                break;
            case 5:

                break;
            case 6:
                las.SetActive(true);
                break;
            case 7:
                ufo.SetActive(true);
                break;
            case 8:
                las.SetActive(true);
                ufo.SetActive(true);
                this.GetComponent<dragon_controller>().status(2, 0, 2, 2, 3);
                break;

        }
    }
}
