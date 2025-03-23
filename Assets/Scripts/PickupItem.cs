using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PickupItem : MonoBehaviour
{
    [SerializeField]
    private GameObject pickupText;
    [SerializeField]
    private GameObject inventoryPanel;
    public ThirdPersonController tps;
    public Inventory inventory;
    public float reach;
    public ItemData Pile;
    public Animator animator;
    public bool Slowed = false;
    private float speed = 0;
    private Item currentItem;
    private float Diff;
    private GameObject NearItem;
    private GameObject NearContainer;
    private float diffTemp;
    private float diffX;
    private float diffY;
    private float diffZ;
    private bool InAnimation = false;
    private GameObject[] li;
    List<GameObject> PickableObject = new List<GameObject>();
    List<GameObject> OpenableContainer = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        speed = animator.GetFloat("Speed");
        Diff=50;
        diffTemp=50;
        li=GameObject.FindGameObjectsWithTag ("Item");
        PickableObject.Clear();
        ItemInRange(li);
        NearItem=null;
        if (PickableObject.Count!=0 && !inventoryPanel.activeSelf){
            pickupText.SetActive(true);
        }
        else{
            pickupText.SetActive(false);
        }
        NearestItem(PickableObject);
        if(ConditionPickup()){
            inventory.content.Add(NearItem.GetComponent<Item>().item);
            if (InAnimation==false){
                animator.SetTrigger("Pickup");
                InAnimation=true;
                }
            Destroy(NearItem);
            Slowed = true;
        }
    }

    public bool ConditionPickup(){
        return (speed < 2.1 && !(inventory.content.Count>44) && Input.GetKeyDown(KeyCode.E) && NearItem!=null && !inventoryPanel.activeSelf && tps.Grounded);
    }
    public void ItemInRange(GameObject[] listItem){
        foreach(GameObject item in listItem){
            if((item.transform.position.x-gameObject.transform.position.x)<reach && (item.transform.position.x-gameObject.transform.position.x)>-reach && (item.transform.position.y-gameObject.transform.position.y)<reach && (item.transform.position.y-gameObject.transform.position.y)>-reach && (item.transform.position.z-gameObject.transform.position.z)<reach && (item.transform.position.z-gameObject.transform.position.z)>-reach){
                PickableObject.Add(item);
            }
        }
    }
    public void NearestItem(List<GameObject> PickableObject){
        foreach(GameObject collectable in PickableObject){
                if((collectable.transform.position.x-gameObject.transform.position.x)<reach && (collectable.transform.position.x-gameObject.transform.position.x)>-reach && (collectable.transform.position.y-gameObject.transform.position.y)<reach && (collectable.transform.position.y-gameObject.transform.position.y)>-reach && (collectable.transform.position.z-gameObject.transform.position.z)<reach && (collectable.transform.position.z-gameObject.transform.position.z)>-reach){
                    diffX = collectable.transform.position.x-gameObject.transform.position.x;
                    diffY = collectable.transform.position.y-gameObject.transform.position.y;
                    diffZ = collectable.transform.position.z-gameObject.transform.position.z;
                    if(diffX < 0 ){
                        diffX = -diffX;
                    }
                    if(diffY < 0 ){
                        diffY = -diffY;
                    }
                    if(diffZ < 0) {
                        diffZ = -diffZ;
                    }
                    diffTemp=diffX+diffY+diffZ;
                    if(diffTemp<Diff){
                        Diff=diffTemp;
                        NearItem=collectable;
                    }
                }
            }
        }
    public void Destroying(){
            Destroy(currentItem);
            currentItem = null;
        }
    
    public void EndAnimation(){
            Slowed = false;
            InAnimation = false;
        }
}