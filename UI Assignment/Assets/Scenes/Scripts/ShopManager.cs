using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public int coins = 100;
    public List<MovableInventoryItem> upgrades;
    public List<GameObject> backPack_items;

    //Refs
    public Text coinText;
    public GameObject shopUI;
    public Transform shopContent;
    public GameObject itemPrefab;
    
    [SerializeField] private GameObject RoseQuartz;
    [SerializeField] private GameObject Potion;
    [SerializeField] private GameObject Crystal;
    [SerializeField] private GameObject Dirt;
    [SerializeField] private GameObject Backpack;
    private ShopManager shopManager;
    private void OnGUI()
    {
        coinText.text = "Coins: " + coins.ToString();
        
    }

    private void Start()
    {
        shopManager = FindObjectOfType<ShopManager>();
        foreach (MovableInventoryItem upgrade in upgrades)
        {
            GameObject item = Instantiate(itemPrefab, shopContent);
            upgrade.itemRef = item;

            foreach (Transform child in item.transform)
            {
                if (child.gameObject.name == "Quantity")
                {
                    child.gameObject.GetComponent<Text>().text = upgrade.quantity.ToString();
                }
                else if (child.gameObject.name == "Cost")
                {
                    child.gameObject.GetComponent<Text>().text = "$" + upgrade.cost.ToString();
                }
                else if (child.gameObject.name == "Name")
                {
                    child.gameObject.GetComponent<Text>().text = upgrade.name;
                    item.gameObject.name = upgrade.name;
                }
                else if (child.gameObject.name == "Image")
                {
                    child.gameObject.GetComponent<Image>().sprite = upgrade.image;
                }
            }

            item.GetComponent<Button>().onClick.AddListener(() =>
            {
                BuyUpgrade(upgrade);
                if (coins >= upgrade.cost)
                {
                    if (item.gameObject.name == "Rose Quartz")
                    {
                        GameObject item = Instantiate(RoseQuartz, Backpack.transform);
                        shopManager.backPack_items.Add(item);
                    }
                    else if (item.gameObject.name == "Potion")
                    {
                        GameObject item = Instantiate(Potion, Backpack.transform);
                        shopManager.backPack_items.Add(item);
                    }
                    else if (item.gameObject.name == "Crystal")
                    {
                        GameObject item = Instantiate(Crystal, Backpack.transform);
                        shopManager.backPack_items.Add(item);
                    }
                    else if (item.gameObject.name == "Dirt")
                    {
                        GameObject item = Instantiate(Dirt, Backpack.transform);
                        shopManager.backPack_items.Add(item);
                    }
                }
               
            });
        }
       
    }
    public void BuyUpgrade(MovableInventoryItem movableInventoryItem)
    {
        if (coins >= movableInventoryItem.cost)
        {
            coins -= movableInventoryItem.cost;
            movableInventoryItem.quantity++;
            movableInventoryItem.itemRef.transform.GetChild(0).GetComponent<Text>().text = movableInventoryItem.quantity.ToString();
            
            
            //ApplyUpgrade(upgrade)
        }
    }

    public void SellToShop(MovableInventoryItem item)
    {
        // add item back to shop
        upgrades.Add(item);
    }

    public void Sell_All()
    {
        coins = 100;
        foreach (GameObject item in backPack_items)
        {
            Destroy(item);
        }
    }
}

    
[System.Serializable]
public class MovableInventoryItem
{
    public string name;
    public int cost;
    public Sprite image;
    [HideInInspector] public int quantity;
    [HideInInspector] public GameObject itemRef;
}
