using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField]
    private GameObject ToolTip;
    [SerializeField]
    private Text headerField;
    [SerializeField]
    private Text descriptionField;
    [SerializeField]
    private Image imageField;
    public ItemData item;
    
    public void ClikOnSlot(){
        if (item!=null){
            headerField.text = item.name;
            descriptionField.text = item.description;
            imageField.sprite = item.visual;
            ToolTip.SetActive(true);
        }
        else{
            ToolTip.SetActive(false);
        }
        Inventory.instance.OpenActionPanel(item);
    }
}