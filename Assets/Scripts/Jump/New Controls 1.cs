//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Scripts/Jump/New Controls 1.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @NewControls1 : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @NewControls1()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""New Controls 1"",
    ""maps"": [
        {
            ""name"": ""Sheep (player)"",
            ""id"": ""0ab60e1d-f056-424d-a138-07be6e7dd366"",
            ""actions"": [
                {
                    ""name"": ""sheild"",
                    ""type"": ""Button"",
                    ""id"": ""75240a71-2e77-4a26-a1aa-a96af0a076d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""128fae5d-79ec-48e3-97d0-baedeb76230e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""EnterGame"",
                    ""type"": ""Value"",
                    ""id"": ""c99d72f7-4f47-41e4-8371-acff2de4c0d5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a41f4e97-fe29-4538-aeb0-52d55c6dda6b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""arrow keys and space bar"",
                    ""action"": ""sheild"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b06b8f0c-5983-4a3c-b41b-82254cd51ba8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fbc1b371-7d42-4e48-8d61-c9760131b060"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""49a86f9c-31ee-420e-b72d-129d40ca83de"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ed1a6d5f-f4cb-492e-b237-a6c2835350f4"",
                    ""path"": ""<Keyboard>/#(a)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""481319f9-a03f-4615-95ed-bd792b2d6a6a"",
                    ""path"": ""<Keyboard>/#(d)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""880d3407-04e6-494f-ba65-552bf351d705"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EnterGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c7799fe-791e-44ad-b42f-a29fb85865d9"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EnterGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""arrow keys and space bar"",
            ""bindingGroup"": ""arrow keys and space bar"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Sheep (player)
        m_Sheepplayer = asset.FindActionMap("Sheep (player)", throwIfNotFound: true);
        m_Sheepplayer_sheild = m_Sheepplayer.FindAction("sheild", throwIfNotFound: true);
        m_Sheepplayer_Move = m_Sheepplayer.FindAction("Move", throwIfNotFound: true);
        m_Sheepplayer_EnterGame = m_Sheepplayer.FindAction("EnterGame", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Sheep (player)
    private readonly InputActionMap m_Sheepplayer;
    private ISheepplayerActions m_SheepplayerActionsCallbackInterface;
    private readonly InputAction m_Sheepplayer_sheild;
    private readonly InputAction m_Sheepplayer_Move;
    private readonly InputAction m_Sheepplayer_EnterGame;
    public struct SheepplayerActions
    {
        private @NewControls1 m_Wrapper;
        public SheepplayerActions(@NewControls1 wrapper) { m_Wrapper = wrapper; }
        public InputAction @sheild => m_Wrapper.m_Sheepplayer_sheild;
        public InputAction @Move => m_Wrapper.m_Sheepplayer_Move;
        public InputAction @EnterGame => m_Wrapper.m_Sheepplayer_EnterGame;
        public InputActionMap Get() { return m_Wrapper.m_Sheepplayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SheepplayerActions set) { return set.Get(); }
        public void SetCallbacks(ISheepplayerActions instance)
        {
            if (m_Wrapper.m_SheepplayerActionsCallbackInterface != null)
            {
                @sheild.started -= m_Wrapper.m_SheepplayerActionsCallbackInterface.OnSheild;
                @sheild.performed -= m_Wrapper.m_SheepplayerActionsCallbackInterface.OnSheild;
                @sheild.canceled -= m_Wrapper.m_SheepplayerActionsCallbackInterface.OnSheild;
                @Move.started -= m_Wrapper.m_SheepplayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_SheepplayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_SheepplayerActionsCallbackInterface.OnMove;
                @EnterGame.started -= m_Wrapper.m_SheepplayerActionsCallbackInterface.OnEnterGame;
                @EnterGame.performed -= m_Wrapper.m_SheepplayerActionsCallbackInterface.OnEnterGame;
                @EnterGame.canceled -= m_Wrapper.m_SheepplayerActionsCallbackInterface.OnEnterGame;
            }
            m_Wrapper.m_SheepplayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @sheild.started += instance.OnSheild;
                @sheild.performed += instance.OnSheild;
                @sheild.canceled += instance.OnSheild;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @EnterGame.started += instance.OnEnterGame;
                @EnterGame.performed += instance.OnEnterGame;
                @EnterGame.canceled += instance.OnEnterGame;
            }
        }
    }
    public SheepplayerActions @Sheepplayer => new SheepplayerActions(this);
    private int m_arrowkeysandspacebarSchemeIndex = -1;
    public InputControlScheme arrowkeysandspacebarScheme
    {
        get
        {
            if (m_arrowkeysandspacebarSchemeIndex == -1) m_arrowkeysandspacebarSchemeIndex = asset.FindControlSchemeIndex("arrow keys and space bar");
            return asset.controlSchemes[m_arrowkeysandspacebarSchemeIndex];
        }
    }
    public interface ISheepplayerActions
    {
        void OnSheild(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnEnterGame(InputAction.CallbackContext context);
    }
}
