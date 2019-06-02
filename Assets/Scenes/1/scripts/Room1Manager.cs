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
            for (int i = 0; i < Helper.leftArm.Length; i++)
            {
                Helper.getSpriteRendererOf(Helper.leftArm[i]).enabled = 
                (i == Helper.room1_LeftArm);
            }
            for (int i = 0; i < Helper.rightArm.Length; i++)
            {
                Helper.getSpriteRendererOf(Helper.rightArm[i]).enabled = 
                (i == Helper.room1_RightArm);
            }
        }
        catch (NullReferenceException e)
        {
            
        }
    }
}
