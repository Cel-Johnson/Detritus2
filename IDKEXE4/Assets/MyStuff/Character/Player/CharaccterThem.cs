using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CharaccterThem : MonoBehaviour
{
    public Animator anim;
    public float rightGoal;
    public float runGoal;
    public float right;
    public float run;

    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }
    private void FixedUpdate()
    {
        ForwardBackward();
        RightLeft();

        run = anim.GetFloat("Run");
        right = anim.GetFloat("right");

        RunGoal();
        RightGoal();

    }

    private void RunGoal()
    {
        if (run > runGoal)
        {
            anim.SetFloat("Run", run += -0.1f);
        }
         if (run < runGoal)
        {
            anim.SetFloat("Run", run += 0.1f);
        }
         
    }

    private void RightGoal()
    {
        if (right > rightGoal)
        {
            anim.SetFloat("right", right += -0.1f);
        }
         if (right < rightGoal)
        {
            anim.SetFloat("right", right += 0.1f);
        }
    }

    private  void RightLeft()
    {
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.A))
        {
            rightGoal = 1;

        }
      else  if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.D))
        {
            rightGoal = -1;
        }
     else   if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            rightGoal = 0.5f;
        }
     else   if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rightGoal = -0.5f;
        }
        else
        {
            rightGoal = 0;
        }
    }

    private  void ForwardBackward()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.S))
        {
            runGoal = 1;

        }
       else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.W))
        {
            runGoal = -1;
        }
      else  if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            runGoal = 0.5f;
        }
       else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            runGoal = 0.5f;
        }
        else
        {
            runGoal = 0;
        }
    }
}
