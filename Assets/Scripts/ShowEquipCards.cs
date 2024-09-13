using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowEquipCards : MonoBehaviour
{
    public GameObject CardPrefab;
    public Transform CardBox;
    public Transform Slot1;
    public Transform Slot2;
    
    [Header("Draggable Info")]
    public Transform UITransform;
    public Transform ParentAfterDrag;
    public Transform ParentBox;
    
    void Start()
    {
        List<Cards> CardsList = InventoryManager.Instance.CardsList;
        SetupCards(CardsList);
    }

    void SetupCards(List<Cards> CardsList)
    {
        for (int i = 0; i < CardsList.Count; i++)
        {
            if(InventoryManager.Instance.CardEquipped1.ID != 0)
                if (InventoryManager.Instance.CardEquipped1.ID == CardsList[i].ID)
                {
                    SetupEquippedCards(InventoryManager.Instance.CardEquipped1, Slot1);
                    continue;
                }
            if(InventoryManager.Instance.CardEquipped2.ID != 0)
                if (InventoryManager.Instance.CardEquipped2.ID == CardsList[i].ID)
                {
                    SetupEquippedCards(InventoryManager.Instance.CardEquipped2, Slot2);
                    continue;
                }

            GameObject Card = Instantiate(CardPrefab, CardBox, true);
            SetupCardInfo CardInfo = Card.GetComponent<SetupCardInfo>();
            CardInfo.CardInfo = CardsList[i];

            DraggableItem Item = Card.GetComponent<DraggableItem>();
            Item.ParentBox = ParentBox;
            Item.ParentAfterDrag = ParentAfterDrag;
            Item.UITransform = UITransform;
        }
        GetComponent<ShowCharacterInfo>().UpdateSlotsValues();
    }

    void SetupEquippedCards(Cards EquippedCard, Transform Slot)
    {
        GameObject Card = Instantiate(CardPrefab, Slot, true);
        SetupCardInfo CardInfo = Card.GetComponent<SetupCardInfo>();
        CardInfo.CardInfo = EquippedCard;
        Card.GetComponent<DraggableItem>().Selectable.raycastTarget = false;

        DraggableItem Item = Card.GetComponent<DraggableItem>();
        Item.ParentBox = ParentBox;
        Item.ParentAfterDrag = ParentAfterDrag;
        Item.UITransform = UITransform;
    }
    
}
