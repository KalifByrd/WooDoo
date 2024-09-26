using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowAIMovement : MonoBehaviour
{
    public float movementSpeed = 20f;
    public float rotationSpeed = 100f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight= false;
    private bool walkTriggered = false;

    int isWalkingHash;
    int isRunningHash;
    int isRestingHash;
    int isEatingHash;

    Rigidbody rb;
    Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("IsWalking");
        isRunningHash = Animator.StringToHash("IsRunning");
        isRestingHash = Animator.StringToHash("IsResting");
        isEatingHash = Animator.StringToHash("IsEating");
    }

    // Update is called once per frame
    void Update()
    {
        handleAnimation();
        if(!isWandering)
        {
            StartCoroutine(Wander());
        }
        if(isRotatingRight)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
        }
        if(isRotatingLeft)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
        }
        if(walkTriggered)
        {
            rb.AddForce(transform.forward * movementSpeed);
        }
    }

    void handleAnimation()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool isResting = animator.GetBool(isRestingHash);
        bool isEating = animator.GetBool(isEatingHash);

        if((walkTriggered || isRotatingLeft || isRotatingRight) && !isWalking)
        {
            animator.SetBool("IsWalking", true);
        }
        if((!walkTriggered || !isRotatingLeft || !isRotatingRight) && isWalking)
        {
            animator.SetBool("IsWalking", false);
        }

    }

    IEnumerator Wander()
    {
        int rotationTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 3);
        int rotateDirection = Random.Range(1, 2);
        int walkWait = Random.Range(1, 3);
        int walkTime = Random.Range(1, 3);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);

        walkTriggered = true;

        yield return new WaitForSeconds(walkTime);

        walkTriggered = false;

        yield return new WaitForSeconds(rotateWait);

        if(rotateDirection == 1)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingLeft = false;
        }
        if(rotateDirection == 2)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingRight = false;
        }

        isWandering = false;

    }
}
