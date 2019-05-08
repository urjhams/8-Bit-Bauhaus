using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public ObjectDialog dialog;
    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().startDialog(dialog);
    }
}
