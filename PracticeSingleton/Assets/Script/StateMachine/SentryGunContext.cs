using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryGunContext
{
    private IState nowState;
    public IState NowState {
        get {
            return nowState;
        }
    }
    public SentryGunContext(ref IState state) {
        nowState = state;
    }
    public void ChangeState(ref IState newState) {
        if (nowState == newState) return;
        nowState = newState;
    }

    public void DoState() {
        nowState.DoingState();
    }
}
