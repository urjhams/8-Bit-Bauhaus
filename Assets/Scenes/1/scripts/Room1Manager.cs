﻿using UnityEngine;
using UnityEngine.SceneManagement;
public class Room1Manager : CursorHandle
{
    public GameObject lastPeice;
    public GameObject birdFood;
    public GameObject inventory;

    void Start()
    {
        birdFood.SetActive(GameManager.Room1.birdFood);
    }
    protected override void Update()
    {
        base.Update();
        updateStatuesArm();
        updateGoal();
    }
    public void updateStatuesArm()
    {
        try
        {
            for (int i = 0; i < GameManager.Room1.leftArm.Length; i++)
            {
                Helper.getSpriteRendererOf(GameManager.Room1.leftArm[i]).enabled = 
                (i == GameManager.Room1.currentLeftArm);
            }
            for (int i = 0; i < GameManager.Room1.rightArm.Length; i++)
            {
                Helper.getSpriteRendererOf(GameManager.Room1.rightArm[i]).enabled = 
                (i == GameManager.Room1.currentRightArm);
            }
        }
        catch {}
    }

    public void updateGoal() {
        if (GameManager.Room1.goal) {
            lastPeice.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (!Helper.inDetail && GameManager.Room1.goal && GameManager.Room1.addedPeice.Count >= 11) {
            SceneManager.LoadScene("Room 1 End");
        }
    }
}
