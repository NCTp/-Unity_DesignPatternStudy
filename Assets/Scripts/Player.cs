using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Player : Entity
    {
        public PlayerController _playerController;
        public void GetDamage(DamageMessage damageMessage)
        {
            health -= damageMessage.amount;
            Debug.Log("Player Health : " + health);
        }
        void Start()
        {
            _playerController.IdlePlayer();
        }
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                _playerController.MovePlayer();
            }
            if(Input.GetKeyDown(KeyCode.Q))
            {
                _playerController.IdlePlayer();
            }
        }
    }
}

