using System;
using Unity.VisualScripting;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private GameObject RoseQuartz;
    [SerializeField] private GameObject Potion;
    [SerializeField] private GameObject Crystal;
    [SerializeField] private GameObject Dirt;
    [SerializeField] private GameObject Backpack;
    private ShopManager shopManager;

    private void Start()
    {
        Backpack = GameObject.FindGameObjectWithTag("BackPack");
        shopManager = FindObjectOfType<ShopManager>();
    }

    public void Shop_Item()
    {
        
        if (gameObject.name == "Rose Quartz")
        {
            GameObject item = Instantiate(RoseQuartz, Backpack.transform);
            shopManager.backPack_items.Add(item);
        }
        else if (gameObject.name == "Potion")
        {
            GameObject item = Instantiate(Potion, Backpack.transform);
            shopManager.backPack_items.Add(item);
        }
        else if (gameObject.name == "Crystal")
        {
            GameObject item = Instantiate(Crystal, Backpack.transform);
            shopManager.backPack_items.Add(item);
        }
        else if (gameObject.name == "Dirt")
        {
            GameObject item = Instantiate(Dirt, Backpack.transform);
            shopManager.backPack_items.Add(item);
        }
    }
    

    public void _Potion()
    {
        
    }

    public void _Crystal()
    {
        
    }

    public void _Dirt()
    {
        
    }

   
    void Update()
    {
        
    }
}
