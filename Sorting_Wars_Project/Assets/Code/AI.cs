using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class AI : MonoBehaviour
{
    //========================================================
    //Sterowanie postaci¹, animacje i wyznaczanie celu 
    //podró¿y postaci
    //========================================================
    //Reference to parent
    Parent parent;

    public float lookRadius = 10f;
    internal bool onpoint = false;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;
    public Animator animator;
    bool atk = false;
    int x = 0;

    void Start()
    {
        parent = FindObjectOfType<Parent>();
        agent.updateRotation = false;
    }

    void Update()
    {
        float distance = Vector3.Distance(parent.target.position, transform.position);
        
        if (distance <= lookRadius & distance >= agent.stoppingDistance) { 
        
            agent.SetDestination(parent.target.position);
            atk = true;
            
 
        }
        if (distance <= agent.stoppingDistance & atk)
        {
            StartCoroutine(Attack());
            atk = false;
        }

        if (agent.remainingDistance > agent.stoppingDistance)
            character.Move(agent.desiredVelocity, false, false);
        else
            character.Move(Vector3.zero, false, false);
            
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

    }

    private IEnumerator Attack() {
        onpoint = true;
        x++;
        if(x==1)
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("Attack", false);
        onpoint = false;

        if (x == 3)
            x = 0;
        
    }
}
