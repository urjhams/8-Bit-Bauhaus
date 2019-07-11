using UnityEngine;
using UnityEngine.EventSystems;

public class KeyHandle : DragHandle
{
    public override void OnEndDrag(PointerEventData eventData)
    {
        #region  IEndDragHAndler implementation
        if (GameManager.currentOverGameObjectName.Equals("detail_finalBox_discover"))
        {
            try 
            {
                GameObject.Find("detail_finalBox_discover").GetComponent<AudioSource>().Play();
            } catch {}
            base.destroyObject("key");
            Destroy(gameObject);
            GameManager.Room1Basement.goal = true;
        }
        base.OnEndDrag(eventData);
    }
    #endregion
}
