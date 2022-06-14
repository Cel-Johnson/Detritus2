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
    public AudioClip b;
    public AudioClip c;
    [SerializeField] [Range(0, 1)] public float yellVolume = 0.75f;
    public Rigidbody rb;
    public ParticleSystem ps;
    public ParticleSystem thruster;
    public float tim;
    public float angels;
    public  bool mad;
    public static int angry;

    public int AIdentity;

    public GameObject deathVFX;

    public static int AINumber;

    public int durationOfExplosion;
    // Start is called before the first frame update
    void Start()
    {
        AINumber += 1;
        AIdentity = AINumber;
        if (angry != 100000)
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        float distt = Vector3.Distance(transform.position, target.transform.position);
        Mad();
        PathFinding();
        Turn();
        Move();
        Die();
        ran += Time.deltaTime;
        Noise();
        

        if (distt >= attackDist)
        {
            rb.drag = 2;
            thruster = ps;
            var emission = thruster.emission;
            emission.rateOverTime = 0;
        }
        else
        {
            if (mad == true)
            {
                thruster = ps;
                var emission = thruster.emission;
                emission.rateOverTime = 60;
                tim += Time.deltaTime;
                if (tim >= 2)
                {
                    audiosource.PlayOneShot(beamSound, yellVolume);
                    tim = 0;
                }
            }
            else
            {
                tim = 0;
                thruster = ps;
                var emission = thruster.emission;
                emission.rateOverTime = 0;
            }
            rb.drag = 10;
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
                    //Debug.Log(hitf.collider.gameObject.name);

                }
            }
          
        }
        else
        {
            uncomfy = false;
        }
    }
}
