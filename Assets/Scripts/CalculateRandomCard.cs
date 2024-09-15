using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalculateRandomCard : MonoBehaviour
{
    public GameObject CardPanel;
    public RawImage Image;
    public TextMeshProUGUI Upgrade;
    public TextMeshProUGUI Downgrade;
    public Gacha GachaInfo;
    public CharactersData Data;

    public void BuyCard()
    {
        int Cost = gameObject.GetComponent<LoadBannerButtons>().CurrentCardCost;
        if(!InventoryManager.Instance.CheckIfHaveEnoughMoney(Cost)) return;
        
        CardPanel.SetActive(true);
        int RandomNum = Random.Range(1, 101);
        bool SetCard = false;
        
        for (int i = 0; i < GachaInfo.CardsInBanner.Count; i++)
        {
            if (RandomNum < GachaInfo.CardsInBanner[i].Probability)
            {
                for (int j = 0; j < Data.CardsList.Count; j++)
                {
                    if (Data.CardsList[j].ID == GachaInfo.CardsInBanner[i].CardID)
                    {
                        InventoryManager.Instance.AddCard(Data.CardsList[j]);
                        Image.texture = Data.CardsList[j].Image;
                        Upgrade.text = Data.CardsList[j].Upgrade.ToString()+ "-" + Data.CardsList[j].UpgradeStat.ToString();
                        Downgrade.text = Data.CardsList[j].Downgrade.ToString() + "-" +
                                         Data.CardsList[j].DowngradeStat.ToString();
                        SetCard = true;
                        break;
                    }
                }
                if(SetCard)
                    break;
            }
            else
            {
                RandomNum -= (int)GachaInfo.CardsInBanner[i].Probability;
            }
        }
    }
}
