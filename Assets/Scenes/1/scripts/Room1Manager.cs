using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1Manager : MonoBehaviour
{
    public static string[] rightArm = { "right arm 4", "right arm 1" };
    public static string[] leftArm = { "left arm 4", "left arm 3", "left arm 2" };
    public static string[] rightArmDetail = { "interact_right arm 4", "interact_right arm 1" };
    public static string[] leftArmDetail = { "interact_left arm 4", "interact_left arm 3", "interact_left arm 2" };

    void Start()
    {
        updateArm();
    }

    void Update()
    {
        updateArm();
    }

    public static void updateArm()
    {
        try {
            for (int i = 0; i < leftArm.Length; i++)
        {
            GameObject.Find(leftArm[i]).SetActive(i == Helper.room1_LeftArm);
            GameObject.Find(leftArmDetail[i]).SetActive(i == Helper.room1_LeftArm);
            // Helper.getSpriteRendererOf(leftArmDetail[i]).enabled = (i == Helper.room1_LeftArm);
        }
        for (int i = 0; i < rightArm.Length; i++)
        {
            GameObject.Find(rightArm[i]).SetActive(i == Helper.room1_RightArm);
            Helper.getSpriteRendererOf(rightArmDetail[i]).enabled = (i == Helper.room1_RightArm);
        }
        } catch (NullReferenceException e) {
            
        }
        
    }
}
