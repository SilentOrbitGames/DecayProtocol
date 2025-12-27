using UnityEngine;
using UnityEngine.UI;

public class WeaponInventory : MonoBehaviour
{
    [Header("Weapon Icons")]
    [SerializeField] Sprite[] bigIcons;
    [SerializeField] Image bigIcon;

    [Header("Weapon Info")]
    [SerializeField] string[] titles;
    [SerializeField] Text title;
    [SerializeField] string[] descriptions;
    [SerializeField] Text description;
    [SerializeField] Text amtsText;

    [Header("Audio")]
    [SerializeField] AudioClip click, select;

    [Header("Weapon Buttons")]
    [SerializeField] Button[] weaponButtons;

    [Header("Action Buttons")]
    [SerializeField] GameObject useButton, combineButton;
    [SerializeField] GameObject combinePanel, combineUseButton;
    [SerializeField] Image[] combineItems;

    private AudioSource audioPlayer;
    private int chosenWeaponNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();

        bigIcon.sprite = bigIcons[0];
        title.text = titles[0];
        description.text = descriptions[0];

        combinePanel.SetActive(false);
        combineUseButton.SetActive(false);
    }

    public void OnEnable()
    {
        for (int i = 0; i < weaponButtons.Length; i++)
        {
            if(SaveScript.weaponsPickedUp[i] == false)
            {
                weaponButtons[i].image.color = new Color(1, 1, 1, 0.06f);
                weaponButtons[i].image.raycastTarget = false;
            }
            if (SaveScript.weaponsPickedUp[i] == true)
            {
                weaponButtons[i].image.color = new Color(1, 1, 1, 1);
                weaponButtons[i].image.raycastTarget = true;
            }
        }

        if(chosenWeaponNumber < 6)
        {
            combinePanel.SetActive(false);
            combineButton.SetActive(false);
        }

        if (SaveScript.itemsPickedUp[2] == true)
        {
            combineItems[0].color = new Color(1, 1, 1, 1);
        }
        if (SaveScript.itemsPickedUp[2] == false)
        {
            combineItems[0].color = new Color(1, 1, 1, 0.06f);
        }
        if (SaveScript.itemsPickedUp[3] == true)
        {
            combineItems[1].color = new Color(1, 1, 1, 1);
        }
        if (SaveScript.itemsPickedUp[3] == false)
        {
            combineItems[1].color = new Color(1, 1, 1, 0.06f);
        }
    }

    public void ChooseWeapon(int weaponNumber)
    {
        bigIcon.sprite = bigIcons[weaponNumber];
        title.text = titles[weaponNumber];
        description.text = descriptions[weaponNumber];
        audioPlayer.clip = click;
        audioPlayer.Play();
        chosenWeaponNumber = weaponNumber;
        amtsText.text = "Amts: " + SaveScript.weaponAmts[weaponNumber];

        if (chosenWeaponNumber > 5)
        {
            combineButton.SetActive(true);
            combinePanel.SetActive(false);
        }
        if (chosenWeaponNumber < 6)
        {
            combinePanel.SetActive(false);
            combineButton.SetActive(false);
        }
    }

    public void CombineAction()
    {
        combinePanel.SetActive(true);

        if(chosenWeaponNumber == 6)
        {
            combineItems[1].transform.gameObject.SetActive(false);
            if (SaveScript.itemsPickedUp[2] == true)
            {
                combineUseButton.SetActive(true);
            }
            if (SaveScript.itemsPickedUp[2] == false)
            {
                combineUseButton.SetActive(false);
            }
        }
        if (chosenWeaponNumber == 7)
        {
            combineItems[1].transform.gameObject.SetActive(true);
            if (SaveScript.itemsPickedUp[2] == true && SaveScript.itemsPickedUp[3] == true)
            {
                combineUseButton.SetActive(true);
            }
            if (SaveScript.itemsPickedUp[2] == false || SaveScript.itemsPickedUp[3] == false)
            {
                combineUseButton.SetActive(false);
            }
        }
    }

    public void CombineAssignWeapon()
    {
        if(chosenWeaponNumber == 6)
        {
            SaveScript.weaponID = chosenWeaponNumber; //Spray Can
        }
        if (chosenWeaponNumber == 7)
        {
            SaveScript.weaponID = chosenWeaponNumber += 1; // Bottle with Cloth
        }
        audioPlayer.clip = select;
        audioPlayer.Play();
    }

    public void AssignWeapon()
    {
        SaveScript.weaponID = chosenWeaponNumber;
        audioPlayer.clip = select;
        audioPlayer.Play();
    }
}
