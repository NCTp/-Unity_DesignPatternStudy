using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


// 부모 클래스로 Entity를 상속 
public class Enemy : Entity
{
    public IObjectPool<Enemy> Pool {get; set;} // 해당 게임 오브젝트라 포함된 Pool을 저장하는 변수. 나는 ~ 풀의 소속입니다!
    private float timeToSelfDestruct = 3.0f; // 테스트를 위한 자살용 변수


    // Entity 클래스의 IDamagealbe 인터페이스에서 선언된 TakeDamage 함수
    // 데미지를 받을 때 사용된다.
    public void TakeDamage(DamageMessage damageMessage)
    {
        CurrentHealth -= damageMessage.amount;
        if(CurrentHealth <= 0.0f)
        {
            ReturnToPool();
        }

    }

    // 자살용 함수
    // 자기 자신을 코루틴을 통해 일정 시간 뒤에 파괴하고, 풀로 돌아간다.
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(timeToSelfDestruct);
        Debug.Log("Return!");
        ReturnToPool();
    }

    // 풀에 들어갈 때 오브젝트를 초기 상태로 돌리기 위한 함수
    void ResetEnemy()
    {
        CurrentHealth = health;
    }

    // 풀에 돌아갈 때 호출하는 함수
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
}
