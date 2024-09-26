using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;


// 여러가지 파워 업 에셋을 만들기 위해 ScriptableObject를 사용한다.
[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUp")]
public class KillerPowerUp : ScriptableObject, IVisitor
{
    public string powerUpName;
    public GameObject powerUpPrefab;
    public string powerUpDescriptionl;

    [Range(0.0f, 100.0f)]
    [Tooltip("AttackPower 0 ~ 100")]
    public float attackPower;

    [Range(0.0f, 100.0f)]
    [Tooltip("AttackSpeed 0% ~ 100%")]
    public float attackSpeed;

    [Range(0.0f, 1.0f)]
    [Tooltip("Movement Speed 0 ~ 1")]
    public float movementSpeed;

    public void Visit(KillerWeapon killerWeapon)
    {
        killerWeapon.attackPower += attackPower;
        killerWeapon.attackSpeed += attackSpeed;
    }

    public void Visit(KillerMovement killerMovement)
    {
        killerMovement.movementSpeed += movementSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
