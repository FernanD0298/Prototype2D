using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetupCardInfo : MonoBehaviour
{
    public Cards CardInfo;
    public RawImage Image;
    public TextMeshProUGUI Upgrade;
    public TextMeshProUGUI Downgrade;
    
    void Start()
    {
        Image.texture = CardInfo.Image;
        Upgrade.text = CardInfo.Upgrade.ToString() + "-"+ CardInfo.UpgradeStat.ToString();
        Downgrade.text = CardInfo.Downgrade.ToString() + "-" + CardInfo.DowngradeStat.ToString();
    }
    
}
