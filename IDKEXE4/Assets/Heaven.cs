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
       
        asn = 1;
    }

    // Update is called once per frame
    void Update()
    {
       angels = FindObjectsOfType<Angel>().Length;

       
        if (angels < asn)
        {
            countdown -= Time.deltaTime;
            if (countdown <=0)
            {
                Instantiate(Angle, transform.position, transform.rotation);
                countdown = 1;
            }
          
        }
        asn = Angel.rage;
        

    }
}
