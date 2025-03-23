using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private ThirdPersonController tpc;
    public bool isInMenu = false;
    public bool isPlayerTriggered = false;
    void Awake()
    {
        if (instance == null){instance = this;}
        else{Destroy(gameObject);}
    }

    public void SetIsInMenu(bool state,bool fromPlayer)
    {
        isPlayerTriggered = fromPlayer;
        isInMenu = state;
        tpc.LockCameraPosition = state;
        SetCursor(state);
    }

    public void SetCursor(bool state)
    {
        Cursor.visible = state;
        if (state){Cursor.lockState = CursorLockMode.Confined;}
        else{Cursor.lockState = CursorLockMode.Locked;}
    }
}