
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Player
{
/*
플레이어의 상태는 현재 크게 Idle / Move / Dead 세가지로 나뉩니다.
Idle은 비전투 상태
Move는 전투 상태 (움직임, 공격, 점프 모두 포함된 상태)
Dead는 사망했을 경우를 의미합니다.
특정 CC기가 걸렸을 경우, 해당하는 상태를 추가합니다.
*/

    /*
    Player의 Idle 상태
    비전투 씬에서의 상태입니다.
    상점 / 능력 선택 등등 전투 씬을 제외한 곳에서 Idle이 됩니다.
    */
    public class PlayerIdleState : MonoBehaviour, IPlayerState
    {
    
        private PlayerController _playerController;
        private PlayerCharacter _playerCharacter;
        public void Handle(PlayerController playerController)
        {
            if(!_playerController)
            {
                _playerController = playerController;
            }
            _playerController.CurrentSpeed = 0.0f;
            _playerController.jumpCount = 0;
            Debug.Log("Player Idle");
        }
        public void Exit()
        {
            _playerController = null;
        }

    }
    /*
    Player의 Move 상태
    좌우 이동 / 점프 모두 이곳에 포함합니다.
    점프를 굳이 따로 나눌 정도로 어떤 특성을 부여하지 않을 예정.
    */
    public class PlayerMoveState : MonoBehaviour, IPlayerState
    {
        private PlayerController _playerController;

        private float _attackTimer = 0.0f;
        private bool _isJumping = false;
        public void Handle(PlayerController playerController)
        {
            if(!_playerController)
            {
                _playerController = playerController;
            }
            _playerController.CurrentSpeed = _playerController.speed;
            _playerController.jumpCount = 1;
            Debug.Log("Player Move");
        }
        public void Exit()
        {
            _playerController = null;
        }
        /*
        일반적인 공격은 Move 상태에서 일정 주기로 실행됨
        특별한 스킬은 입력을 받아서 Attack상태에서 실행됨.
        */
        void CycleAttack()
        {
            Debug.Log("Attack!");

        }
        void Update()
        {
            if(_playerController)
            {
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");
                //ector2 dir = new Vector2(horizontal, vertical);
                //Debug.Log(_playerController.speed);
                transform.Translate(new Vector3(horizontal, vertical, 0.0f) * _playerController.CurrentSpeed * Time.deltaTime);

                if(Input.GetKeyDown(KeyCode.Space) && _playerController.jumpCount > 0) // 점프 입력 받기
                {
                    _playerController.rigidbody.AddForce(new Vector2(0.0f, _playerController.jumpForce));
                    _isJumping = true; // 추후 애니메이션 조작을 위함.
                    _playerController.jumpCount -= 1;
                }
            }
        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Collide!");
            // 점프 관련 처리
            if(collision.gameObject.CompareTag("Floor"))
            {
                _isJumping = false;
                _playerController.jumpCount = 1;
            }
        }

    }
    /*
    Player의 Attack 상태
    게임 기획상, Move 상태에서 Attack을 동시에 수행하고 있습니다.
    필요가 없는 부분입니다만, 일단은 남겨둡니다.
    특별한 스킬을 추가하게 될 수도 있으므로.
    "폭탄" 기능을 사용할 때 이 상태로 옴으로써, 잠시동안의 공격과 이동을 멈추게 할 수도 있습니다.
    */
    public class PlayerAttackState : MonoBehaviour, IPlayerState
    {
        private PlayerController _playerController;
        public void Handle(PlayerController playerController)
        {
            if(!_playerController)
            {
                _playerController = playerController;
            }
            Debug.Log("Player Attack");
        }
        public void Exit()
        {
            _playerController = null;
        }

    }
    /*
    Player의 Dead 상태
    플레이어의 체력이 다 떨어져, 죽은 상태를 의미합니다.
    */
    public class PlayerDeadState : MonoBehaviour, IPlayerState
    {
        private PlayerController _playerController;
        public void Handle(PlayerController playerController)
        {
            if(!_playerController)
            {
                _playerController = playerController;
            }
            Debug.Log("Player Dead");
        }
        public void Exit()
        {
            _playerController = null;
        }

    }
}