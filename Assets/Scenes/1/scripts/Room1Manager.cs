using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1Manager : CursorHandle
{
    protected override void Update()
    {
        updateStatuesArm();
    }
    public void updateStatuesArm()
    {
        base.Update();
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
}
