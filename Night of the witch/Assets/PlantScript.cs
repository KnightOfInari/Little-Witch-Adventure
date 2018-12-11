using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{

    Animator animator;
    public AnimationClip attackAnimation;
    public AnimationClip idleAnimation;

    public float timeBetweenAttacks;
    private float attackTimer;

    private bool attacking;
    private bool idle;

    private void Start()
    {
        attackTimer = timeBetweenAttacks;
        animator = GetComponent<Animator>(); // get the animator attached to the game object
        if (animator == null)
        {
            Debug.LogError("No animator on " + gameObject.name);
        }
        idle = true;
        animator.Play(idleAnimation.name);

    }

    void Attack()
    {
        Debug.Log("attacking");
        attacking = true;
        idle = false;
        animator.Play(attackAnimation.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (attacking == true) // if the mob is moving
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer < 0f)
            {
                attacking = false;
                if (idle == false)
                {
                    idle = true;
                    animator.Play(idleAnimation.name);
                }
                attackTimer = Random.Range(timeBetweenAttacks * 0.50f, timeBetweenAttacks * 1.50f);
            }
        }
        else
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer < 0f)
            {
                Attack();
            }
        }
    }
}
