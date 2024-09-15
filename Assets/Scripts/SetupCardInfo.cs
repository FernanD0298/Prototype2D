using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SetupCardInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Cards CardInfo;
    public RawImage Image;
    public TextMeshProUGUI Upgrade;
    public TextMeshProUGUI Downgrade;
    public TextMeshProUGUI Level;

    public TextMeshProUGUI DamagePreview;
    public TextMeshProUGUI SpeedPreview;
    public TextMeshProUGUI LifePreview;
    
    void Start()
    {
        Image.texture = CardInfo.Image;
        Upgrade.text = CardInfo.Upgrade.ToString() + "-"+ CardInfo.UpgradeStat.ToString();
        Downgrade.text = CardInfo.Downgrade.ToString() + "-" + CardInfo.DowngradeStat.ToString();
        Level.text = "L-" + CardInfo.CardLevel.ToString();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (CardInfo.UpgradeStat)
        {
            case CharacterStat.Damage:
                DamagePreview.gameObject.SetActive(true);
                DamagePreview.text = "+  " + CardInfo.Upgrade.ToString();
                DamagePreview.color = Color.green;
                break;
            case CharacterStat.Life:
                LifePreview.gameObject.SetActive(true);
                LifePreview.text = "+  " + CardInfo.Upgrade.ToString();
                LifePreview.color = Color.green;
                break;
            case CharacterStat.Speed:
                SpeedPreview.gameObject.SetActive(true);
                SpeedPreview.text = "+  " + CardInfo.Upgrade.ToString();
                SpeedPreview.color = Color.green;
                break;
        }

        switch (CardInfo.DowngradeStat)
        {
            case CharacterStat.Damage:
                DamagePreview.gameObject.SetActive(true);
                DamagePreview.text = "+  " + CardInfo.Downgrade.ToString();
                DamagePreview.color = Color.red;
                break;
            case CharacterStat.Life:
                LifePreview.gameObject.SetActive(true);
                LifePreview.text = "+  " + CardInfo.Downgrade.ToString();
                LifePreview.color = Color.red;
                break;
            case CharacterStat.Speed:
                SpeedPreview.gameObject.SetActive(true);
                SpeedPreview.text = "+  " + CardInfo.Downgrade.ToString();
                SpeedPreview.color = Color.red;
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DamagePreview.gameObject.SetActive(false);
        LifePreview.gameObject.SetActive(false);
        SpeedPreview.gameObject.SetActive(false);
    }
}
