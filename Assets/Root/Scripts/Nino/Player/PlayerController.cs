using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerController : MonoBehaviour
{

    [BoxGroup("Reference")][Required][field:SerializeField]InputHandeler inputHandeler;
    [BoxGroup("Reference")][Required][field: SerializeField] GroundChecker groundChecker;
    [BoxGroup("Reference")][Required] CharacterController cc;


    [TabGroup("Value Input")][field: SerializeField] float walkSpeed;
    [TabGroup("Value Input")][field: SerializeField] float runSpeed;
    [TabGroup("Value Input")][field: SerializeField] float gravityForce;
    [TabGroup("Value Input")][field: SerializeField] float rotationLerpSpeed;
    [Button][GUIColor(0.6f,1,0.6f)][TabGroup("Value Input")] void RestoreDefaultValue()
    {
        walkSpeed = 1;
        runSpeed = 3.3f;
        gravityForce = 0.25f;
        rotationLerpSpeed = 7;
    }

    [TabGroup("State Debug")] public int moveState;
    [TabGroup("State Debug")][field: SerializeField] float VelocityY;

    
    
    void Start()
    {
        TryGetComponent<CharacterController>(out cc);
        VelocityY = 0;
        moveState = 0;
    }
    private void OnEnable()
    {
        inputHandeler.onWalk.AddListener(PlayerWalk);
        inputHandeler.onRun.AddListener(PlayerRun);
    }
    private void OnDisable()
    {
        inputHandeler.onWalk.RemoveListener(PlayerWalk);
        inputHandeler.onRun.RemoveListener(PlayerRun);
    }
    public void PlayerWalk()
    {
        moveState = 1;
        cc.Move(inputHandeler.moveDirection * walkSpeed * Time.fixedDeltaTime);
        lookForward();
    }
    public void PlayerRun()
    {
        moveState = 2;
        cc.Move(inputHandeler.moveDirection * runSpeed * Time.fixedDeltaTime);
        lookForward();
    }
    private void FixedUpdate()
    {
        if (!groundChecker.onGround) VelocityY -= gravityForce * Time.fixedDeltaTime;
        else VelocityY = -gravityForce;

        cc.Move(new Vector3(0, VelocityY, 0));

        if (inputHandeler.moveDirection == Vector3.zero) moveState = 0;
    }
    private void lookForward()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(inputHandeler.moveDirection), rotationLerpSpeed * Time.fixedDeltaTime);
    }
}
