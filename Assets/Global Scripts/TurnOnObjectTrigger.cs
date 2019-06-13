using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnObjectTrigger : MonoBehaviour
{
    public GameObject[] triggerObjects;
    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    void OnMouseDown()
    {
        if (triggerObjects != null){
            foreach (var item in triggerObjects)
            {
                item.SetActive(true);
            }
        }
    }
}
