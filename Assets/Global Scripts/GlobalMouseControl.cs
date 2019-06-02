﻿using UnityEngine.UI;
using UnityEngine;

public class GlobalMouseControl : GlobalEffectControl
{
    [SerializeField] public GameObject interactContainer;
    [SerializeField] public Text dialogBox;
    [SerializeField] public Text nameBox;
    public Collider2D col;
    [HideInInspector] public string currentHover = "None";

    private void OnMouseEnter()
    {
        print(col.name);
        currentHover = col.name;
        if (currentHover.Contains("interact"))
        {
            Helper.setMouseStatus(MouseStatus.Click);
        }
        else if (currentHover.Contains("discover"))
        {
            if (!Helper.inDetail)
                Helper.setMouseStatus(MouseStatus.Inspect);
            else
                Helper.setMouseStatus(MouseStatus.Free);
        }
        else if (currentHover.Contains("grab"))
        {
            Helper.setMouseStatus(MouseStatus.Grap);
        }
        else
        {
            Helper.setMouseStatus(MouseStatus.Free);
        }
        this.toolTipHandle();
    }

    private void OnMouseExit()
    {
        Helper.setMouseStatus(MouseStatus.Free);
        Tooltip.hideToolTip_Static();
    }

    public virtual void toolTipHandle() {}

    public void detailInteraction(string name, string nameText, string contentText)
    {
        if (!interactContainer.name.Equals(name))
            return;
        if (Helper.inDetail)
        {   //TODO: add fade in, fade out
            Helper.inDetail = false;
            interactContainer.SetActive(false);
            dialogBox.enabled = false;
            nameBox.enabled = false;
        }
        else
        {
            interactContainer.SetActive(true);
            dialogBox.text = contentText;
            nameBox.text = nameText;
            dialogBox.enabled = true;
            nameBox.enabled = true;
            Helper.inDetail = true;
            Helper.setMouseStatus(MouseStatus.Free);
        }
        disableGameObjectList(new string[] {
            "background group", 
            "enviroment group", 
            "interactable group", 
            "effect group"});
    }

    private void disableGameObjectList(string[] names) {
        foreach (var name in names)
        {
            GameObject[] objArray = GameObject.FindGameObjectsWithTag(name);
            foreach (var obj in objArray)
            {
                obj.SetActive(false);
            }
        }
    }

    private void enableGameObjectList(string[] names) {
        foreach (var name in names)
        {
            GameObject[] objArray = GameObject.FindGameObjectsWithTag(name);
            foreach (var obj in objArray)
            {
                obj.SetActive(true);
            }
        }
    }
}
