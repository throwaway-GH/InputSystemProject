// GENERATED AUTOMATICALLY FROM 'Assets/JustPointer.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @JustPointer : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @JustPointer()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""JustPointer"",
    ""maps"": [
        {
            ""name"": ""point"",
            ""id"": ""0d901abf-2fdb-4f1a-abb7-7e4584af50ea"",
            ""actions"": [
                {
                    ""name"": ""pointer"",
                    ""type"": ""Value"",
                    ""id"": ""688742b2-dc7d-4387-936b-dce3671d9aec"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Pointer Input"",
                    ""id"": ""7cc81883-fa15-4edb-a655-c60ddefffdad"",
                    ""path"": ""PointerInput"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""pointer"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""contact"",
                    ""id"": ""46642f5b-36f5-48de-b392-249386b01ec7"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""pointer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""position"",
                    ""id"": ""d6b4276a-eae3-486b-88dc-13d7456663ad"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""pointer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // point
        m_point = asset.FindActionMap("point", throwIfNotFound: true);
        m_point_pointer = m_point.FindAction("pointer", throwIfNotFound: true);
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

    // point
    private readonly InputActionMap m_point;
    private IPointActions m_PointActionsCallbackInterface;
    private readonly InputAction m_point_pointer;
    public struct PointActions
    {
        private @JustPointer m_Wrapper;
        public PointActions(@JustPointer wrapper) { m_Wrapper = wrapper; }
        public InputAction @pointer => m_Wrapper.m_point_pointer;
        public InputActionMap Get() { return m_Wrapper.m_point; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PointActions set) { return set.Get(); }
        public void SetCallbacks(IPointActions instance)
        {
            if (m_Wrapper.m_PointActionsCallbackInterface != null)
            {
                @pointer.started -= m_Wrapper.m_PointActionsCallbackInterface.OnPointer;
                @pointer.performed -= m_Wrapper.m_PointActionsCallbackInterface.OnPointer;
                @pointer.canceled -= m_Wrapper.m_PointActionsCallbackInterface.OnPointer;
            }
            m_Wrapper.m_PointActionsCallbackInterface = instance;
            if (instance != null)
            {
                @pointer.started += instance.OnPointer;
                @pointer.performed += instance.OnPointer;
                @pointer.canceled += instance.OnPointer;
            }
        }
    }
    public PointActions @point => new PointActions(this);
    public interface IPointActions
    {
        void OnPointer(InputAction.CallbackContext context);
    }
}
