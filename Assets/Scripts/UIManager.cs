using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI goalText;
    public int goal;
    public static UIManager instance;
    public float monsterTime;
    public float hideTimer;

    public TextMeshProUGUI Failed;
    public TextMeshProUGUI Win;

    public GameObject monsterPrefab;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        monsterTime = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > hideTimer)
        {
            Instantiate(monsterPrefab,new Vector3(Random.Range(-12,50),Random.Range(12,15),Random.Range(50,75)),Quaternion.identity);
            hideTimer = Time.time + monsterTime;
        }
        WiningJudge();

    }

    private void WiningJudge()
    {
        if(CharacterMovement.instance.HP <= 0)
        {
            Failed.gameObject.SetActive(true);
        }
        if(goal >= 20)
        {
            Win.gameObject.SetActive(true);
        }
    }
    public void ShowGoal()
    {
        goalText.text = "Goal: " + goal + "\n" +"HP: " + CharacterMovement.instance.HP;
    }
}
