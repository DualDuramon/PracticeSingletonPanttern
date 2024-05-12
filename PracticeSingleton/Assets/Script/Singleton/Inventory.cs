using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    private static Inventory instance;

    private Dictionary<string, int> slot;
    [SerializeField] private int maxItemCount = 5;
    private int nowItemsCount = 0;

    public static Inventory Instance {
        get {
            if (instance == null) {
                var obj = FindObjectOfType<Inventory>();

                if (obj == null) {
                    obj = new GameObject().AddComponent<Inventory>();
                    instance = obj;
                }

            }

            return instance;
        }
    }

    private void Awake() {
        var objs = FindObjectsOfType<Inventory>();

        if (objs.Length != 1) {
            Destroy(gameObject);
            return;
        }
        slot = new Dictionary<string, int>();

        DontDestroyOnLoad(gameObject);

        testOne();  //�׽�Ʈ�� �ڵ�
    }

    private void testOne() {
        AddItem("HPpotion", 1);
        AddItem("MPpotion", 1);
        AddItem("Gold", 20);
        UseItem("MPpotion");
        UseItem("HPpotion");
        UseItem("HPpotion");
        UseItem("MPpotion");
    }

    public void AddItem(string itemName, int n) {
        if (nowItemsCount + n > maxItemCount) {
            Debug.Log($"�κ��丮�� ������ {itemName} �������� ���� �� �����ϴ�.");
            return;
        }

        if (slot.ContainsKey(itemName)) {
            slot[itemName] += n;
        }
        else {
            slot.Add(itemName, n);
        }

        nowItemsCount += n;

        Debug.Log($"{itemName}�� {n}�� ȹ���߽��ϴ�.");
    }

    public void UseItem(string itemName) {

        if (!slot.ContainsKey(itemName)) {
            Debug.Log(itemName + "�� ������ ���� �ʽ��ϴ�.");
            return;
        }

        /*
         * ������ ��� ȿ�� �߻� �ڵ�
         */

        slot[itemName]--;
        nowItemsCount--;
        if (slot[itemName] == 0) slot.Remove(itemName);

        Debug.Log(itemName + "�� ����߽��ϴ�.");
    }
}