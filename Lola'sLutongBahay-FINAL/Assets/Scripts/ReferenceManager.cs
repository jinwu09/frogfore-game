using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceManager : MonoBehaviour
{
    public EggCooking myScriptReference;
    public void egg(GameObject cloneObject)
    {
        // Assuming MyScript is attached to the cloneObject
        myScriptReference = cloneObject.GetComponent<EggCooking>();
    }
}
