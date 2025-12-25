using System.Collections;
using System.Data;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public enum weaponSelect
    {
      knife,
      cleaver,
      bat,
      axe,
      pistol,
      shotgun,
      sprayCan,
      bottle,
      bottleWithCloth
    }

    [Header("Weapon's Settings")]
    [SerializeField] weaponSelect chosenWeapon;
    [SerializeField] GameObject[] weapons;
    [Header("Audio Settings")]
    [SerializeField] AudioClip[] weaponSounds;
    private int weaponID = 0;
    private Animator anim;
    private AudioSource audioPlayer;
    private int currentWeaponID;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SaveScript.weaponID = (int)chosenWeapon;
        anim = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
        ChangeWeapons();
    }

    // Update is called once per frame
    void Update()
    {
        if(SaveScript.weaponID != currentWeaponID)
        {
            ChangeWeapons();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(SaveScript.inventoryOpen == false)
            {
                anim.SetTrigger("Attack");
                audioPlayer.clip = weaponSounds[SaveScript.weaponID];
                audioPlayer.Play();
            } 
        }
    }

    private void ChangeWeapons()
    {
        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }
        weapons[SaveScript.weaponID].SetActive(true);
        chosenWeapon = (weaponSelect)SaveScript.weaponID;
        anim.SetInteger("WeaponID", SaveScript.weaponID);
        anim.SetBool("weaponChanged", true);
        currentWeaponID = SaveScript.weaponID;
        Move(); 
        StartCoroutine(WeaponReset());
    }

    private void Move()
    {
        switch (chosenWeapon)
        {
            case weaponSelect.knife:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
            case weaponSelect.cleaver:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
            case weaponSelect.bat:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
            case weaponSelect.axe:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
            case weaponSelect.pistol:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
            case weaponSelect.shotgun:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.46f);
                break;
            case weaponSelect.sprayCan:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
            case weaponSelect.bottle:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
        }
    }

    IEnumerator WeaponReset()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("weaponChanged", false);
    }
}
