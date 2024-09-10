using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : Entity
{
    public IObjectPool<Enemy> Pool {get; set;}
    private float timeToSelfDestruct = 3.0f;

    public void TakeDamage(DamageMessage damageMessage)
    {
        CurrentHealth -= damageMessage.amount;
        if(CurrentHealth <= 0.0f)
        {
            ReturnToPool();
        }

    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(timeToSelfDestruct);
        Debug.Log("Return!");
        ReturnToPool();
    }
    void ResetEnemy()
    {
        CurrentHealth = health;
    }

    void ReturnToPool()
    {
        Pool.Release(this);
    }
    
    void OnEnable()
    {
        StartCoroutine(SelfDestruct());
    }
    void OnDisable()
    {
        ResetEnemy();
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
