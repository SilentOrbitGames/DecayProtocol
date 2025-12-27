using UnityEngine;

public class WeaponType : MonoBehaviour
{
    public enum typeOfWeapon
    {
        knife,
        cleaver,
        bat,
        axe,
        pistol,
        shotgun,
        sprayCan,
        bottle
    }

    public typeOfWeapon chooseWeapon;
}
