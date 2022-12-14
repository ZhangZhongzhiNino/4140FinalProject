using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionRadius = 0.5f;
    [SerializeField] private LayerMask _interactionMask;
    [SerializeField] private InteractionUI _interactionUI;

    private Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private IInteractable _interactable;

    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionRadius, _colliders,
            _interactionMask);

        if (_numFound > 0)
        {
            _interactable = _colliders[0].GetComponent<IInteractable>();

            if (_interactable != null)
            {
                if (!_interactionUI.isDisplayed) _interactionUI.SetUp(_interactable.InteractionPrompt);

                if (Keyboard.current.eKey.wasPressedThisFrame) _interactable.Interact(this);
            }

            if (_numFound > 1)
            {
                _interactable = _colliders[1].GetComponent<IInteractable>();

                if (_interactable != null)
                {
                    if (!_interactionUI.isDisplayed) _interactionUI.SetUp(_interactable.InteractionPrompt);

                    if (Keyboard.current.eKey.wasPressedThisFrame) _interactable.Interact(this);
                }
            }
        }
        else
        {
            if (_interactable != null) _interactable = null;
            if (_interactionUI.isDisplayed) _interactionUI.Close();
        }
    }
}
