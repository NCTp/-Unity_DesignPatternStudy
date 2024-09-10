using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyObjectPool : MonoBehaviour
{
    public int maxPoolSize = 10; // 풀에 보관할 오브젝트의 수 
    public int stackDefaultCapacity = 10; // 기본 스택 크기

    private IObjectPool<Enemy> _pool;
    
    public IObjectPool<Enemy> Pool // 풀 초기화 부분
    {
        get
        {
            if(_pool == null)
            {
                _pool = new ObjectPool<Enemy>(
                    CreatedPooledItem,
                    OnTakeFromPool,
                    OnReturnedToPool,
                    OnDestroyPoolObject,
                    true,
                    stackDefaultCapacity,
                    maxPoolSize);
            }
            return _pool;
        }
    }

    // Pooling할 오브젝트를 만드는 함수
    // Pool에 들어갈 오브젝트를 만드는 공장이 이곳
    private Enemy CreatedPooledItem()
    {
        var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Enemy enemy = go.AddComponent<Enemy>();
        go.name = "Enemy";
        enemy.Pool = Pool;
        return enemy;
    }

    // 오브젝트를 풀로 반환
    // 반환된 오브젝트는 비활성화된다.
    private void OnReturnedToPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    // 오브젝트를 사용하기 위해 풀에서 가져감.
    // 오브젝트는 초기 상태에서 활성화된다.
    private void OnTakeFromPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(true);
    }

    // 풀에 더 이상 공간이 없을 때 호출된다.
    // 저장할 공간을 넘은 오브젝트를 삭제한다.
    private void OnDestroyPoolObject(Enemy enemy) 
    {
        Destroy(enemy.gameObject);
    }

    // 오브젝트를 스폰할 때 사용한다.
    // 풀에서 오브젝트를 꺼내고, 랜덤한 위치에 생성한다.
    public void Spawn()
    {
        var amount = Random.Range(1, 10);
        for(int i = 0; i < amount; i++)
        {
            var enemy = Pool.Get();
            enemy.transform.position = Random.insideUnitSphere * 10;
        }
    }
}
