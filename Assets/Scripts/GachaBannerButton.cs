using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaBannerButton : MonoBehaviour
{
    public GameObject BuyButton;
    public Gacha GachaInfo;
    public Transform RootUI;

    public void SelectBanner()
    {
        LoadBannerButtons BannerButtons = RootUI.gameObject.GetComponent<LoadBannerButtons>();
        BannerButtons.UpdateBannerInfo(GachaInfo);
        BuyButton.SetActive(true);
    }
}
