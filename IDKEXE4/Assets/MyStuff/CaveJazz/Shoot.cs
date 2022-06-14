using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public AudioSource ad;
    public Light light;
    public Animator anim;
    public float shotTime;
    public ParticleSystem ps;
    public ParticleSystem thruster;
    public float time;
    public int ran;
    public ParticleSystem muzzle;
    public AudioClip downSound;
    [SerializeField] [Range(0, 1)] public float downVolume = 0.75f;
    public AudioClip shootSound;
    [SerializeField] [Range(0, 1)] public float shootVolume = 0.75f;
    public AudioClip blamSound;
    [SerializeField] [Range(0, 1)] public float blamVolume = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (light.intensity< 10)
            {
                light.intensity += 0.01f;
            }
            anim.SetBool("Shoot", true);
            shotTime += Time.deltaTime;
            if (shotTime >= 0.0001f)
            {
                
               thruster = ps;
                var emission = thruster.emission;
                emission.rateOverTime = 10;
               
                var muzzleflash = muzzle.emission;
                muzzleflash.rateOverTime = 4;

                if(shotTime>time)
                {
                    ran = Random.Range(1, 4);
                   if(ran ==1)
                    {
                       ad.PlayOneShot(downSound, downVolume);
                    }
                    if (ran == 2)
                    {
                        ad.PlayOneShot(shootSound, shootVolume);
                    }
                    if (ran == 3)
                    {
                        ad.PlayOneShot(blamSound, blamVolume);
                    }


                    shotTime = 0;
                }
               
            }
        }
        else
        {
            if (light.intensity > 0.01f)
            {
                light.intensity -= 0.008f;
            }
            anim.SetBool("Shoot", false);
            thruster = ps;
            var emission = thruster.emission;
            emission.rateOverTime = 0;
            var muzzleflash = muzzle.emission;
            muzzleflash.rateOverTime = 0;
        }
    }
}
      


