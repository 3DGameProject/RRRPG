using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerCondition condition;

    public ItemData itemData;
    public Action addItem;

    public Transform dropPosition;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        condition = GetComponent<PlayerCondition>();
    }
}