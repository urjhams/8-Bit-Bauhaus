using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnObjectTrigger : MonoBehaviour
{
    public GameObject[] triggerObjects;
    public virtual void OnMouseDown()
    {
        if (triggerObjects != null){
            foreach (var item in triggerObjects)
            {
                item.SetActive(true);
            }
        }
    }
}
