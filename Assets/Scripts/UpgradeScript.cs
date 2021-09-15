using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class UpgradeScript : MonoBehaviour
{
    public GameObject confirm;

    public int isDoubleFlipBought = 0;
    public int doubleFlipCost = 1000;
    public Text doubleCostText;

    public int isTripleFlipBought = 0;
    public int tripleFlipCost = 5000;
    public Text tripleCostText;

    public int autoFlipCount = 0;
    public float autoFlipCost = 15;
    public float autoCostCoef = 1.11f;
    public Text flipCostText;

    public int gotLessGlue = 0;
    public int glueCost = 50;
    public Text glueCostText;
    public int glueDouble;

    public int gotMagicNotebook = 0;
    public int notebookCost = 10000;
    public Text notebookText;

    public float moreNoteCost = 150;
    public float noteCostCoef = 1.10f;
    public Text noteCostText;

    public int friendCount = 0;
    public float friendCost = 200;
    public float friendCostCoef = 1.12f;
    public Text friendCostText;

    public int roboCount = 0;
    public float roboCost = 800;
    public float roboCostCoef = 1.13f;
    public Text roboCostText;

    public int stonkPurchased = 0;
    public int stonkPrice = 200;
    public Text stonkPriceText;
    public float coinCost = 100;
    public int coinAmount = 0;
    public GameObject Buy;
    public Text rate;
    public GameObject Sell;
    public Text balance;
    public float timer = 0;

    private void Update()
    {
        UpdateText();
        stickyCount += (autoFlipCount * Time.deltaTime) / 2;
        stickyCount += (friendCount * Time.deltaTime) * 3;
        stickyCount += (roboCount * Time.deltaTime) * 10;

        timer += Time.deltaTime;

        if (timer >= 0.5)
        {
            if (stonkPurchased == 1)
            {
                coinCost += Random.Range(-2, 3);
                PlayerPrefs.SetFloat("coinCost", coinCost);
                if (coinCost <= 1)
                {
                    coinCost = 1;
                }
                rate.text = coinCost + " stickys / $tickydollar";
            }

            PlayerPrefs.SetFloat("stickyCount", stickyCount);
            timer = 0;

        }

        if (isDoubleFlipBought == 0)
        {
            doubleCostText.text = "Double flip: " + doubleFlipCost + " stickys";
        }
        else
        {
            doubleCostText.text = "Double flip bought!";
        }
        if (isTripleFlipBought == 0)
        {
            tripleCostText.text = "Triple flip: " + tripleFlipCost + " stickys";
        }
        else
        {
            tripleCostText.text = "Triple flip bought!";
        }
        if (gotLessGlue == 0)
        {
            glueCostText.text = "Less glue: " + glueCost + " stickys";
        }
        else
        {
            glueCostText.text = "Got less glue!";
        }
        if (gotMagicNotebook == 0)
        {
            notebookText.text = "Magic notepad: " + notebookCost + " stickys";
        }
        else
        {
            notebookText.text = "Magic notepad bought!";
        }

        if (stonkPurchased == 0)
        {
            stonkPriceText.text = "Stonks: " + stonkPrice + " stickys";
        }
        else
        {
            stonkPriceText.text = "Stonks bought!";
        }

        flipCostText.text = "Auto flipper: " + Mathf.Round(autoFlipCost) + " stickys";
        noteCostText.text = "More notes: " + Mathf.Round(moreNoteCost) + " stickys";
        friendCostText.text = "Bored colleague: " + Mathf.Round(friendCost) + " stickys";
        roboCostText.text = "Robo flipper: " + Mathf.Round(roboCost) + " stickys";
    }
    private void Start()
    {
        stickyCount = PlayerPrefs.GetFloat("stickyCount", 0);
        addSticky = PlayerPrefs.GetInt("addSticky", 1);
        UpdateText();

        autoFlipCount = PlayerPrefs.GetInt("autoFlipCount", 0);
        autoFlipCost = PlayerPrefs.GetFloat("autoFlipCost", autoFlipCost);

        moreNoteCost = PlayerPrefs.GetFloat("moreNoteCost", moreNoteCost);

        friendCount = PlayerPrefs.GetInt("friendCount", 0);
        friendCost = PlayerPrefs.GetFloat("friendCost", friendCost);

        stonkPurchased = PlayerPrefs.GetInt("stonkPurchased", 0);
        Buy.SetActive(stonkPurchased == 1);
        Sell.SetActive(stonkPurchased == 1);
        coinCost = PlayerPrefs.GetFloat("coinCost", 100);


        isDoubleFlipBought = PlayerPrefs.GetInt("isDoubleFlipBought", 0);
        isTripleFlipBought = PlayerPrefs.GetInt("isTripleFlipBought", 0);
        gotLessGlue = PlayerPrefs.GetInt("gotLessGlue", 0);
        gotMagicNotebook = PlayerPrefs.GetInt("gotMagicNotebook", 0);
        StartCoroutine("GlueChance");   
    }


    public void DoubleFlip()
    {
        if (isDoubleFlipBought == 0 && stickyCount >= doubleFlipCost)
        {
            addSticky = addSticky * 2;
            isDoubleFlipBought = 1;
            stickyCount -= doubleFlipCost;
            doubleCostText.text = "Double flip bought!";
            PlayerPrefs.SetInt("addSticky", addSticky);
            PlayerPrefs.SetInt("isDoubleFlipBought", isDoubleFlipBought);
        }

    }
    public void TripleFlip()
    {
        if (isTripleFlipBought == 0 && stickyCount >= tripleFlipCost)
        {
            addSticky = addSticky * 3;
            isTripleFlipBought = 1;
            stickyCount -= tripleFlipCost;
            tripleCostText.text = "Triple flip bought!";
            PlayerPrefs.SetInt("addSticky", addSticky);
            PlayerPrefs.SetInt("isTripleFlipBought", isTripleFlipBought);
        }
    }
    public void AutoFlip()
    {
        if (stickyCount >= autoFlipCost)
        {
            autoFlipCount += 1;
            stickyCount -= autoFlipCost;
            autoFlipCost *= autoCostCoef;
            flipCostText.text = "Auto flipper: " + (int)Mathf.Round(autoFlipCost) + " stickys";
            PlayerPrefs.SetFloat("autoFlipCost", autoFlipCost);
            PlayerPrefs.SetInt("autoFlipCount", autoFlipCount);
            addSticky += gotMagicNotebook;
        }
    }
    public void LessGlue()
    {
        if (gotLessGlue == 0 && stickyCount >= glueCost)
        {
            gotLessGlue = 1;
            glueCostText.text = "Got less glue!";
            stickyCount -= glueCost;
            PlayerPrefs.SetInt("gotLessGlue", gotLessGlue);

        }
    }
    private IEnumerator GlueChance()
    {
        while (gotLessGlue == 1)
        {
            if (Random.Range(0, 2) == 1)
            {
                glueDouble = 1;
            }
            yield return new WaitForSeconds(2);
        }
    }
    public void MagicNotepad()
    {
        if (autoFlipCount > 0)
        {
            if (gotMagicNotebook == 0 && stickyCount >= notebookCost)
            {
                gotMagicNotebook = 1;
                notebookText.text = "Got magic notepad!";
                stickyCount -= notebookCost;
                PlayerPrefs.SetInt("gotMagicNotebook", gotMagicNotebook);
                addSticky += autoFlipCount;
            }
        }

    }
    public void MoreNotes()
    {
        if (stickyCount >= moreNoteCost)
        {
            addSticky += 1;
            stickyCount -= moreNoteCost;
            moreNoteCost *= noteCostCoef;
            flipCostText.text = "More notes: " + Mathf.Round(moreNoteCost) + " stickys";
            PlayerPrefs.SetFloat("moreNoteCost", moreNoteCost);
        }
    }
    public void Friend()
    {
        if (stickyCount >= friendCost)
        {
            friendCount += 1;
            stickyCount -= friendCost;
            friendCost *= friendCostCoef;
            flipCostText.text = "Bored colleague: " + Mathf.Round(friendCost) + " stickys";
            PlayerPrefs.SetFloat("friendCost", friendCost);
            PlayerPrefs.SetInt("friendCount", friendCount);
        }
    }
    public void Stonks()
    {
        if (stonkPurchased == 0 && stickyCount >= stonkPrice)
        {
            stonkPurchased = 1;
            stickyCount -= stonkPrice;
            PlayerPrefs.SetInt("stonkPurchased", stonkPurchased);
            Buy.SetActive(true);
            Sell.SetActive(true);
        }
    }
    public void BuyCoin()
    {
        if (stickyCount >= coinCost)
        {
            coinAmount += 1;
            stickyCount -= coinCost;
            balance.text = coinAmount  + ((coinAmount == 1) ? " $tickydollar": " $tickydollars");
            PlayerPrefs.SetInt("coinAmount", coinAmount);
        }
    }
    public void SellCoin()
    {
        if (coinAmount > 0)
        {
            coinAmount -= 1;
            stickyCount += coinCost;
            balance.text = coinAmount + ((coinAmount == 1) ? " $tickydollar" : " $tickydollars");
            PlayerPrefs.SetInt("coinAmount", coinAmount);
        }
    }

    public void RoboFlip()
    {
        if (stickyCount >= roboCost)
        {
            roboCount += 1;
            stickyCount -= roboCost;
            roboCost *= roboCostCoef;
            roboCostText.text = "Robo clicker: " + Mathf.Round(roboCost) + " stickys";
            PlayerPrefs.SetFloat("friendCost", roboCost);
            PlayerPrefs.SetInt("roboCount", roboCount);
        }
    }
    public void ConfirmScreen()
    {
        confirm.SetActive(true);
    }
    public void CloseConfirm()
    {
        confirm.SetActive(false);
    }    
}
