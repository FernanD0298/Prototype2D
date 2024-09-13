using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlot : MonoBehaviour, IDropHandler
{
    public int SlotIndex;
    
    public void OnDrop(PointerEventData eventData)
    {
        GameObject Dropped = eventData.pointerDrag;
        DraggableItem DraggableItem = Dropped.GetComponent<DraggableItem>();

        if (transform.childCount > 0)
        {
            transform.GetChild(0).GetComponent<DraggableItem>().Selectable.raycastTarget = true;
            transform.GetChild(0).SetParent(Dropped.GetComponent<DraggableItem>().ParentBox);
        }
        
        DraggableItem.ParentAfterDrag = transform;
        DraggableItem.Equipped = true;
        DraggableItem.Selectable.raycastTarget = false;

        SetupCardInfo CardInfo = Dropped.GetComponent<SetupCardInfo>();
        if (SlotIndex == 1)
        {
            InventoryManager.Instance.CardEquipped1 = CardInfo.CardInfo;
        }
        else
        {
            InventoryManager.Instance.CardEquipped2 = CardInfo.CardInfo;
        }
    }
}
