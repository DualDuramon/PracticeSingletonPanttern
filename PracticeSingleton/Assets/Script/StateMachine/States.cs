using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState {
    private static IdleState instance;

    public IdleState() {}

    public static IdleState Instance {  //½Ì±ÛÅæ
        get {
            if (instance == null) {
                instance = new IdleState();
            }

            return instance;
        }
    }

    public static IdleState GetInstance() {
        return instance;
    }

    public void DoingState() {
        Debug.Log("°æ°è¸ðµå ÁøÀÔ");
        
    }   
}

public class PrepareState : IState {
    private static PrepareState instance;
    public PrepareState() {}

    public static PrepareState Instance {  //½Ì±ÛÅæ
        get {
            if (instance == null) {
                instance = new PrepareState();
            }

            return instance;
        }
    }

    public static PrepareState GetInstance() {
        return instance;
    }
    public void DoingState() {
        Debug.Log("Àû Æ÷Âø, ¿¹¿­ Áß");

    }
}

public class AttackState : IState {
    private static AttackState instance;
    public  AttackState() { }

    public static AttackState Instance {  //½Ì±ÛÅæ
        get {
            if (instance == null) {
                instance = new AttackState();
            }

            return instance;
        }
    }

    public static AttackState GetInstance() {
        return instance;
    }
    public void DoingState() {
        Debug.Log("»ç°Ý Áß");

    }
}