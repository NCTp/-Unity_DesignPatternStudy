using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientObjectPool : MonoBehaviour
{
    private EnemyObjectPool _enemyPool;
    // Start is called before the first frame update
    void Start()
    {
        _enemyPool = gameObject.AddComponent<EnemyObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI()
    {
        if(GUILayout.Button("Spawn Drones"))
        {
            _enemyPool.Spawn();
        }
    }
}