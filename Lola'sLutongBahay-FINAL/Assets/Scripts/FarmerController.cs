using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerController : MonoBehaviour
{
    public GameObject harvestButton;
    private FarmHarvest currentPlant;

    void Update()
    {
        if(harvestButton == null)
        {
            harvestButton = GameObject.FindWithTag("Harvest");
        }
        else
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Plant"))
        {
            currentPlant = collision.gameObject.GetComponent<FarmHarvest>();
            if (currentPlant != null)
            {
                harvestButton.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Plant"))
        {
            harvestButton.SetActive(false);
            currentPlant = null;
        }
    }

    public void HarvestPlant()
    {
        if (currentPlant != null)
        {
            currentPlant.Harvest();
        }
    }
}

