using UnityEngine;

public class DoorType : MonoBehaviour
{
    public enum typeOfDoor
    {
        cabinet,
        houde,
        cabin
    }

    public typeOfDoor chooseDoor;
    public bool opened = false;
    public bool locked = false;
    [HideInInspector]
    public string message = "[E] Open";
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        if(opened == true)
        {
            anim.SetTrigger("Open");
            message = "[E] Close";
        }
    }
}
