using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertPanel : MonoBehaviour
{
    public GameObject alertPanel;

    void Start()
    {
        alertPanel.SetActive(true);
        GameManager.instance.SetIsInMenu(true,false);
    }

    public void SetAlertPanel()
    {
        GameManager.instance.SetIsInMenu(!alertPanel.activeSelf,false);
        alertPanel.SetActive(!alertPanel.activeSelf);
    }
}