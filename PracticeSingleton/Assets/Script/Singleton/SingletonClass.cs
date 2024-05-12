using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonClass {

    private SingletonClass() { }

    private static SingletonClass instance;

    public static SingletonClass Instance {
        get {
            if (instance == null) {
                instance = new SingletonClass();
            }
            return instance;
        }
    }
}