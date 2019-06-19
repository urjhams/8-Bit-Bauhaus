using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public static GameObject staticInventory = null;
    public static ArrayList currentInventoryItems = new ArrayList();
    public class Room1
    {
        public static int currentRightArm = 0;
        public static int currentLeftArm = 1;
        public static string[] rightArm = {
        "right arm 4", "right arm 2", "right arm 1" };
        public static string[] leftArm = {
        "left arm 4", "left arm 3", "left arm 2" };
        public static string[] rightArmDetail = {
        "interact_right arm 4", "interact_right arm 2", "interact_right arm 1" };
        public static string[] leftArmDetail = {
        "interact_left arm 4", "interact_left arm 3", "interact_left arm 2" };
        public static bool statuesDone = false;
        public static bool ladderDone = false;
        public static List<string> boxCorrectPeices = new List<string>();
        public static List<Tuple<string,Vector3>> boxPeices = new List<Tuple<string, Vector3>>();
        public static bool birdFood = false;
        public static bool birdFoodGave = false;
    }
    public class Room1Basement {
        public static bool lastPeiceCutScene = false;
        public static bool lastPeice = false;
    }

    // this one use for drop
    public static String currentOverGameObjectName = "";
}
