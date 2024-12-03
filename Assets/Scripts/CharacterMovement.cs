using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed;
    public Transform Transform;
    public static CharacterMovement instance;

    public int HP;
    
    // Start is called before the first frame update
    void Start()
    {
        HP = 10;
        instance = this;    
        Transform = gameObject.transform; 
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMove();
       
    }

    private void CharacterMove()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 movementV = transform.forward * vertical * Time.deltaTime * moveSpeed;
        Vector3 movementH = transform.right * horizontal * Time.deltaTime * moveSpeed;
        transform.position += movementV + movementH;

    }

    
}
