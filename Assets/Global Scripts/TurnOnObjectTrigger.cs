using UnityEngine;

public class TurnOnObjectTrigger : MonoBehaviour
{
    public GameObject[] triggerObjects;
    public virtual void OnMouseDown()
    {
        if (triggerObjects != null)
        {
            for (int index = 0; index < triggerObjects.Length; index++)
            {
                if (triggerObjects[index] != null)
                    triggerObjects[index].SetActive(true);
            }
        }
    }
}
