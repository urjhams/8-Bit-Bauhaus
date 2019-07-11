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
        public static List<Tuple<string, Vector3>> boxPeices = new List<Tuple<string, Vector3>>();
        public static bool birdFood = true;
        public static bool goal = false;
        public static ArrayList addedPeice = new ArrayList();
    }
    public class Room1Basement
    {
        public static bool lastPeiceCutScene = false;
        public static bool lastPeice = false;
        public static bool lastPeiceCollected = false;
        public static bool wardrobeOpen = false;
        public static bool goal = false;
    }
    public class Room2
    {
        public static bool needScrewDriver = false;
        public static bool gotScrewDriver = false;
        public static bool puzzleGiven = false;
        public static bool scewDriverCutScene = true;
        public static bool goal = false;
    }
    public class Room3
    {
        public static bool puzzleSoved = false;
        public static bool goal = false;
    }

    // this one use for drop
    public static String currentOverGameObjectName = "";

    public static void resetGame()
    {
        staticInventory = null;
        currentInventoryItems = new ArrayList();
        currentOverGameObjectName = "";

        Room1.currentRightArm = 0;
        Room1.currentLeftArm = 1;
        Room1.statuesDone = false;
        Room1.ladderDone = false;
        Room1.boxPeices = new List<Tuple<string, Vector3>>();
        Room1.birdFood = true;
        Room1.goal = false;
        Room1.addedPeice = new ArrayList();

        Room1Basement.lastPeiceCutScene = false;
        Room1Basement.lastPeice = false;
        Room1Basement.lastPeiceCollected = false;
        Room1Basement.wardrobeOpen = false;
        Room1Basement.goal = false;

        Room2.needScrewDriver = false;
        Room2.gotScrewDriver = false;
        Room2.puzzleGiven = false;
        Room2.scewDriverCutScene = true;
        Room2.goal = false;
        PuzzleControl.position = new int[] { 0, 1, 2, 2, 0, 1, 1, 3, 2, 1, 0, 0, 1, 1, 0, 3, 1, 0, 0, 2, 1, 0, 3, 0, 1, 1 };

        Room3.puzzleSoved = false;
        Room3.goal = false;

        Helper.inDetail = false;
        Helper.Scene2BaseOK = false;
        Helper.PipelinePuzzleOK = false;
        Helper.DialogState = 0;
    }
}
