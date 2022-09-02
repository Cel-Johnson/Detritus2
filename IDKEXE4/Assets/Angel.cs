using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angel : MonoBehaviour
{
    ParticleCollide hit;
    public AudioSource audiosource;
    public GameObject target;
    public Transform bibliclyAccurateAimer;
    public Transform bibliclyAccurateAimerUp;
    public float moveSpeed = 10;
    public float rotationalDamp = 0.5f;
    public float castDist = 20;
    public float castOff = 2.5f;
    public bool uncomfy;
    public float detectRange;
    public float attackDist;
    public int health;
    public static int rage;
    public float ran;
    public AudioClip dieSound;
    [SerializeField] [Range(0, 1)] public float dieVolume = 0.75f;
    public int num;
    public AudioClip yellSound;
    public AudioClip beamSound;
    public AudioClip a;
    public AudioClip hum;
    public AudioClip b;
    public AudioClip c;
    public AudioClip Bwah;
    public AudioClip pwah;
    [SerializeField] [Range(0, 1)] public float yellVolume = 0.75f;
    [SerializeField][Range(0, 1)] public float bbwah = 0.75f;
    public Rigidbody rb;
    public ParticleSystem ps;
    public ParticleSystem thruster;
    public ParticleSystem suck;
    public float tim;
    public float angels;
    public  bool mad;
    public static int angry;
    public float temper;
    public float charge;
    public bool llock;
    public ParticleSystemForceField grav;
    public int AIdentity;
    public bool blah;
    public float hh;
    public bool hhclick;
    public float hlimit;
    public ParticleSystem glow;
    public float humc;

    public GameObject deathVFX;

    public static int AINumber;
    public int rng;
    public int durationOfExplosion;
    // Start is called before the first frame update
    void Start()
    {
        AINumber += 1;
        AIdentity = AINumber;
        if (angry != 6660)
        {
            angry += 1;
            mad = true;
        }
        else
        {
            mad = false;
        }
        target = FindObjectOfType<CharaccterThem>().gameObject;
        num = Random.Range(3, 8);
        health = 20 + (5 * rage);
        rb = GetComponent<Rigidbody>();
        rng = Random.Range(1, 5);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.right * detectRange, Color.yellow);
        Debug.DrawRay(transform.position, -transform.right * detectRange, Color.yellow);
        Debug.DrawRay(transform.position, transform.forward * detectRange, Color.yellow);
        Debug.DrawRay(transform.position, transform.up * detectRange, Color.yellow);
        Debug.DrawRay(transform.position, -transform.up * detectRange, Color.yellow);
        humc += Time.deltaTime;

        if (humc >= 1)
        {
            if (charge > 0.2)
            {
                audiosource.PlayOneShot(hum, 1);
                humc = 0;
            }
            else
            {
                audiosource.PlayOneShot(hum, 0.1f);
                humc = 0;
            }

        }

            float distt = Vector3.Distance(transform.position, target.transform.position);
            Mad();
            PathFinding();
            Turn();
            Move();
            Die();
            ran += Time.deltaTime;
            Noise();

            AttackLogic(distt);
        
    }
    private void AttackLogic(float distt)
    {if (hhclick == true)
        {
            hh -= Time.deltaTime;
            charge = 0;
            tim = 1.49f;
            thruster = ps;
           var emission = thruster.emission;
            emission.rateOverTime = 0;
            var glowrate = glow.emission;
            glowrate.rateOverTime = 0;
            var sucklim = suck.emission;
           sucklim.rateOverTime = 0;
            llock = false;
            if ( hh <=0)
            {
                hhclick = false;
            }
            var suckrate = suck.emission;
            suckrate.rateOverTime = 0;
            grav.gravity = 1;
        }
        if (distt >= attackDist /rng)
        {
            rb.drag = 3 -(0.5f*rng);
            thruster = ps;
            var emission = thruster.emission;
            temper = 0;
            if (llock == true && charge >= 0)
            {
                charge -= Time.deltaTime;
            }
            else
            {
                llock = false;
                tim = 1.49f;
            }
            if (hh >= hlimit)
            {
                hhclick = true;
            }
            if (llock == true && hhclick == false)
            {
                hh += Time.deltaTime;
                thruster = ps;
                var glowrate = glow.emission.rateOverTime;
                glowrate = 3;
                emission.rateOverTime = 200;
                tim += Time.deltaTime;
                if (tim >= 1.5f)
                {
                    audiosource.PlayOneShot(pwah, bbwah);

                    tim = 0;
                }
            }
            else
            {
                var suckrate = suck.emission;
                suckrate.rateOverTime = 0;
                emission.rateOverTime = 0;
                var glowrate = glow.emission;
                glowrate.rateOverTime = 0;
                grav.gravity = 1;

            }
        }
        else
        {
            var glowrate = glow.emission;
            glowrate.rateOverTime = 2;
            if (hh >= hlimit)
            {
                hhclick = true;
            }
            if (llock == true && hhclick == false)
            {
                hh += Time.deltaTime;
                thruster = ps;
                var emission = thruster.emission;
                emission.rateOverTime = 200;
              
                glowrate.rateOverTime = 5;
                tim += Time.deltaTime;
                if (tim >= 1.5f)
                {
                    audiosource.PlayOneShot(pwah, bbwah);

                    tim = 0;
                }
            }

            if (mad == true)
            {
                temper += Time.deltaTime * rng;
                if (temper >= 2)
                {

                    if (llock == false && charge <= 2)
                    {
                        if (blah == false && charge >= 0.9f)
                        {
                            audiosource.PlayOneShot(Bwah, bbwah);
                            blah = true;
                        }

                        grav.gravity = 1;
                        charge += Time.deltaTime * rng;
                        var suckrate = suck.emission;
                        suckrate.rateOverTime = 30;
                    }
                    if (charge >= 2)
                    {
                        var suckrate = suck.emission;
                        suckrate.rateOverTime = 30;
                        llock = true;
                        blah = false;
                        grav.gravity = -1;
                    }
                }

            }
            else
            {
                tim = 1.49f;
                thruster = ps;
                var emission = thruster.emission;
                emission.rateOverTime = 0;
            }

            rb.drag = 10/rng;
        }
    }

    private void Noise()
    {
        if (ran >= num)
        {
            int apple = Random.Range(1, 5);

            if (apple == 1)
            {
                audiosource.PlayOneShot(yellSound, yellVolume);
            }
            if (apple == 2)
            {
                audiosource.PlayOneShot(a, yellVolume);
            }
            if (apple == 3)
            {
                audiosource.PlayOneShot(b, yellVolume);
            }
            if (apple == 4)
            {
                audiosource.PlayOneShot(c, yellVolume);
            }
            num = Random.Range(3, 8);
            ran = 0;
        }
    }

    private void Mad()
    {
        
        if (mad == true)
        {
            target = FindObjectOfType<CharaccterThem>().gameObject;
        }
        else
        {
            target = FindObjectOfType<Heaven>().gameObject;
        }
        angels = FindObjectsOfType<Angel>().Length;
       
    }

    private  void Die()
    {
        if (health < 1)
        {
            angry -= 1;
            rage += 1;
           
            GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(explosion, durationOfExplosion);
            AudioSource.PlayClipAtPoint(dieSound, Camera.main.transform.position, dieVolume);
            Destroy(gameObject);
        }
    }
    public void Damage()
    {
        health -= 1;
    }

    void OnParticleCollision(GameObject other)
    {
      //  Debug.Log("foo");
    }
      
    void Turn()
    {
        Vector3 pos = target.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
    }
    void Move()
    {
        if(uncomfy == false)
        {
            GetComponent<Rigidbody>().AddForce(bibliclyAccurateAimer.transform.position - transform.position);
        }
        if (uncomfy == true)
        {
            GetComponent<Rigidbody>().AddForce(bibliclyAccurateAimerUp.transform.position - transform.position);
        }
    }
    void PathFinding()
    {
        RaycastHit hitr;
        RaycastHit hitl;
        RaycastHit hitu;
        RaycastHit hitd;
        RaycastHit hitf;
        Ray right = new Ray(transform.position, transform.right);
        Ray left = new Ray(transform.position, -transform.right);
        Ray up = new Ray(transform.position, transform.up);
        Ray down = new Ray(transform.position, -transform.up);
        Ray forward = new Ray(transform.position, transform.forward);

        // Debug.DrawRay()




        if (Physics.Raycast(right, out hitr, detectRange) || Physics.Raycast(forward, out hitf, detectRange) || Physics.Raycast(left, out hitl, detectRange) || Physics.Raycast(up, out hitu, detectRange) || Physics.Raycast(down, out hitd, detectRange))
        {
           

            uncomfy = true;

            if (Physics.Raycast(forward, out hitf, detectRange))
            {
                if (hitf.collider != null)
                {
                    Debug.Log(hitf.collider.gameObject.name);

                }
            }
          
        }
        else
        {
            uncomfy = false;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name + "apple");
        if (other.gameObject.GetComponentInChildren<Angel>() != null)
        {
            Vector3 oa = other.transform.position;
            GetComponent<Rigidbody>().AddForce(oa + transform.position);
            Debug.Log("No");
        }
      
    }
}
