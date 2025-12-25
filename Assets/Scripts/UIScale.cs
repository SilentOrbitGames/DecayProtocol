using UnityEngine;

public class UIScale : MonoBehaviour
{
    private float scaleValue = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(Screen.width > 1920)
        {
            scaleValue = 2;
        }
        this.transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
    }
}
