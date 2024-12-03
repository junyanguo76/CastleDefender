using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class Monsters : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigidbody;
    public Transform playerTransform;
    public NavMeshAgent agent;
    public int HP;
    public float timer;
    public float shootTime;
    int temp = 0;
    public float distance;
    void Start()
    {
        rigidbody = gameObject.GetComponentInParent<Rigidbody>();
        HP = 4;
        shootTime = 5;
        StartCoroutine(WaitABit());

    }

    IEnumerator WaitABit()
    {
        yield return new WaitForSeconds(1);
        temp = 1;
    }
    // Update is called once per frame
    void Update()
    {
        playerTransform.position = CharacterMovement.instance.Transform.position;
        agent.SetDestination(playerTransform.position);
        Attack();
    }

    private void Attack()
    {
        distance = Vector3.Distance(this.transform.position, playerTransform.position);
        if (Vector3.Distance(this.transform.position, playerTransform.position) < 21 && Time.time > timer && temp != 0)
        {
            StartCoroutine(AttackAnim());
            CharacterMovement.instance.HP -= 1;
            UnityEngine.Debug.Log(CharacterMovement.instance.HP);
            timer = Time.time + shootTime;
            temp++;
            UIManager.instance.ShowGoal();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        Arrow arrow = other.gameObject.GetComponent<Arrow>();
        if (arrow != null)
        {
            UIManager.instance.goal += 1;
            UIManager.instance.ShowGoal();
            HP -= 1;
            if (HP == 0)
            {
                StartCoroutine(Die());

            }
        }
    }
    IEnumerator AttackAnim()
    {
        gameObject.GetComponent<Animator>().SetBool("Attack", true);
        yield return new WaitForSeconds(3f);
        gameObject.GetComponent<Animator>().SetBool("Attack", false);
    }
    IEnumerator Die()
    {
        gameObject.GetComponent<Animator>().SetBool("Die",true);
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

}
