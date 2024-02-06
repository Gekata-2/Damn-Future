//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Combat"",
            ""id"": ""dc89fa7a-7f97-41ef-befa-c355828c0751"",
            ""actions"": [
                {
                    ""name"": ""LeftMouseClick"",
                    ""type"": ""Button"",
                    ""id"": ""3d671b02-a368-472e-83ee-ff8847348fea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightMouseClick"",
                    ""type"": ""Button"",
                    ""id"": ""589a0cac-50bd-4def-a1e5-859137e62864"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability0"",
                    ""type"": ""Button"",
                    ""id"": ""2e4b776e-405f-4980-b6ea-6f9bdffbc9a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability1"",
                    ""type"": ""Button"",
                    ""id"": ""81fe5bbb-1103-4c70-9a5b-a26a60fd7144"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability2"",
                    ""type"": ""Button"",
                    ""id"": ""3eb921b3-eba8-437c-83ad-8de6dc39bbd0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability3"",
                    ""type"": ""Button"",
                    ""id"": ""7c6b1733-abde-40b7-b228-6e1c48096464"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability4"",
                    ""type"": ""Button"",
                    ""id"": ""39329354-0392-43d0-814b-014376257abc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability5"",
                    ""type"": ""Button"",
                    ""id"": ""c87f833c-263d-422a-a907-6c5e1d55c0c6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability6"",
                    ""type"": ""Button"",
                    ""id"": ""3aadadbd-6f6a-4947-848c-9959daa5729f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7b58e1ae-a4e9-42d9-a232-209b1aded87f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftMouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35fe3f4d-5420-4b55-ac25-111478ea5d48"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightMouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""585f0dd6-7668-4ebe-92b0-90f94f2940cf"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""803c91c2-8e92-4a1c-8bf8-f464730a5e38"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dcfbc9ef-6179-4621-9678-9d2014ac447c"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5a79fc6-7dbe-44cb-bd7b-6506090418f3"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48bb11c0-52e6-46e6-a72f-dfd5d831e192"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fca66d39-9754-4369-b13c-dfe72bf50999"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3db94d75-a52c-4499-a4f6-578a0addc4db"",
                    ""path"": ""<Keyboard>/7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Combat
        m_Combat = asset.FindActionMap("Combat", throwIfNotFound: true);
        m_Combat_LeftMouseClick = m_Combat.FindAction("LeftMouseClick", throwIfNotFound: true);
        m_Combat_RightMouseClick = m_Combat.FindAction("RightMouseClick", throwIfNotFound: true);
        m_Combat_Ability0 = m_Combat.FindAction("Ability0", throwIfNotFound: true);
        m_Combat_Ability1 = m_Combat.FindAction("Ability1", throwIfNotFound: true);
        m_Combat_Ability2 = m_Combat.FindAction("Ability2", throwIfNotFound: true);
        m_Combat_Ability3 = m_Combat.FindAction("Ability3", throwIfNotFound: true);
        m_Combat_Ability4 = m_Combat.FindAction("Ability4", throwIfNotFound: true);
        m_Combat_Ability5 = m_Combat.FindAction("Ability5", throwIfNotFound: true);
        m_Combat_Ability6 = m_Combat.FindAction("Ability6", throwIfNotFound: true);
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

    // Combat
    private readonly InputActionMap m_Combat;
    private List<ICombatActions> m_CombatActionsCallbackInterfaces = new List<ICombatActions>();
    private readonly InputAction m_Combat_LeftMouseClick;
    private readonly InputAction m_Combat_RightMouseClick;
    private readonly InputAction m_Combat_Ability0;
    private readonly InputAction m_Combat_Ability1;
    private readonly InputAction m_Combat_Ability2;
    private readonly InputAction m_Combat_Ability3;
    private readonly InputAction m_Combat_Ability4;
    private readonly InputAction m_Combat_Ability5;
    private readonly InputAction m_Combat_Ability6;
    public struct CombatActions
    {
        private @PlayerInputActions m_Wrapper;
        public CombatActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftMouseClick => m_Wrapper.m_Combat_LeftMouseClick;
        public InputAction @RightMouseClick => m_Wrapper.m_Combat_RightMouseClick;
        public InputAction @Ability0 => m_Wrapper.m_Combat_Ability0;
        public InputAction @Ability1 => m_Wrapper.m_Combat_Ability1;
        public InputAction @Ability2 => m_Wrapper.m_Combat_Ability2;
        public InputAction @Ability3 => m_Wrapper.m_Combat_Ability3;
        public InputAction @Ability4 => m_Wrapper.m_Combat_Ability4;
        public InputAction @Ability5 => m_Wrapper.m_Combat_Ability5;
        public InputAction @Ability6 => m_Wrapper.m_Combat_Ability6;
        public InputActionMap Get() { return m_Wrapper.m_Combat; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CombatActions set) { return set.Get(); }
        public void AddCallbacks(ICombatActions instance)
        {
            if (instance == null || m_Wrapper.m_CombatActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CombatActionsCallbackInterfaces.Add(instance);
            @LeftMouseClick.started += instance.OnLeftMouseClick;
            @LeftMouseClick.performed += instance.OnLeftMouseClick;
            @LeftMouseClick.canceled += instance.OnLeftMouseClick;
            @RightMouseClick.started += instance.OnRightMouseClick;
            @RightMouseClick.performed += instance.OnRightMouseClick;
            @RightMouseClick.canceled += instance.OnRightMouseClick;
            @Ability0.started += instance.OnAbility0;
            @Ability0.performed += instance.OnAbility0;
            @Ability0.canceled += instance.OnAbility0;
            @Ability1.started += instance.OnAbility1;
            @Ability1.performed += instance.OnAbility1;
            @Ability1.canceled += instance.OnAbility1;
            @Ability2.started += instance.OnAbility2;
            @Ability2.performed += instance.OnAbility2;
            @Ability2.canceled += instance.OnAbility2;
            @Ability3.started += instance.OnAbility3;
            @Ability3.performed += instance.OnAbility3;
            @Ability3.canceled += instance.OnAbility3;
            @Ability4.started += instance.OnAbility4;
            @Ability4.performed += instance.OnAbility4;
            @Ability4.canceled += instance.OnAbility4;
            @Ability5.started += instance.OnAbility5;
            @Ability5.performed += instance.OnAbility5;
            @Ability5.canceled += instance.OnAbility5;
            @Ability6.started += instance.OnAbility6;
            @Ability6.performed += instance.OnAbility6;
            @Ability6.canceled += instance.OnAbility6;
        }

        private void UnregisterCallbacks(ICombatActions instance)
        {
            @LeftMouseClick.started -= instance.OnLeftMouseClick;
            @LeftMouseClick.performed -= instance.OnLeftMouseClick;
            @LeftMouseClick.canceled -= instance.OnLeftMouseClick;
            @RightMouseClick.started -= instance.OnRightMouseClick;
            @RightMouseClick.performed -= instance.OnRightMouseClick;
            @RightMouseClick.canceled -= instance.OnRightMouseClick;
            @Ability0.started -= instance.OnAbility0;
            @Ability0.performed -= instance.OnAbility0;
            @Ability0.canceled -= instance.OnAbility0;
            @Ability1.started -= instance.OnAbility1;
            @Ability1.performed -= instance.OnAbility1;
            @Ability1.canceled -= instance.OnAbility1;
            @Ability2.started -= instance.OnAbility2;
            @Ability2.performed -= instance.OnAbility2;
            @Ability2.canceled -= instance.OnAbility2;
            @Ability3.started -= instance.OnAbility3;
            @Ability3.performed -= instance.OnAbility3;
            @Ability3.canceled -= instance.OnAbility3;
            @Ability4.started -= instance.OnAbility4;
            @Ability4.performed -= instance.OnAbility4;
            @Ability4.canceled -= instance.OnAbility4;
            @Ability5.started -= instance.OnAbility5;
            @Ability5.performed -= instance.OnAbility5;
            @Ability5.canceled -= instance.OnAbility5;
            @Ability6.started -= instance.OnAbility6;
            @Ability6.performed -= instance.OnAbility6;
            @Ability6.canceled -= instance.OnAbility6;
        }

        public void RemoveCallbacks(ICombatActions instance)
        {
            if (m_Wrapper.m_CombatActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICombatActions instance)
        {
            foreach (var item in m_Wrapper.m_CombatActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CombatActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CombatActions @Combat => new CombatActions(this);
    public interface ICombatActions
    {
        void OnLeftMouseClick(InputAction.CallbackContext context);
        void OnRightMouseClick(InputAction.CallbackContext context);
        void OnAbility0(InputAction.CallbackContext context);
        void OnAbility1(InputAction.CallbackContext context);
        void OnAbility2(InputAction.CallbackContext context);
        void OnAbility3(InputAction.CallbackContext context);
        void OnAbility4(InputAction.CallbackContext context);
        void OnAbility5(InputAction.CallbackContext context);
        void OnAbility6(InputAction.CallbackContext context);
    }
}