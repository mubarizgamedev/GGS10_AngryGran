using System;
using UnityEngine;
using UnityEngine.UI;

public class PetSelectionMainMenu : MonoBehaviour
{
    public static PetSelectionMainMenu Instance { get; private set; }
    
    
    public Transform catSpawnPoint;
    public GameObject[] catPrefabs;
    public GameObject selectButton;
    public GameObject unlockButton;
    public GameObject unlockAllCats;
    public GameObject rewardCoinsButton;
    public GameObject showAdAndSelectFree;

    public bool secondCatFree;
    public bool thirdCatFree;

    [Space(5)]
    public GameObject pet1Button, pet2Button;

    [Space(5)]
    [Header("BUTTONS")]
    public Button btnSelectAfterAd;
    public Button btnUnlockAfterAd;

    [Space(5)]
    [Header("PANELS")]
    public GameObject notEnoughCoinsPanel;
    public GameObject unlockAllinapp;
    public GameObject gameplayLoadingScreen;


    [Space(5)]
    [Header("BUTTONS")]
    public GameObject reqCoinsGameobject;
    public Text reqCoinsText;

    [Space(5)]
    [Header("REQ COMPONENTS")]
    public ModesAd modesAdHandler;

    private int currentIndex = 0;
    private GameObject currentCatInstance;
    private int[] petPrices = { 0, 1, 2};
    void Start()
    {
        currentIndex = PlayerPrefs.GetInt("SelectedCatIndex", 0); // Load saved index
        int noAds = PlayerPrefs.GetInt("noADS");
        if (noAds == 1)
        {
            unlockAllinapp.SetActive(false);
        }
    }
    private void Awake()
    {
        CheckForInApp();
    }

    private void OnEnable()
    {
        PlayerPrefs.SetInt("SelectedCatIndex", 0);
        currentIndex = PlayerPrefs.GetInt("SelectedCatIndex", 0);
        SpawnPet();
        currentIndex = 0;
    }

    public void MoveToPetAtIndex(int petIndex)
    {
        currentIndex = petIndex;
        SpawnPet();
    }

    public void MoveLeft()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = catPrefabs.Length - 1; // Loop to last cat
        }
        SpawnPet();
    }

    public void MoveRight()
    {
        currentIndex++;
        if (currentIndex >= catPrefabs.Length)
        {
            currentIndex = 0; // Loop to first cat
        }
        SpawnPet();
    }

    public void SelectPet()
    {
        if (IsPetUnlocked(currentIndex))
        {
            PlayerPrefs.SetInt("SelectedCatIndex", currentIndex);
            PlayerPrefs.Save();
            Debug.Log("Cat " + currentIndex + " selected!");
            Destroy(currentCatInstance);
            //NextPanel();
        }
        else
        {
            Debug.Log("This cat is locked! Unlock it first.");
        }
    }

    void UnlockAfterAd()
    {
        Sfx_Mainmenu.PlaySound(Sfx_Mainmenu.Instance.sellPurchase);
        PlayerPrefs.SetInt("CatUnlocked_" + currentIndex, 1);
        PlayerPrefs.Save();
        Debug.Log("Cat " + currentIndex + " unlocked!");
        UpdateButtons();
        NextPanel();
    }

    public void SpawnPet()
    {
        if (currentCatInstance != null)
        {
            Destroy(currentCatInstance);
        }
        if (Sfx_Mainmenu.Instance)
            Sfx_Mainmenu.PlaySound(Sfx_Mainmenu.Instance.petSelect, 1);
        currentCatInstance = Instantiate(catPrefabs[currentIndex], catSpawnPoint.position, Quaternion.identity);
        currentCatInstance.transform.rotation = Quaternion.Euler(0, 225, 0);
        UpdateButtons();
    }

    void UpdateButtons()
    {
        if (IsPetUnlocked(currentIndex))
        {
            showAdAndSelectFree.SetActive(true);
            selectButton.SetActive(true);
            unlockButton.SetActive(false);
            unlockAllCats.SetActive(false);
            rewardCoinsButton.SetActive(false);
            reqCoinsGameobject.SetActive(false);
        }
        else
        {
            showAdAndSelectFree.SetActive(false);
            selectButton.SetActive(false);
            unlockButton.SetActive(true);
            unlockAllCats.SetActive(true);
            rewardCoinsButton.SetActive(true);
            reqCoinsGameobject.SetActive(true);
        }
        UpdateReqCoinsText(petPrices[currentIndex]);
        ShowButtonsIfPetLocked();
    }

    bool IsPetUnlocked(int index)
    {
        if (index == 0) return true;
        return PlayerPrefs.GetInt("CatUnlocked_" + index, 0) == 1;
    }
    public void DestroyCurrentPet()
    {
        Destroy(currentCatInstance);
    }

    public void UnlockAllPets()
    {
        for (int i = 0; i < catPrefabs.Length; i++)
        {
            PlayerPrefs.SetInt("CatUnlocked_" + i, 1);
        }
        PlayerPrefs.Save();
        Debug.Log("All pets unlocked!");
        UpdateButtons();
    }

    public void BuyNow()
    {
        int playerCoins = PlayerPrefs.GetInt("MyCoins", 0);
        int petPrice = petPrices[currentIndex];

        if (IsPetUnlocked(currentIndex))
        {
            Debug.Log("Pet already unlocked!");
            return;
        }

        if (playerCoins >= petPrice)
        {
            playerCoins -= petPrice;
            PlayerPrefs.SetInt("MyCoins", playerCoins);
            PlayerPrefs.SetInt("CatUnlocked_" + currentIndex, 1);
            PlayerPrefs.Save();
            UpdateButtons();
            Sfx_Mainmenu.PlaySound(Sfx_Mainmenu.Instance.sellPurchase);
            modesAdHandler.DeductCoins(petPrices[currentIndex]);
        }
        else
        {

            notEnoughCoinsPanel.SetActive(true);
            DestroyCurrentPet();
        }
    }

    void UpdateReqCoinsText(int coins)
    {
        reqCoinsText.text = coins.ToString() + "$";
    }

    void CheckForInApp()
    {
        if (PlayerPrefs.GetInt("noADS") == 1)
        {
            UnlockAllPets();
        }
    }
    

    void NextPanel()
    {
        gameObject.SetActive(false);
        DestroyCurrentPet();
        gameplayLoadingScreen.SetActive(true);
    }

    public void UnlockPetAtIndex(int index)
    {
        if (index < 0 || index >= catPrefabs.Length)
        {
            Debug.LogWarning("Invalid pet index: " + index);
            return;
        }

        PlayerPrefs.SetInt("CatUnlocked_" + index, 1);
        PlayerPrefs.Save();

        Debug.Log("Pet at index " + index + " unlocked!");

        // If the current index is the same as the unlocked index, update buttons
        if (currentIndex == index)
        {
            UpdateButtons();
        }
    }


    public void ShowButtonsIfPetLocked()
    {
        if (currentIndex == 1)
        {
            if (secondCatFree)
            {
                selectButton.SetActive(true);
            }
            else
            {
                // Check if pet at index 1 is locked
                if (!IsPetUnlocked(1))
                {
                    pet1Button.SetActive(true);
                    pet2Button.SetActive(false);
                }
                else
                {
                    pet1Button.SetActive(false);
                }
            }
        }
        else if (currentIndex == 2)
        {
            if (thirdCatFree)
            {
                selectButton.SetActive(true);
            }
            else
            {
                // Check if pet at index 2 is locked
                if (!IsPetUnlocked(2))
                {
                    pet2Button.SetActive(true);
                    pet1Button.SetActive(false);
                }
                else
                {
                    pet2Button.SetActive(false);
                }
            } 
        }
        else
        {
            pet1Button.SetActive(false);
            pet2Button.SetActive(false);
        }
    }

    public void ShowAdAndSelectPet()
    {
        Rewad_.Instance.StartLoading(SelectPet);
    }

    public void ShowAdAndUnlockPet()
    {
        Rewad_.Instance.StartLoading(UnlockAfterAd);
    }

}