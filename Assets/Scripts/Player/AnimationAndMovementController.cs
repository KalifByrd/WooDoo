using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationAndMovementController : MonoBehaviour
{

    // delacre reference variables
    PlayerInput playerInput;
    CharacterController characterController;
    Animator animator;

    // variables to store optimized setter/getter parameter IDs
    int isWalkingHash;
    int isRunningHash;
    int isSwimmingHash;
    int isSwimIdleHash;
    int swimExitHash;
    int isCastingSpellHash;


    // variables to store player input values
    Vector2 currentMovementInput;
    Vector3 currentMovement;
    Vector3 currentRunMovement;
    bool isMovementPressed;
    bool isRunPressed;
    bool isCastingSpellPressed;

    [SerializeField]
    float rotationFactorPerFrame = 6.0f;
    float runMultiplier = 1.5f;
    float groundedGravity = -.03f;
    float gravity = -9.8f;

    public bool swimTriggered;
    public bool swimExitTriggered;

    [SerializeField]
    public bool movementDisabled;
    

    public Vector3 newHandPos;
    private CustomTag playerTags;

    //public Hills _activeLedge;

    public Vector3 GetStandUpPos(Hills ledge)
    {
        GameObject child = null;
        foreach(Transform transform in ledge.transform)
        {
            if(transform.CompareTag("StandPos"))
            {
                child = transform.gameObject;
                break;
            }
        }
        return child.GetComponent<RectTransform>().transform.position;
    }

    //Awake is called earlier than Start  in Unit's event life cycle
    void Awake()
    {
        // initally set reference variables
        playerTags = gameObject.GetComponent<CustomTag>();
        playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("IsWalking");
        isRunningHash = Animator.StringToHash("IsRunning");
        isSwimmingHash = Animator.StringToHash("IsSwimming");
        isSwimIdleHash = Animator.StringToHash("IsSwimIdle");
        swimExitHash = Animator.StringToHash("SwimExit");
        isCastingSpellHash = Animator.StringToHash("IsCastingSpell");

        playerInput.CharacterControls.Move.started += onMovementInput;
        playerInput.CharacterControls.Move.canceled += onMovementInput;
        playerInput.CharacterControls.Move.performed += onMovementInput;
        playerInput.CharacterControls.Run.started += onRun;
        playerInput.CharacterControls.Run.canceled += onRun;

        playerInput.CharacterControls.Cast.started += onCastInput;
    }

    void onRun(InputAction.CallbackContext context)
    {
        isRunPressed = context.ReadValueAsButton();
    }

    void handleRotation()
    {
        Vector3 positionToLookAt;
        // the change in position our character should point to
        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z;
        // the current rotation of our character
        Quaternion currentRotation = transform.rotation;
        if(isMovementPressed)
        {
            // Creates a new rotation based on where the player is currently pressing
            Quaternion taragetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, taragetRotation, rotationFactorPerFrame * Time.deltaTime);
        }
        
    }
    void onMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        currentRunMovement.x = currentMovementInput.x * runMultiplier;
        currentRunMovement.z = currentMovementInput.y * runMultiplier;
        isMovementPressed = currentMovementInput.x !=0 || currentMovementInput.y != 0;
    }
    void onCastInput(InputAction.CallbackContext context)
    {
        isCastingSpellPressed = context.ReadValueAsButton();
    
    }
        

    void handleAnimation()
    {
        // get parameter values from animator
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);

        bool isSwimming = animator.GetBool(isSwimmingHash);
        bool isSwimIdle = animator.GetBool(isSwimIdleHash);

        bool isCastingSpell = animator.GetBool(isCastingSpellHash);


        // start walking if  movement pressed is true and not already walking
        if(isMovementPressed && !isWalking && !swimTriggered)
        {
            animator.SetBool("IsWalking", true);
        }
        // stop walking if isMovementPressed is false and not already walking
        else if(!isMovementPressed && isWalking && !swimTriggered)
        {
            animator.SetBool("IsWalking", false);
        }
        // start swimming if movement pressed is ture and in water trigger and if not already swimming
        if(isMovementPressed && swimTriggered && !isSwimming)
        {
            Debug.Log("swimming");
            animator.SetBool("IsSwimming", true);
            animator.SetBool("IsSwimIdle", false);
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", false);
        }
        // start swim idle if  movement pressed is false and in water trigger and if not already swimming
        else if(!isMovementPressed && swimTriggered && isSwimming)
        {
            Debug.Log("swimming idle");
            animator.SetBool("IsSwimming", false);
            animator.SetBool("IsSwimIdle", true);
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", false);
        }

        if(swimExitTriggered && (isSwimming || isSwimIdle))
        {
            Debug.Log("exit swim");
            //swimTriggered = false;
            animator.SetBool("IsSwimming", false);
            animator.SetBool("IsSwimIdle", false);
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", false);
            animator.enabled = false;
            animator.enabled = true;
            animator.SetBool("SwimExit", true);
            
            
            Debug.Log(gameObject);
            
        }
        if(!swimExitTriggered)
        {
            animator.SetBool("SwimExit", false);
        }
        
        if(isCastingSpellPressed && (playerTags.HasTag("EarthAligned") || playerTags.HasTag("AirAligned") || playerTags.HasTag("FireAligned") || playerTags.HasTag("WaterAligned")))
        {
            animator.SetBool("IsCastingSpell", true);
            
            isCastingSpellPressed = false;
            
        }
        else if(!isCastingSpellPressed)
        {
            animator.SetBool("IsCastingSpell", false);
        }

        if((isMovementPressed && isRunPressed) && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }
        else if((!isMovementPressed || !isRunPressed) && isRunning)
        {
            animator.SetBool(isRunningHash, false);
        }
    }

    void handleGravity()
    {
        // apply proper gravity depending on if the character is grounded or not
        if(characterController.isGrounded)
        {
            currentMovement.y = groundedGravity;
            currentRunMovement.y = groundedGravity;
        }
        else
        {
            currentMovement.y += gravity;
            currentRunMovement.y += gravity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        handleGravity();
        
        handleAnimation();
        if(!movementDisabled)
        {
            handleRotation();
            if(isRunPressed)
            {
                characterController.Move(currentRunMovement * Time.deltaTime);
            }
            else
            {
                characterController.Move(currentMovement * Time.deltaTime);
            }
        }
        
    }

    void OnEnable()
    {
        // enable the character controls action map
        playerInput.CharacterControls.Enable();
    }

    void OnDisable()
    {
        // disable the character controls action map
        playerInput.CharacterControls.Disable();
    }
}
