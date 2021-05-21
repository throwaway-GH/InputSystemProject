// GENERATED AUTOMATICALLY FROM 'Assets/PointerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PointerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PointerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PointerControls"",
    ""maps"": [
        {
            ""name"": ""pointer"",
            ""id"": ""86deda96-e9ed-48e9-bf1c-7f4456b19811"",
            ""actions"": [
                {
                    ""name"": ""point"",
                    ""type"": ""Value"",
                    ""id"": ""0e846370-e920-48fa-a4c9-013167fb5cbc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""MouseAndPen"",
                    ""id"": ""71fd34cb-c9e1-4006-830a-6edd1d26de53"",
                    ""path"": ""PointerInput"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""point"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""contact"",
                    ""id"": ""0db0ba38-ca1e-4035-a706-12cc083e825f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""contact"",
                    ""id"": ""218890f8-2338-4279-ac48-e98713f823c1"",
                    ""path"": ""<Pen>/tip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Pen"",
                    ""action"": ""point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""position"",
                    ""id"": ""09f60474-092c-4b91-94a8-3912e2f10656"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""position"",
                    ""id"": ""3756a343-5805-43d8-af8b-8e7cc63452b2"",
                    ""path"": ""<Pen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Pen"",
                    ""action"": ""point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Touch0"",
                    ""id"": ""4dd9868c-6807-44b2-9883-fae7a320d58c"",
                    ""path"": ""PointerInput"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""point"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""contact"",
                    ""id"": ""7b96c747-aae6-4a89-85f6-2dd9d61b6e32"",
                    ""path"": ""<Touchscreen>/touch0/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""position"",
                    ""id"": ""bcfcd0a0-0a9b-47d7-ad06-14abc2d2a841"",
                    ""path"": ""<Touchscreen>/touch0/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse"",
            ""bindingGroup"": ""Mouse"",
            ""devices"": []
        },
        {
            ""name"": ""Pen"",
            ""bindingGroup"": ""Pen"",
            ""devices"": []
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": []
        }
    ]
}");
        // pointer
        m_pointer = asset.FindActionMap("pointer", throwIfNotFound: true);
        m_pointer_point = m_pointer.FindAction("point", throwIfNotFound: true);
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

    // pointer
    private readonly InputActionMap m_pointer;
    private IPointerActions m_PointerActionsCallbackInterface;
    private readonly InputAction m_pointer_point;
    public struct PointerActions
    {
        private @PointerControls m_Wrapper;
        public PointerActions(@PointerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @point => m_Wrapper.m_pointer_point;
        public InputActionMap Get() { return m_Wrapper.m_pointer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PointerActions set) { return set.Get(); }
        public void SetCallbacks(IPointerActions instance)
        {
            if (m_Wrapper.m_PointerActionsCallbackInterface != null)
            {
                @point.started -= m_Wrapper.m_PointerActionsCallbackInterface.OnPoint;
                @point.performed -= m_Wrapper.m_PointerActionsCallbackInterface.OnPoint;
                @point.canceled -= m_Wrapper.m_PointerActionsCallbackInterface.OnPoint;
            }
            m_Wrapper.m_PointerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @point.started += instance.OnPoint;
                @point.performed += instance.OnPoint;
                @point.canceled += instance.OnPoint;
            }
        }
    }
    public PointerActions @pointer => new PointerActions(this);
    private int m_MouseSchemeIndex = -1;
    public InputControlScheme MouseScheme
    {
        get
        {
            if (m_MouseSchemeIndex == -1) m_MouseSchemeIndex = asset.FindControlSchemeIndex("Mouse");
            return asset.controlSchemes[m_MouseSchemeIndex];
        }
    }
    private int m_PenSchemeIndex = -1;
    public InputControlScheme PenScheme
    {
        get
        {
            if (m_PenSchemeIndex == -1) m_PenSchemeIndex = asset.FindControlSchemeIndex("Pen");
            return asset.controlSchemes[m_PenSchemeIndex];
        }
    }
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    public interface IPointerActions
    {
        void OnPoint(InputAction.CallbackContext context);
    }
}
