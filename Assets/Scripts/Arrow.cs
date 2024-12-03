using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int arrowType = 0;
    public Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(arrowType == 1)
        //{
        //    Vector2 v = rigidbody.velocity;
        //    float angle = Mathf.Atan2(v.x, v.y);
        //    transform.rotation = Quaternion.AngleAxis(angle, Vector3.right);
        //}
    }
    public void ArrowDestroy()
    {
        Destroy(gameObject, 10);
    }
    
    

}
