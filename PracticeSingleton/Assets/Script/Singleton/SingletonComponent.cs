using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonComponent : MonoBehaviour
{
    private static SingletonComponent instance;    //static���� �����ؾ� ��� SingletonComponent�� ��ü���� �� ������ ������.

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

        if (objs.Length != 1) { //�̹� �ش� ������Ʈ�� ���� ��ü�� ������������ �ڱ� �ڽ��� �ı��Ͽ� ��ü�� 1���� �����ϰ� ��.
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);  //������ ����Ǳ� ������ �̱��� ���� ������Ʈ�� �ı����� �ʰ� ����.
    }
}
