using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    private bool _isRecording;
    private bool _isReplaying;
    private float _replayTime;
    private float _recordingTime;
    //특정 명령이 실행된 때를 추적하는 배열
    private SortedList<float, Command> _recordedCommands = new SortedList<float, Command>();
    
    public void ExecuteCommand(Command command)
    {
        command.Execute(); // 커맨드 실행
        if(_isRecording) _recordedCommands.Add(_recordingTime, command);
        Debug.Log("Recorded Time : " + _recordingTime);
        Debug.Log("Recorded Command : " + command);
    }
    public void Record()
    {
        _recordingTime = 0.0f;
        _isRecording = true;
    }

    public void Replay()
    {
        // 리플레이 시작 전 세팅
        _replayTime = 0.0f;
        _isReplaying = true;
        if(_recordedCommands.Count <= 0) Debug.LogError("No commands to replay!");
        _recordedCommands.Reverse();
    }

    void FixedUpdate()
    {
        if(_isRecording) _recordingTime += Time.deltaTime; //리코딩 시작
        if(_isReplaying) //리플레이 시작
        {
            _replayTime += Time.deltaTime;
            if(_recordedCommands.Any()) //기록된 커맨드가 존재한다면,
            {
                if(Mathf.Approximately(_replayTime, _recordedCommands.Keys[0]))
                {
                    Debug.Log("Replay Time : " + _replayTime);
                    Debug.Log("Replay Command : " + _recordedCommands.Values[0]);
                    _recordedCommands.Values[0].Execute();
                    _recordedCommands.RemoveAt(0);
                }

            }
            else //기록된 커맨드가 다 떨어졌다면 리플레이 종료
            {
                _isReplaying = false;
            }
        }
    }
}
