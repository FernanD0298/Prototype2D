using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image Selectable;
    public Transform UITransform;
    public Transform ParentAfterDrag;
    public Transform ParentBox;
    public bool Equipped = false;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(UITransform);
        transform.SetAsLastSibling();
        Selectable.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(ParentAfterDrag);
        ShowCharacterInfo ShowInfo = UITransform.GetComponent<ShowCharacterInfo>();
        ShowInfo.RestartValues();
        ShowInfo.UpdateSlotsValues();
        if(!Equipped)
            Selectable.raycastTarget = true;
    }
}
