using UnityEngine;
using UnityEngine.UI;

public class ItemsInventory : MonoBehaviour
{
    [Header("Item Icons")]
    [SerializeField] Sprite[] bigIcons;
    [SerializeField] Image bigIcon;
    [Header("Item Info")]
    [SerializeField] string[] titles;
    [SerializeField] Text title;
    [SerializeField] string[] descriptions;
    [SerializeField] Text description;
    [SerializeField] Text amtsText;
    [Header("Audio")]
    [SerializeField] AudioClip click, select;
    [Header("Item Buttons")]
    [SerializeField] Button[] itemButtons;
    [SerializeField] GameObject useButton;

    private AudioSource audioPlayer;
    private int chosenItemNunmber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();

        bigIcon.sprite = bigIcons[0];
        title.text = titles[0];
        description.text = descriptions[0];
        useButton.SetActive(false);
    }
    
    public void OnEnable()
    {
        for (int i = 0; i < itemButtons.Length; i++)
        {
            if(SaveScript.itemsPickedUp[i] == false)
            {
                itemButtons[i].image.color = new Color(1, 1, 1, 0.06f);
                itemButtons[i].image.raycastTarget = false;
            }
            if (SaveScript.itemsPickedUp[i] == true)
            {
                itemButtons[i].image.color = new Color(1, 1, 1, 1);
                itemButtons[i].image.raycastTarget = true;
            }
        }
    }

    public void ChooseItem(int itemNumber)
    {
        bigIcon.sprite = bigIcons[itemNumber];
        title.text = titles[itemNumber];
        description.text = descriptions[itemNumber];
        audioPlayer.clip = click;
        audioPlayer.Play();
        chosenItemNunmber = itemNumber;
        amtsText.text = "Amts: " + SaveScript.itemAmts[itemNumber];

        if (itemNumber < 4)
        {
            useButton.SetActive(false);
        }
        else
        {
            useButton.SetActive(true);
        }
    }

    public void AssignItem()
    {
        SaveScript.itemID = chosenItemNunmber;
        audioPlayer.clip = select;
        audioPlayer.Play();
    }
}
