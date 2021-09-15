using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class UpgradeScript : MonoBehaviour
{

    public float stickyCount;
    public int addSticky = 1;
    public Text stickyCountText;

    // Start is called before the first frame update

    public void StickypadButton()
    {
        print(stickyCount);
        
        if (glueDouble == 1)
        {
            stickyCount += addSticky + 1;
            glueDouble = 0;
        }
        else
        {
            stickyCount += addSticky;
        }
       
        PlayerPrefs.SetFloat("stickyCount", stickyCount);
        PlayerPrefs.Save();
    }    

    void UpdateText()
    {
        if (stickyCount != 1)
        {
            stickyCountText.text = Mathf.Round(stickyCount) + " stickys";   
        }
        else
        {
            stickyCountText.text = stickyCount + " sticky";
        }
    }

    public void ResetSticky()
    {
        PlayerPrefs.SetFloat("stickyCount", 0);
        PlayerPrefs.SetInt("addSticky", 1);
        PlayerPrefs.SetInt("autoFlipCount", 0);
        PlayerPrefs.Save();
        stickyCount = 0;
        addSticky = 1;
        PlayerPrefs.SetInt("isDoubleFlipBought", 0);
        PlayerPrefs.SetInt("isTripleFlipBought", 0);
        PlayerPrefs.SetInt("gotLessGlue", 0);
        PlayerPrefs.SetInt("gotMagicNotebook", 0);
        isDoubleFlipBought = 0;
        isTripleFlipBought = 0;
        autoFlipCount = 0;
        autoFlipCost = 15;
        PlayerPrefs.SetFloat("autoFlipCost", autoFlipCost);
        moreNoteCost = 150;
        PlayerPrefs.SetFloat("moreNoteCost", moreNoteCost);
        gotLessGlue = 0;
        gotMagicNotebook = 0;
        friendCount = 0;
        PlayerPrefs.SetInt("friendCount", 0);
        friendCost = 200;
        PlayerPrefs.SetFloat("friendCost", friendCost);
        roboCount = 0;
        PlayerPrefs.SetInt("roboCount", 0);
        roboCost = 800;
        PlayerPrefs.SetFloat("roboCost", roboCost);
        stonkPurchased = 0;
        PlayerPrefs.SetInt("stonkPurchased", 0);
        Buy.SetActive(false);
        Sell.SetActive(false);
        PlayerPrefs.SetInt("coinAmount", 0);
        coinAmount = 0;
        PlayerPrefs.SetFloat("coinCost", coinCost = 100);

        stickyCountText.text = stickyCount + " stickys";
        confirm.SetActive(false);
    }
}
