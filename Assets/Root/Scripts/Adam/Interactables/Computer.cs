using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Computer : MonoBehaviour, IInteractable
{
    private Camera _mainCam;
    [SerializeField] private GameObject _notePanel;
    [SerializeField] private GameObject _noteHint;
    [SerializeField] private TextMeshProUGUI _noteText;
    [SerializeField] private InteractionUI _interactionUI;

    public bool isDisplayed = false;
    
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    private void Start()
    {
        _notePanel.SetActive(false);
        _noteHint.SetActive(false);
        _noteText.text = "";
    }
    
    public bool Interact(Interactor interactor)
    {
        if (!isDisplayed)
        {
            
            _prompt = "Close Notes";
            _interactionUI.SetUp(_prompt);
            _noteText.text = "These runes were deciphered from the electronic signals being passed between the plants in the Laboratory.";
            _notePanel.SetActive(true);
            _noteHint.SetActive(true);
            isDisplayed = true;
        }
        else if (isDisplayed)
        {
            _prompt = "View Notes";
            _interactionUI.SetUp(_prompt);
            _noteText.text = "";
            _notePanel.SetActive(false);
            _noteHint.SetActive(false);
            isDisplayed = false;
        }
        
        return true;
    }
}
