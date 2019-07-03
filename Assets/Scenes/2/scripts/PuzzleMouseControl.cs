using UnityEngine;

public class PuzzleMouseControl : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (gameObject.name.StartsWith("straight") || gameObject.name.StartsWith("curved") || gameObject.name.StartsWith("special"))
        {
            float xscale = gameObject.transform.localScale.x;
            float yscale = gameObject.transform.localScale.y;
            gameObject.transform.Rotate(0, 0, 90, Space.Self);
            gameObject.transform.localScale = new Vector3(yscale, xscale, 0);

            string number = gameObject.name.Substring(gameObject.name.IndexOf("_piece") + 6);
            if (number != "")
            {
                if (int.TryParse(number, out int result))
                {
                    if (result >= 1 && result <= 22)
                    {
                        int pos = 0;
                        if (gameObject.transform.localEulerAngles.z == 0)
                        {
                            if (gameObject.name.StartsWith("straight"))
                            {
                                pos = 0;
                            }
                            else if (gameObject.name.StartsWith("curved"))
                            {
                                pos = 0;
                            }
                        }
                        else if (gameObject.transform.localEulerAngles.z == 90)
                        {
                            if (gameObject.name.StartsWith("straight"))
                            {
                                pos = 1;
                            }
                            else if (gameObject.name.StartsWith("curved"))
                            {
                                pos = 1;
                            }
                        }
                        else if (gameObject.transform.localEulerAngles.z == 180)
                        {
                            if (gameObject.name.StartsWith("straight"))
                            {
                                pos = 0;
                            }
                            else if (gameObject.name.StartsWith("curved"))
                            {
                                pos = 2;
                            }
                        }
                        else if (gameObject.transform.localEulerAngles.z == 270)
                        {
                            if (gameObject.name.StartsWith("straight"))
                            {
                                pos = 1;
                            }
                            else if (gameObject.name.StartsWith("curved"))
                            {
                                pos = 3;
                            }
                        }
                        PuzzleControl.position[result - 1] = pos;
                        string code = "";
                        for (int n = 0; n < 22; n++)
                        {
                            code += PuzzleControl.position[n];
                        }
                        if (code == "0030111231113110113011")
                        {
                            GameObject puzzleOK = GameObject.Find("end_piecesok");
                            if (puzzleOK != null)
                            {
                                puzzleOK.GetComponent<SpriteRenderer>().sortingOrder = 15;
                                Helper.PipelinePuzzleOK = true;
                            }
                        }
                    }
                }
            }
        }
    }
}
