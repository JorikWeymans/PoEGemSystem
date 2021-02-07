// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/UIInputSettings.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Jorik.Input
{
    public class @UIInputSettings : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @UIInputSettings()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""UIInputSettings"",
    ""maps"": [
        {
            ""name"": ""TogglePanels"",
            ""id"": ""78e3b59c-fcc3-403a-8335-6613835b0ac8"",
            ""actions"": [
                {
                    ""name"": ""SkillPanel"",
                    ""type"": ""Button"",
                    ""id"": ""0c15a585-7df5-4f71-9c1c-f7a2a2319b76"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InventoryPanel"",
                    ""type"": ""Button"",
                    ""id"": ""2ae9bf0b-cbb5-4e90-a8e7-bcc23da10731"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3248aa96-0e84-466e-8caa-c3d9fbbc7008"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SkillPanel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75072055-05fa-456d-b089-81f8ef827845"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InventoryPanel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // TogglePanels
            m_TogglePanels = asset.FindActionMap("TogglePanels", throwIfNotFound: true);
            m_TogglePanels_SkillPanel = m_TogglePanels.FindAction("SkillPanel", throwIfNotFound: true);
            m_TogglePanels_InventoryPanel = m_TogglePanels.FindAction("InventoryPanel", throwIfNotFound: true);
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

        // TogglePanels
        private readonly InputActionMap m_TogglePanels;
        private ITogglePanelsActions m_TogglePanelsActionsCallbackInterface;
        private readonly InputAction m_TogglePanels_SkillPanel;
        private readonly InputAction m_TogglePanels_InventoryPanel;
        public struct TogglePanelsActions
        {
            private @UIInputSettings m_Wrapper;
            public TogglePanelsActions(@UIInputSettings wrapper) { m_Wrapper = wrapper; }
            public InputAction @SkillPanel => m_Wrapper.m_TogglePanels_SkillPanel;
            public InputAction @InventoryPanel => m_Wrapper.m_TogglePanels_InventoryPanel;
            public InputActionMap Get() { return m_Wrapper.m_TogglePanels; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(TogglePanelsActions set) { return set.Get(); }
            public void SetCallbacks(ITogglePanelsActions instance)
            {
                if (m_Wrapper.m_TogglePanelsActionsCallbackInterface != null)
                {
                    @SkillPanel.started -= m_Wrapper.m_TogglePanelsActionsCallbackInterface.OnSkillPanel;
                    @SkillPanel.performed -= m_Wrapper.m_TogglePanelsActionsCallbackInterface.OnSkillPanel;
                    @SkillPanel.canceled -= m_Wrapper.m_TogglePanelsActionsCallbackInterface.OnSkillPanel;
                    @InventoryPanel.started -= m_Wrapper.m_TogglePanelsActionsCallbackInterface.OnInventoryPanel;
                    @InventoryPanel.performed -= m_Wrapper.m_TogglePanelsActionsCallbackInterface.OnInventoryPanel;
                    @InventoryPanel.canceled -= m_Wrapper.m_TogglePanelsActionsCallbackInterface.OnInventoryPanel;
                }
                m_Wrapper.m_TogglePanelsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @SkillPanel.started += instance.OnSkillPanel;
                    @SkillPanel.performed += instance.OnSkillPanel;
                    @SkillPanel.canceled += instance.OnSkillPanel;
                    @InventoryPanel.started += instance.OnInventoryPanel;
                    @InventoryPanel.performed += instance.OnInventoryPanel;
                    @InventoryPanel.canceled += instance.OnInventoryPanel;
                }
            }
        }
        public TogglePanelsActions @TogglePanels => new TogglePanelsActions(this);
        public interface ITogglePanelsActions
        {
            void OnSkillPanel(InputAction.CallbackContext context);
            void OnInventoryPanel(InputAction.CallbackContext context);
        }
    }
}
