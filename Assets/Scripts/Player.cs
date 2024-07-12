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
            _playerController.PlayerIdle();
        }
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                _playerController.PlayerIdle();
            }
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                _playerController.PlayerMove();
            }
            if(Input.GetKeyDown(KeyCode.Alpha3))
            {
                _playerController.PlayerAttack();
            }
            if(Input.GetKeyDown(KeyCode.Alpha4))
            {
                _playerController.PlayerDead();
            }
        }
    }
}

