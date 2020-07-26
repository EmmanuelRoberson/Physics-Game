using UnityEngine;
using UnityEngine.InputSystem;

public class MovementBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void Movement()
    {
        Vector3 movement = new Vector3();
        
        if (Keyboard.current.wKey.isPressed) {movement.z +=1;}
        if (Keyboard.current.sKey.isPressed) {movement.z -=1;}
        if (Keyboard.current.wKey.isPressed) {movement.z +=1;}
        if (Keyboard.current.wKey.isPressed) {movement.z +=1;}
    }
    
}
