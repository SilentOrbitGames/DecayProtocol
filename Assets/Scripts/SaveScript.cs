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
    public static int[] weaponAmts = new int[8];
    public static int[] itemAmts = new int[13];
    public static int[] ammoAmts = new int[2];
    public static bool change = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weaponsPickedUp[0] = true; // Knife is always picked up

        itemsPickedUp[0] = true; // Flashlight is always picked up
        itemsPickedUp[1] = true; // Nightvision is always picked up
        itemAmts[0] = 1; // Flashlight amt
        itemAmts[1] = 1; // Nightvision amt

        ammoAmts[0] = 12; // Pistol Default Ammo Amt
        ammoAmts[1] = 2; // Shotgun Default Ammo Amt
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

        if (change == true)
        {
            change = false;
            for(int i = 1; i < weaponAmts.Length; i++)
            {
                if (weaponAmts[i] > 0)
                {
                    weaponsPickedUp[i] = true;
                }
                else if (weaponAmts[i] == 0)
                {
                    weaponsPickedUp[i] = false;
                }
            }

            for (int i = 2; i < itemAmts.Length; i++)
            {
                if (itemAmts[i] > 0)
                {
                    itemsPickedUp[i] = true;
                }
                else if (itemAmts[i] == 0)
                {
                   itemsPickedUp[i] = false;
                }
            }
        }
    }
}
