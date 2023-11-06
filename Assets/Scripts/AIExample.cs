using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.AI;

public class AIExample : MonoBehaviour
{
   public FirstPersonController fpsc;
    public float fov = 120f;
    public float viewDistance = 10f;
    private bool isAware = true;
    private NavMeshAgent agent;
    private Renderer renderer;
    public float health = 50f;
    public float wanderSpeed = 4f;
    private Animator animator;
    private Vector3 distanceDifference;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        renderer = GetComponent<Renderer>();
        animator = GetComponentInChildren<Animator>();
        distanceDifference = gameObject.transform.position - fpsc.transform.position;
    }

    public void Update()
    {
        if (isAware)
        {
            agent.SetDestination(fpsc.transform.position);
            agent.speed = wanderSpeed;
            
          //  renderer.material.color = Color.yellow;

        }
        else
        {
            searchForPlayer();
           // renderer.material.color = Color.blue;
        }
    }

    public void searchForPlayer()
    {
        if(Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(fpsc.transform.position)) < fov/2f)
        {
            if(Vector3.Distance(fpsc.transform.position, transform.position) < viewDistance)
            {
                onAware();
            }
        }
    }

    public void onAware()
    {
        isAware = true;
    }

    public void takeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
    void doDamage()
    {
        if((distanceDifference.x < 2f) || (distanceDifference.y < 2f) || (distanceDifference.z < 2f))
        {
            animator.Play("Z_Attack");
            Debug.Log("Player has been caught!");
        }
    }


}
