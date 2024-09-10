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

    private Enemy CreatedPooledItem()
    {
        var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Enemy enemy = go.AddComponent<Enemy>();
        go.name = "Enemy";
        enemy.Pool = Pool;
        return enemy;
    }

    private void OnReturnedToPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }
    private void OnTakeFromPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(true);
    }
    //풀에 더 이상 공간이 없을 때 호출된다.
    private void OnDestroyPoolObject(Enemy enemy) 
    {
        Destroy(enemy.gameObject);
    }
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
