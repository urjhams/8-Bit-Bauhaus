﻿using UnityEngine;
using UnityEngine.EventSystems;

public class LastPeiceHandle : DragHandle
{
    #region  IEndDragHAndler implementation
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (GameManager.currentOverGameObjectName.Equals("puzzle peice 10"))
        {
            try
            {
                GameObject.Find("Background").GetComponent<AudioSource>().Play();
            }
            catch { }
            base.destroyObject("lastpeice");
            Destroy(gameObject);
            GameManager.Room1.goal = true;
        }
        base.OnEndDrag(eventData);
    }
    #endregion
}
