using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerStates;

public class InputHandler : MonoBehaviour
{
    private Invoker _invoker;
    private bool _isReplaying;
    private bool _isRecording;
    private PlayerController _playerController;
    private Command _spaceBar;

    void Awake()
    {
        _invoker = gameObject.AddComponent<Invoker>();
        _playerController = FindObjectOfType<PlayerController>();
        _spaceBar= new PlayerJump(_playerController);
    }
    // Update is called once per frame
    void Update()
    {
        /*
        if(!_isReplaying && _isRecording)
        {
            if(Input.GetKeyDown(KeyCode.Space)) 
            {
                _invoker.ExecuteCommand(_spaceBar);
            }
        }
        */
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            _invoker.ExecuteCommand(_spaceBar);
        }
    }
    void OnGUI()
    {
        if(GUILayout.Button("Start Recording"))
        {
            _isRecording = true;
            _isReplaying = false;
            _invoker.Record();
        }
        if(GUILayout.Button("Stop Recording"))
        {
            _isRecording = false;
        }

        if(!_isRecording)
        {
            if(GUILayout.Button("Start Replay"))
            {
                _isRecording = false;
                _isReplaying = true;
                _invoker.Replay();
            }
            
        }
    }
}
