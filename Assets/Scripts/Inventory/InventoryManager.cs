using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent){    
            Destroy(item.gameObject);
            //Items.RemoveAt(i);
        }

        foreach (var item in Items)
        {
            //GameObject obj = Instantiate(InventoryItem, ItemContent);
            //var getItemIcon = obj.transform.Find("itemIcon").GetComponent<Image>();

            //getItemName.text = item.itemName;
            //getItemIcon.sprite = item.Icon;
            
            GameObject objek = Instantiate(InventoryItem, ItemContent);
            objek.SetActive(true);
            

            var itemName = objek.transform.Find("Item Name").GetComponent<Text>();
            var iconItem = objek.transform.Find("Item Image").GetComponent<Image>();

            itemName.text = item.itemName;
            iconItem.sprite = item.Icon;
        }
    }

}
