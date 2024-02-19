using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static GameData;

public class SpawnFriend : MonoBehaviour
{
    private GameObject canvas;
    private GameObject[] FriendObject = new GameObject[SPAWN_FRIEND_NUM];
    private bool[] ActiveFriendObject = new bool[SPAWN_FRIEND_NUM];
    private bool AllActive = false;

    public GameObject[] FriendPrefab = new GameObject[SPAWN_FRIEND_NUM];

    // private Vector3[] FriendPosition = new Vector3[SPAWN_FRIEND_NUM] 
    // {

    // }

    void Start()
    {
        canvas = GameObject.Find("FriendCanvas");
    }

    void Update()
    {
        if(AllActive) return;
        for(int i = 0;i < MAX_SHIFT_BUY_BUTTONS;i++)
        {
            for(int j = 0;j < BUY_BUTTON_NUM;j++)
            {
                if(i == 0 && j == 0) continue;
                if(BuyStack[i,j] != 0)
                {
                    Spawn(i, j);
                }
            }
        }
        AllActive = ActiveCheck();
    }

    void Spawn(int i, int j)
    {
        if(i == 0)
        {
            switch(j)
            {
                case 1:
                if(ActiveFriendObject[0]) return;
                FriendObject[0] = Instantiate(FriendPrefab[0]);
                FriendObject[0].transform.SetParent(canvas.transform,false);
                ActiveFriendObject[0] = true;
                break;

                case 2:
                if(ActiveFriendObject[1]) return;
                FriendObject[1] = Instantiate(FriendPrefab[1]);
                FriendObject[1].transform.SetParent(canvas.transform,false);
                ActiveFriendObject[1] = true;
                break;

                default:
                break;
            }
        }
        else
        {
            switch(j)
            {
                case 0:
                if(ActiveFriendObject[2]) return;
                FriendObject[2] = Instantiate(FriendPrefab[2]);
                FriendObject[2].transform.SetParent(canvas.transform,false);
                ActiveFriendObject[2] = true;
                break;

                case 1:
                if(ActiveFriendObject[3]) return;
                FriendObject[3] = Instantiate(FriendPrefab[3]);
                FriendObject[3].transform.SetParent(canvas.transform,false);
                ActiveFriendObject[3] = true;
                break;

                case 2:
                if(ActiveFriendObject[4]) return;
                FriendObject[4] = Instantiate(FriendPrefab[4]);
                FriendObject[4].transform.SetParent(canvas.transform,false);
                ActiveFriendObject[4] = true;
                break;

                default:
                break;

            }
        }
    }
    
    bool ActiveCheck()
    {
        foreach (bool Active in ActiveFriendObject)
        {
            if(!Active)
            {
                return false;
            }
        }
        return true;
    }
}
