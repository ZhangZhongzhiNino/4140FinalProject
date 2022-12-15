using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VialSwitch : MonoBehaviour, IInteractable
{
    public Animator animator;
    private bool isBlue = false;
    [SerializeField] private InteractionUI _interactionUI;

    [SerializeField] private string _prompt = "Change Color";
    public string InteractionPrompt => _prompt;
    
    public bool Interact(Interactor interactor)
    {
        GetComponent<AudioSource>().Play();
        if (!isBlue)
        {
            animator.SetBool("Active", true);
            isBlue = true;
        }
        else if (isBlue){
            animator.SetBool("Active", false);
            isBlue = false;
        }

        return true;
    }
}