﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT);
        }
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefender(GetSquareClicked());
        
    }

    public void selectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefender(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();
        if (starDisplay.HaveEnoughStar(defenderCost))
        {
            SpawnDefender(gridPos);
            starDisplay.spendStars(defenderCost);
        }
    }
    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 worldPos)
    {
        Defender newDefender = Instantiate(defender, worldPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }
}
