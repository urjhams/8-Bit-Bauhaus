using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleControl : MonoBehaviour
{
    public static int[] position = { 0, 1, 2, 2, 0, 1, 1, 3, 2, 1, 0, 0, 1, 1, 0, 3, 1, 0, 0, 2, 1, 0, 3, 0, 1, 1};

    // Start is called before the first frame update
    void Start()
    {
        ResetPuzzle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ResetPuzzle()
    {
        GameObject puzzle = GameObject.Find("InteractContainer_puzzle");
        if (puzzle != null)
        {
            Transform[] pieces = puzzle.GetComponentsInChildren<Transform>();
            int n = 0;
            float xscale = 0.01937887f;
            float yscale = 0.03390509f;
            foreach (Transform p in pieces)
            {
                if (p.name.StartsWith("straight") || p.name.StartsWith("curved") || p.name.StartsWith("special"))
                {
                    try {
                        if (position[n] == 0)
                    {
                        p.transform.localRotation = Quaternion.Euler(0, 0, 0);
                        p.transform.localScale = new Vector3(xscale, yscale, 0);
                    }
                    else if (position[n] == 1)
                    {
                        p.transform.localRotation = Quaternion.Euler(0, 0, 90);
                        p.transform.localScale = new Vector3(yscale, xscale, 0);
                    }
                    else if (position[n] == 2)
                    {
                        p.transform.localRotation = Quaternion.Euler(0, 0, 180);
                        p.transform.localScale = new Vector3(xscale, yscale, 0);
                    }
                    else if (position[n] == 3)
                    {
                        p.transform.localRotation = Quaternion.Euler(0, 0, 270);
                        p.transform.localScale = new Vector3(yscale, xscale, 0);
                    }
                    n++;
                    } catch{}
                }
            }
        }
    }
}
