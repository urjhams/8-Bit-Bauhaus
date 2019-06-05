using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
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
    }
}
