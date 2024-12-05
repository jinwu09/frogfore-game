using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FarmHarvest : MonoBehaviour
{
    [SerializeField] Sprite harvestedPlantSprite;

    public ItemManager itemManager;

    public bool harvestcount = false;
    [SerializeField] UnityEvent onHarvest;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Harvest()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = harvestedPlantSprite;
            itemManager.HarvestPlant();
            onHarvest.Invoke();
        }
        harvestcount = true;
    }
}
