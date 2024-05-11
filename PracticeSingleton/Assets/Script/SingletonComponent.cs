using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonComponent : MonoBehaviour
{
    private static SingletonComponent instance;    //static으로 선언해야 모든 SingletonComponent의 객체들이 이 변수를 공유함.

    public static SingletonComponent Instance {
        get {
            if(instance == null) {
                var obj = FindObjectOfType<SingletonComponent>();
                
                if (obj != null) {
                    instance = obj;
                }
                else {
                    var newObj = new GameObject().AddComponent<SingletonComponent>();
                    instance = newObj;
                }

            }
            
            return instance;
        }
    }

    private void Awake() {
        var objs = FindObjectsOfType<SingletonComponent>();

        if (objs.Length != 1) { //이미 해당 컴포넌트를 가진 객체가 생성되있으면 자기 자신을 파괴하여 객체가 1개를 유지하게 함.
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);  //게임이 종료되기 전까지 싱글톤 패턴 오브젝트가 파괴되지 않게 만듬.
    }
}
