using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLockSystem : MonoBehaviour
{
    public LevelManagement level1Management;
    public LevelManagement level2Management;
    public LevelManagement level3Management;

    public string LevelOne;
    public string LevelTwo;
    public string LevelThree;


    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void CheckLevel()
    {
        bool LvlOneisComplete = TaskManager.instance.IsTaskComplete(LevelOne);
        bool LvlTwoisComplete = TaskManager.instance.IsTaskComplete(LevelTwo);
        bool LvlThreeisComplete = TaskManager.instance.IsTaskComplete(LevelThree);
        if (LvlTwoisComplete)//If Level one is Completed Unlock Level 2
        {
            level2Management.UnlockLevel();
        }
        else
        {
            Debug.Log("Omelet is not complete.");
        }
        if (LvlThreeisComplete)// If Level two is Completed Unlock Level 3
        {
            level3Management.UnlockLevel();
        }
        else
        {
            Debug.Log("Aroz Caldo is not complete.");
        }
        if (LvlOneisComplete)
        {
            level1Management.UnlockLevel();
        }
    }
}
