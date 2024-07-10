using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Entity Class
// 게임 속 움직이는 모든 객체들은 Entity 클래스를 상속받는다.
public class Entity : MonoBehaviour, IDamageable
{
    public float health;
    private float CurrentHealth;
    public virtual void GetDamage(DamageMessage damageMessage)
    {
        Debug.Log("Entity");
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
