// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ControlsWrapper : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @ControlsWrapper()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""de89d4e8-f6c5-4398-bcac-44dfdd31417c"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""c3d6573b-2937-48bd-9a4d-c4522ff5174c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""afd95859-e7ec-4331-9191-2d07282c8868"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Button"",
                    ""id"": ""c4837c5b-6a94-45b2-bc61-e2470192ecfa"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Set Gravity"",
                    ""type"": ""Button"",
                    ""id"": ""b7f540c0-5152-409c-9e23-b22feffc7497"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap(duration=0.5),SlowTap(duration=0.5)""
                },
                {
                    ""name"": ""Directional Gravity"",
                    ""type"": ""Button"",
                    ""id"": ""288735c3-f2f1-4a84-badc-a62db791f75a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Cancel Gravity"",
                    ""type"": ""Button"",
                    ""id"": ""423046b9-5a73-40ee-9cb1-6d143bce976d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Graviton Surge"",
                    ""type"": ""Button"",
                    ""id"": ""08c34ede-90eb-4956-abb7-d72b8254f7eb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""f301e722-6bd8-4b80-88bb-85beb8041bf4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""8bb5147d-21dc-4c1f-b1bf-1ae08d74b7a0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""13dd2fed-025c-487e-98fb-119e63936e02"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""15d98782-2ee5-4d56-94d3-89767c22cd5a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""18bc7955-b4f5-435e-b4df-8c53cb25358e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""c8c5d94b-ac69-4d5d-bef0-1889f2585cbb"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Jump"",
                    ""id"": ""6555b1f5-8397-46b3-b47a-335d1aa75479"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""60cd459a-30e2-4d00-9a26-76109c609278"",
                    ""path"": ""<Keyboard>/leftAlt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""00dbc6c3-2693-4f33-aa22-1247b1582f19"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""98eb1ef8-6182-4cc6-ae23-a3547d473a38"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.1,y=0.1)"",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf508b01-77f6-4080-a4e0-86b031301c6f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Set Gravity"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d5a069e-5456-48da-b3e5-e054f236b86f"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Directional Gravity"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ef267a1-1adc-43b2-a5ca-e9b1d89369c7"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Cancel Gravity"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""544d7bfe-f37a-413b-86f3-a9921e987f16"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Graviton Surge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8e24ee8-1a57-415e-8176-ebbd6c3e8791"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""9b3e0113-4523-4c41-8436-50a9e1887940"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""9b052dc9-2a8e-44cb-bf1e-2990f2b93598"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Dismiss Popup"",
                    ""type"": ""Button"",
                    ""id"": ""50861bc5-0f21-4af4-8c0c-596f7929ac3a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""28f2273d-c00f-4ae1-a505-cbd8d0dbb94d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3fd97d5c-ec17-45bb-9902-001c50209661"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Dismiss Popup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse & Keyboard"",
            ""bindingGroup"": ""Mouse & Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Look = m_Gameplay.FindAction("Look", throwIfNotFound: true);
        m_Gameplay_SetGravity = m_Gameplay.FindAction("Set Gravity", throwIfNotFound: true);
        m_Gameplay_DirectionalGravity = m_Gameplay.FindAction("Directional Gravity", throwIfNotFound: true);
        m_Gameplay_CancelGravity = m_Gameplay.FindAction("Cancel Gravity", throwIfNotFound: true);
        m_Gameplay_GravitonSurge = m_Gameplay.FindAction("Graviton Surge", throwIfNotFound: true);
        m_Gameplay_Interact = m_Gameplay.FindAction("Interact", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Pause = m_UI.FindAction("Pause", throwIfNotFound: true);
        m_UI_DismissPopup = m_UI.FindAction("Dismiss Popup", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Look;
    private readonly InputAction m_Gameplay_SetGravity;
    private readonly InputAction m_Gameplay_DirectionalGravity;
    private readonly InputAction m_Gameplay_CancelGravity;
    private readonly InputAction m_Gameplay_GravitonSurge;
    private readonly InputAction m_Gameplay_Interact;
    public struct GameplayActions
    {
        private @ControlsWrapper m_Wrapper;
        public GameplayActions(@ControlsWrapper wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Look => m_Wrapper.m_Gameplay_Look;
        public InputAction @SetGravity => m_Wrapper.m_Gameplay_SetGravity;
        public InputAction @DirectionalGravity => m_Wrapper.m_Gameplay_DirectionalGravity;
        public InputAction @CancelGravity => m_Wrapper.m_Gameplay_CancelGravity;
        public InputAction @GravitonSurge => m_Wrapper.m_Gameplay_GravitonSurge;
        public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Look.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @SetGravity.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSetGravity;
                @SetGravity.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSetGravity;
                @SetGravity.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSetGravity;
                @DirectionalGravity.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDirectionalGravity;
                @DirectionalGravity.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDirectionalGravity;
                @DirectionalGravity.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDirectionalGravity;
                @CancelGravity.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCancelGravity;
                @CancelGravity.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCancelGravity;
                @CancelGravity.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCancelGravity;
                @GravitonSurge.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGravitonSurge;
                @GravitonSurge.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGravitonSurge;
                @GravitonSurge.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGravitonSurge;
                @Interact.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @SetGravity.started += instance.OnSetGravity;
                @SetGravity.performed += instance.OnSetGravity;
                @SetGravity.canceled += instance.OnSetGravity;
                @DirectionalGravity.started += instance.OnDirectionalGravity;
                @DirectionalGravity.performed += instance.OnDirectionalGravity;
                @DirectionalGravity.canceled += instance.OnDirectionalGravity;
                @CancelGravity.started += instance.OnCancelGravity;
                @CancelGravity.performed += instance.OnCancelGravity;
                @CancelGravity.canceled += instance.OnCancelGravity;
                @GravitonSurge.started += instance.OnGravitonSurge;
                @GravitonSurge.performed += instance.OnGravitonSurge;
                @GravitonSurge.canceled += instance.OnGravitonSurge;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Pause;
    private readonly InputAction m_UI_DismissPopup;
    public struct UIActions
    {
        private @ControlsWrapper m_Wrapper;
        public UIActions(@ControlsWrapper wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_UI_Pause;
        public InputAction @DismissPopup => m_Wrapper.m_UI_DismissPopup;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @DismissPopup.started -= m_Wrapper.m_UIActionsCallbackInterface.OnDismissPopup;
                @DismissPopup.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnDismissPopup;
                @DismissPopup.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnDismissPopup;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @DismissPopup.started += instance.OnDismissPopup;
                @DismissPopup.performed += instance.OnDismissPopup;
                @DismissPopup.canceled += instance.OnDismissPopup;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_MouseKeyboardSchemeIndex = -1;
    public InputControlScheme MouseKeyboardScheme
    {
        get
        {
            if (m_MouseKeyboardSchemeIndex == -1) m_MouseKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse & Keyboard");
            return asset.controlSchemes[m_MouseKeyboardSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnSetGravity(InputAction.CallbackContext context);
        void OnDirectionalGravity(InputAction.CallbackContext context);
        void OnCancelGravity(InputAction.CallbackContext context);
        void OnGravitonSurge(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnDismissPopup(InputAction.CallbackContext context);
    }
}
