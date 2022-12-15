using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public Animation Wing;
    private bool openState = false;
    [SerializeField] private InteractionUI _interactionUI;

    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    
    public bool Interact(Interactor interactor)
    {
        GetComponent<AudioSource>().Play();
        if (!openState)
        {
            _prompt = "Close Door";
            _interactionUI.SetUp(_prompt);
            Wing ["door_02_wing"].speed = 1;
            openState = true;
        }
        else if (openState){
            _prompt = "Open Door";
            _interactionUI.SetUp(_prompt);
            Wing ["door_02_wing"].time = Wing ["door_02_wing"].length;
            Wing ["door_02_wing"].speed = -1;
            openState = false;
        }
        Wing.Play();
        return true;
    }
}
