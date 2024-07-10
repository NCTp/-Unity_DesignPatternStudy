using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Player
{
    public enum PlayerCharacter
        {
            Yuuka,
            Arisu,
            Toki
        }
    public class PlayerController : MonoBehaviour
    {
        public PlayerCharacter playerCharacter;
        public float speed = 2.0f;
        public float CurrentSpeed {get; set;}
        public float attackRate = 1.0f;
        public float jumpForce = 100.0f;
        public int jumpCount = 1;
        public Rigidbody2D rigidbody;

        private IPlayerState _idleState, _moveState, _attackState; // Idle, Move, Attack States
        private PlayerStateContext _playerStateContext;
        
        void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            _playerStateContext = new PlayerStateContext(this);
            _idleState = gameObject.AddComponent<PlayerIdleState>();
            _moveState = gameObject.AddComponent<PlayerMoveState>();
            _attackState = gameObject.AddComponent<PlayerAttackState>();
            CurrentSpeed = 0.0f;
            Debug.Log("I am " + playerCharacter.ToString() + "!");
        }

        void Start()
        {
        }
        void Update()
        {
        }
        public void IdlePlayer()
        {
            _playerStateContext.Transition(_idleState);
        }
        public void MovePlayer()
        {
            _playerStateContext.Transition(_moveState);
        }
        public void AttackPlayer()
        {
            _playerStateContext.Transition(_attackState);
        }
    }
}
