using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private float moveSpeed = 0.2f;
    private Vector3 stopPosition;

    private float walkCounter;
    private float walkTime;

    private float waitCounter;
    private float waitTime;

    private int walkDirection;

    private bool isWaking;


    private void Start()
    {
        animator = GetComponent<Animator>();

        // random move and stop time
        waitTime = Random.Range(3, 6);
        walkTime = Random.Range(5, 7);

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();
    }

    private void Update()
    {
        if (isWaking)
        {
            animator.SetBool("isRunning", true);
            walkCounter -= Time.deltaTime;

            switch (walkDirection)
            {
                case 0:
                    transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    break;
                case 1:
                    transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    break;
                case 2:
                    transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    break;
                case 3:
                    transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    break;
            }

            if(walkCounter <= 0)
            {
                stopPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                // stop movement
                isWaking = false;
                transform.position = stopPosition;
                animator.SetBool("isRunning", false);

                // reset waitCounter
                waitCounter = waitTime;
            }
        }
        else
        {
            // idle time
            waitCounter -= Time.deltaTime;

            if(waitCounter <= 0)
            {
                // choose random direction to move
                ChooseDirection();
            }
        }
    }

    private void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);

        isWaking = true;
        walkCounter = walkTime;
    }


}
