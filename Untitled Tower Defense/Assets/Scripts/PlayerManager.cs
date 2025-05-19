using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;
using UnityEngine.XR.Interaction.Toolkit.Utilities;

public class PlayerManager : MonoBehaviour
{
    public XROrigin xrPlayer;
    public static PlayerManager instance;
    public GameObject rightTileRaycast;

    [SerializeField]
    [Tooltip("Input data that will be used to perform a jump.")]
    XRInputButtonReader m_PressA = new XRInputButtonReader("Press A Button");

    public XRInputButtonReader pressA{
        get => m_PressA;
        set => XRInputReaderUtility.SetInputProperty(ref m_PressA, value, this);
    }

    void Start(){
        instance = this;
    }

    void OnEnable(){
        // Enable and disable directly serialized actions with this behavior's enabled lifecycle.
        m_PressA.EnableDirectActionIfModeUsed();
    }
    
    void Update(){
        if(m_PressA.ReadIsPerformed()){
            rightTileRaycast.SetActive(!rightTileRaycast.activeSelf);
        }
    }

    void OnDisable(){
        m_PressA.DisableDirectActionIfModeUsed();
    }

}
