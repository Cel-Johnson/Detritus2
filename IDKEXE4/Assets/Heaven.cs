using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heaven : MonoBehaviour
{
    public int angels;
    public GameObject Angle;
    public float countdown;
    public int asn;
 
    // Start is called before the first frame update
    void Start()
    {
       
        Angel.rage = 1;
        asn = 1;
    }

    // Update is called once per frame
    void Update()
    {
       angels = FindObjectsOfType<Angel>().Length;

        countdown -= Time.deltaTime;
        if (angels < asn)
        {
            if(countdown <=0)
            {
                Instantiate(Angle, transform.position, transform.rotation);
                countdown = 6;
            }
          
        }
        if (Angel.rage == 1 || Angel.rage == 2 || Angel.rage == 3)
        {
            asn = 1;
        }
        if (Angel.rage == 4|| Angel.rage == 5 || Angel.rage == 6)
        {
            asn = 2;
        }
        if (Angel.rage == 7|| Angel.rage == 8 || Angel.rage == 9)
        {
            asn = 3;
        }

    }
}
