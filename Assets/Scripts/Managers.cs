using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Managers : Singleton<Managers>
{
    private DateTime _sessionStartTime;
    private DateTime _sessionEndTime;
    public static GameManager _gameManager = new GameManager();
    // Start is called before the first frame update
    void Start()
    {

        _sessionStartTime = DateTime.Now;;
        Debug.Log("Game Session start @: " + DateTime.Now);
    }
    void OnApplcationQuit()
    {
        _sessionEndTime = DateTime.Now;
        TimeSpan timeDifference = _sessionEndTime.Subtract(_sessionStartTime);
        Debug.Log("Game session ended @: " + DateTime.Now);
        Debug.Log("Game session lasted @: " + timeDifference);

    }
    void OnGUI()
    {
        if(GUILayout.Button("Next Scene"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // 다음 인덱스의 씬 로드
            
        }
    }

}
