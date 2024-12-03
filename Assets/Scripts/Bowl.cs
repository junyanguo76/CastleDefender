using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Bowl : MonoBehaviour
{
    public static Bowl Instance;
    public Transform CreatingPosition;
    Animator animator;
    public int timer;

    public GameObject prefab;
    public GameObject ArrowModel;


    public Transform headPoint;
    public Transform tailPoint;
    public Transform lanuchPoint;

    public float force;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void ShootingByClick()
    {
        Shooting();
        animator.SetBool("shoot",true);
        StartCoroutine(Reload());
    }

    private void Shooting()
    {
        GameObject arrow = Instantiate(prefab);
        arrow.transform.position = prefab.transform.position;
        arrow.transform.position += new Vector3(0, 0.182f - 0.126f, 0); 
        arrow.transform.rotation = prefab.transform.rotation;
        arrow.GetComponent<Arrow>().ArrowDestroy();
        arrow.GetComponent<Arrow>().arrowType = 1;
        arrow.GetComponent<Arrow>().rigidbody.useGravity = true;
        arrow.GetComponent <TrailRenderer>().enabled = true;
        //arrow.GetComponent<Rigidbody>().useGravity = true;
        arrow.GetComponent<Rigidbody>().AddForce((headPoint.position - tailPoint.position) * force);
        ArrowModel.SetActive(false);
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("shoot", false);
        ArrowModel.SetActive(true);
    }


}
