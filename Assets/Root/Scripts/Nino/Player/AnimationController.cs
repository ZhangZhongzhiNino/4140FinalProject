using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class AnimationController : MonoBehaviour
{
    [BoxGroup("Reference")][Required][field: SerializeField] Animator animator;
    [BoxGroup("Reference")][Required][field: SerializeField] PlayerController playerController;

    [BoxGroup("Debug")][field:SerializeField] bool debug_Mode;
    [BoxGroup("Debug")][field: SerializeField] int debug_Play;
    void Start()
    {
        TryGetComponent<PlayerController>(out playerController);
        debug_Mode = false;
    }

    private void Update()
    {
        if (debug_Mode) 
        {
            if (animator.GetInteger("State") != debug_Play) animator.SetInteger("State", debug_Play);
            return;
        }
        
        if (playerController.moveState == 1  && animator.GetInteger("State") != 1) animator.SetInteger("State", 1);
        if (playerController.moveState == 2  && animator.GetInteger("State") != 2) animator.SetInteger("State", 2);
        if (playerController.moveState == 0 && animator.GetInteger("State") != 0) animator.SetInteger("State", 0);
    }
}
