﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room2MouseControl : GlobalMouseControl
{
    public override void OnMouseDown()
    {
        bool runAction = true;
        GameObject dialog = null;

        if (currentHover == "other_stuff" & Helper.DialogState != 1)
            runAction = false;
        if (runAction)
        {
            base.OnMouseDown();
            if (IsMouseOverUI())
                return;
            switch (currentHover)
            {
                case "worker":
                    if (Helper.Scene2BaseOK == false)
                    {
                        detailInteraction(
                            "InteractContainer_worker",
                            "Worker:",
                            "\"Hey! This is a construction site. Get out!\"");
                        GameObject worker_zoom = GameObject.Find("worker_zoom");
                        if (worker_zoom != null)
                        {
                            Animator workerAnimator = worker_zoom.GetComponent<Animator>();
                            if (workerAnimator != null)
                            {
                                workerAnimator.SetBool("Play", true);
                            }
                        }
                    }
                    else
                    {
                        detailInteraction(
                            "InteractContainer_worker",
                            "Sophia:",
                            "\"Excuse me, could I borrow a screwdriver?\"");
                        Helper.inDetail = false;
                    }
                    break;
                case "other_stuff":
                    detailInteraction(
                        "InteractContainer_puzzle",
                        "Sophia:",
                        "\"Puzzle?\"");
                    dialog = GameObject.Find("dialog_worker canvas");
                    if (dialog != null)
                    {
                        Image[] Images = dialog.GetComponentsInChildren<Image>();
                        foreach (Image Im in Images)
                        {
                            Im.enabled = false;
                        }
                        Text[] Texte = dialog.GetComponentsInChildren<Text>();
                        foreach (Text Tx in Texte)
                        {
                            Tx.enabled = false;
                        }
                    }
                    break;
                case "Goethe_Schiller":
                    detailInteraction(
                        "InteractContainer_gs",
                        "Sophia:",
                        "\"What is that on the pedastal?\"");
                    Helper.inDetail = false;
                    break;
                case "goethe_schiller_from behind":
                    detailInteraction(
                        "InteractContainer_gs_base",
                        "Sophia:",
                        "\"There is something behind this shield. I probably need a screwdriver!\"");
                    dialog = GameObject.Find("dialog canvas");
                    if (dialog != null)
                    {
                        Image[] Images = dialog.GetComponentsInChildren<Image>();
                        foreach (Image Im in Images)
                        {
                            Im.enabled = false;
                        }
                        Text[] Texte = dialog.GetComponentsInChildren<Text>();
                        foreach (Text Tx in Texte)
                        {
                            Tx.enabled = false;
                        }
                    }
                    Helper.Scene2BaseOK = true;
                    break;
                default:
                    break;
            }
        }
    }
}
