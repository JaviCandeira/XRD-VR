using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputDemo : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerActions;
    private InputAction _myAction;

    private void Awake()
    {
        var rightHandInteractionActions = playerActions.FindActionMap("XRI RightHand Interaction");
        _myAction = rightHandInteractionActions.FindAction("MyAction");
    }

    void Update()
    {
        if (_myAction.triggered) Debug.Log("A was pressed");
    }
}