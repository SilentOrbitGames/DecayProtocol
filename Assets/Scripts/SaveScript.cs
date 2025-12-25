using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class SaveScript : MonoBehaviour
{
    public static bool inventoryOpen = false;
    public static int weaponID = 0;
    public static int itemID = 0;
    public static bool[] weaponsPickedUp = new bool[8];
    public static bool[] itemsPickedUp = new bool[13];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weaponsPickedUp[0] = true; // Knife is always picked up
        weaponsPickedUp[6] = true;
        weaponsPickedUp[7] = true;

        itemsPickedUp[0] = true; // Flashlight is always picked up
        itemsPickedUp[1] = true; // Nightvision is always picked up
        itemsPickedUp[2] = true;
        itemsPickedUp[3] = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(FirstPersonController.invenrtorySwitchedOn == true)
        {
            inventoryOpen = true;
        }
        if (FirstPersonController.invenrtorySwitchedOn == false)
        {
            inventoryOpen = false;
        }
    }
}
