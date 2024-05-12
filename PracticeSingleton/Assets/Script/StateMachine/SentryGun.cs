using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryGun : MonoBehaviour
{
    public float nowPrepareTime = 0.0f;
    public float maxPrepareTime = 3.0f;
    private SentryGunContext context;
    private IState idle, prepare, attack;

    private void Awake() {
        idle = new IdleState();
        prepare = new PrepareState();
        attack = new AttackState();

        context = new SentryGunContext(ref idle);
    }

    private void Update() {
        if (context.NowState == idle) {
            nowPrepareTime -= Time.deltaTime;

            if (nowPrepareTime < 0.0f) nowPrepareTime = 0.0f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.CompareTag("Enemy")) return;

        context.ChangeState(ref prepare);
        context.DoState();
    }

    void OnTriggerStay2D(Collider2D collision) {

        if (!collision.CompareTag("Enemy")) return;

        if (nowPrepareTime < maxPrepareTime) {
            nowPrepareTime += Time.deltaTime;
            return;
        }   
        else if(context.NowState != attack) {
            context.ChangeState(ref attack);
        }
        
        context.DoState();
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (!collision.CompareTag("Enemy")) return;

        context.ChangeState(ref idle);
        context.DoState();
    }
    
}