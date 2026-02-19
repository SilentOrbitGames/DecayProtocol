using UnityEngine;
using UnityEngine.UI;
public class SprayScript : MonoBehaviour
{
    [Header("Spray UI Settings")]
    [SerializeField] public Image sprayFill;

    public float sprayAmount = 1.0f;
    public float drainTime = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            sprayAmount -= drainTime * Time.deltaTime;
            sprayFill.fillAmount = sprayAmount;
        }
    }
}
