using UnityEngine;

public class ItemType : MonoBehaviour
{
    public enum typeOfItem
    {
        flashlight,
        nightvision,
        lighter,
        rags,
        healthPack,
        pills,
        waterBottle,
        energyCan,
        batteryFL, //Flashlight Battery
        batteryNV, //Nightvision Battery
        houseKey,
        cabinKey,
        jerryCan
    }

    public typeOfItem chooseItem;
}
