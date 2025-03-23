using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    public List<ItemData> content = new List<ItemData>();
    [SerializeField]
    private GameObject inventoryPanel;
    [SerializeField]
    private Transform inventorySlotsParent;
    [SerializeField]
    private GameObject tooltip;
    [SerializeField]
    private Transform dropPoint;
    [SerializeField]
    private Sprite imageTransparent;
    [SerializeField]
    private Slot slot;
    private ItemData itemCurrentlySelected;

    [Header("Action panel element")]
    [SerializeField]
    private GameObject actionPanel;
    [SerializeField]
    private GameObject useEquipItemButton;
    [SerializeField]
    private GameObject dropItemButton;
    [SerializeField]
    private GameObject destroyItemButton;
    [SerializeField]
    private GameObject useEquipUsableText;
    [SerializeField]
    private GameObject useEquipUnusableText;
    [SerializeField]
    private GameObject dropUsableText;
    [SerializeField]
    private GameObject dropUnusableText;
    [SerializeField]
    private GameObject destroyUsableText;
    [SerializeField]
    private GameObject destroyUnusableText;


    public static Inventory instance;

    private void Awake(){
        instance = this;
    }
    private void Start(){
        inventoryPanel.SetActive(false);
        actionPanel.SetActive(false);
        tooltip.SetActive(false);
    }
    private void Update(){
        RefreshContent();
        if (Input.GetKeyDown(KeyCode.Tab) && (!GameManager.instance.isInMenu || GameManager.instance.isPlayerTriggered)){OpenInventory();}
    }
    private void OpenInventory(){
        GameManager.instance.SetIsInMenu(!inventoryPanel.activeSelf,true);
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        if(content.Count > 0)
        {
            OpenActionPanel(content[0]);
            slot.ClikOnSlot();
        }
    }
    private void RefreshContent()
    {
        for (int i = 0; i < 45; i++)
        {
            Slot currentSlot = inventorySlotsParent.GetChild(i).GetComponent<Slot>();
            if(i<content.Count){
                currentSlot.item = content[i];
                inventorySlotsParent.GetChild(i).GetChild(0).GetComponent<Image>().sprite = content[i].visual;
            }
            else{
                currentSlot.item = null;
                inventorySlotsParent.GetChild(i).GetChild(0).GetComponent<Image>().sprite = imageTransparent;
            }
        }
    }

    public void OpenActionPanel(ItemData item)
    {
        itemCurrentlySelected = item;
        if (item == null){
            actionPanel.SetActive(false);
            return;
        }

        switch (item.itemType)
        {
            case ItemType.Ressource:
                useEquipUsableText.SetActive(false);
                useEquipUnusableText.SetActive(true);
                dropUsableText.SetActive(item.loosable);
                dropUnusableText.SetActive(!item.loosable);
                destroyUsableText.SetActive(item.loosable);
                destroyUnusableText.SetActive(!item.loosable);
                
                useEquipItemButton.GetComponent<Button>().enabled = false;
                dropItemButton.GetComponent<Button>().enabled = item.loosable;
                destroyItemButton.GetComponent<Button>().enabled = item.loosable;
                break;
            case ItemType.Equipement:
            case ItemType.Consumable:
                useEquipUsableText.SetActive(true);
                useEquipUnusableText.SetActive(false);
                dropUsableText.SetActive(item.loosable);
                dropUnusableText.SetActive(!item.loosable);
                destroyUsableText.SetActive(item.loosable);
                destroyUnusableText.SetActive(!item.loosable);
                
                useEquipItemButton.GetComponent<Button>().enabled = true;
                dropItemButton.GetComponent<Button>().enabled = item.loosable;
                destroyItemButton.GetComponent<Button>().enabled = item.loosable;
                
                break;
        }
        actionPanel.SetActive(true);
    }

    public void CloseActionPanel(){
        actionPanel.SetActive(false);
        itemCurrentlySelected = null;
    }
    
    public void UseEquipActionButton(){
        CloseActionPanel();
    }
    
    public void DropActionButton(){
        GameObject instantiatedItem = Instantiate(itemCurrentlySelected.prefab);
        instantiatedItem.transform.position = dropPoint.position;
        content.Remove(itemCurrentlySelected);
        CloseActionPanel();
        tooltip.SetActive(false);
    }
    
    public void DestroyActionButton(){
        content.Remove(itemCurrentlySelected);
        CloseActionPanel();
        tooltip.SetActive(false);
    }
}
