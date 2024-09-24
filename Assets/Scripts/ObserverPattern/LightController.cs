using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : Subject
{
    private Light[] _lights; // 전구들을 저장할 리스트

    // 씬에 존재하는 모든 전구를 찾아 _lights 리스트에 저장하는 메서드
    void FindLightsInScene()
    {
        _lights = FindObjectsOfType<Light>(); // 씬 위의 모든 전구를 찾아 리스트에 저장.
        //AttachAllLights();
    }

    void AttachAllLights()
    {
        foreach(Light light in _lights)
        {
            Attach(light);
        }
    }
    void DetachAllLights()
    {
        foreach(Light light in _lights)
        {
            Detach(light);
        }
    }
    void OnEnable()
    {
        AttachAllLights();
    }
    void OnDisable()
    {
        DetachAllLights();
    }
    // Start is called before the first frame update
    void Awake()
    {
        FindLightsInScene();
    }

    void OnGUI()
    {
        if(GUILayout.Button("Notify!"))
        {
            NotifyObservers();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // A키를 눌러 옵저버들에게 Notify
        //if(Input.GetKeyDown(KeyCode.A)) NotifyObservers();
    }
    [RuntimeInitializeOnLoadMethod]
    static void PrintSayHello1()
    {
        Debug.LogWarning("게임이 실행되면 출력됩니다");
    }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void PrintSayHello2()
    {
        Debug.LogWarning("씬 로드 직전 출력됩니다");
    }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void PrintSayHello3()
    {
        Debug.LogWarning("씬 로드 직후 출력됩니다");
    }
}
