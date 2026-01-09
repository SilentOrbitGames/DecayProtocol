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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
