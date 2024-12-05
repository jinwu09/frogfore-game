using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookbookLocked : MonoBehaviour
{
    [SerializeField] GameObject CookBookButton;
    [SerializeField] SpriteRenderer CabinetCkBk;
    [SerializeField] Sprite OpenedCkBk;
    [SerializeField] GameObject Indicators;
    public string missionUnlock;
    // Start is called before the first frame update
    void Start()
    {
        CheckCookBook();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckCookBook()
    {
        bool MissionisComplete = TaskManager.instance.IsTaskComplete(missionUnlock);
        if(MissionisComplete)
        {
            CookBookButton.SetActive(true);
            CabinetCkBk.sprite = OpenedCkBk;
            Indicators.SetActive(false);
        }
    }
}
