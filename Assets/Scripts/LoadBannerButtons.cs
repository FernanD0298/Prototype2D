using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadBannerButtons : MonoBehaviour
{
    public GameObject Data;
    public GameObject BannerButton;
    public Transform ContentBox;
    public Transform ParentUI;
    public GameObject CardPanel;
    public GameObject BuyButton;
    public TextMeshProUGUI AmountOfCardsPerBanner;
    public TextMeshProUGUI CardPrice;
    private List<Gacha> GachaList;

    public int CurrentCardCost;
    

    private void OnEnable()
    {
        CharactersData CharactersData = Data.GetComponent<CharactersData>();
        GachaList = CharactersData.GachaInfo;
        
        CardPanel.SetActive(false);
        BuyButton.SetActive(false);
        AmountOfCardsPerBanner.gameObject.SetActive(false);
        CardPrice.gameObject.SetActive(false);
        
        SetupBannerButtons();
    }

    private void OnDisable()
    {
        foreach (Transform transform in ContentBox)
        {
            Destroy(transform.gameObject);
        }
    }

    void SetupBannerButtons()
    {
        for (int i = 0; i < GachaList.Count; i++)
        {
            GameObject Button = Instantiate(BannerButton, ContentBox, true);
            Button.GetComponentInChildren<TextMeshProUGUI>().text = "Banner" + GachaList[i].BannerID.ToString();
            GachaBannerButton NewBannerButton = Button.GetComponent<GachaBannerButton>();
            NewBannerButton.GachaInfo = GachaList[i];
            NewBannerButton.RootUI = ParentUI;
            NewBannerButton.BuyButton = BuyButton;
        }
    }

    public void UpdateBannerInfo(Gacha GachaInfo)
    {
        AmountOfCardsPerBanner.gameObject.SetActive(true);
        CardPrice.gameObject.SetActive(true);
        
        AmountOfCardsPerBanner.text = GachaInfo.CardsInBanner.Count.ToString();
        CardPrice.text = "$" + GachaInfo.Price.ToString();
        CurrentCardCost = GachaInfo.Price;
        CalculateRandomCard CalculateRandomCard = GetComponent<CalculateRandomCard>();
        CalculateRandomCard.GachaInfo = GachaInfo;
        CalculateRandomCard.Data = Data.GetComponent<CharactersData>();
    }

    public void Close()
    {
        ParentUI.gameObject.SetActive(false);
    }
}
