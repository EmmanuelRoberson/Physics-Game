
using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class HealthComponentDebugger : MonoBehaviour
{
    public HealthComponent hp;

    public int HealthMax = 100;

    public Slider slider;

    public Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        hp = new HealthComponent(100);
    }

    // Update is called once per frame
    void Update()
    {
        slider.transform.LookAt(mainCam.transform);
    }

    public void DecreaseHealth()
    {
        hp.AlterHealth(-10);

        slider.value = hp.HealthValue / HealthMax;
    }

    private void OnTriggerEnter(Collider other)
    {
        TaskSourceBehaviourDebugger tsb = other.GetComponent<TaskSourceBehaviourDebugger>();

        if (tsb != null)
        {
            DecreaseHealth();
        }
    }
    
}
