using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TindahanInteraction : MonoBehaviour
{
    [SerializeField] List<ItemManager> shopKeeperitemsForSale;
    [SerializeField] GameObject interactButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadShopMenu()
    {
        ShopManager.instance.itemsForSale = shopKeeperitemsForSale;
        ShopManager.instance.OpenShopMenu();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            interactButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            interactButton.SetActive(false);
        }
    }
}
