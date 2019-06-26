using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockClickNumbers : GlobalMouseControl
{
    private static int number1, number2, number3;

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        if (IsMouseOverUI())
            return;
        if (currentHover.StartsWith("number"))
        {
            string number = gameObject.GetComponent<SpriteRenderer>().sprite.name.Replace("numbers", "");
            if (int.TryParse(number, out int result))
            {
                result++;
                if (result > 9)
                    result = 0;
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("numbers\\numbers" + result.ToString());
                if (currentHover == "number1")
                    number1 = result;
                if (currentHover == "number2")
                    number2 = result;
                if (currentHover == "number3")
                    number3 = result;
            }
            if (number1 == 8 && number2 == 7 && number3 == 4)
            {
                GameObject.Find("detail").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Lock_open");
                GameObject.Find("Locker_Closeup").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Locker_Closeup_open");
                GameObject.Find("locker").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Locker_open");
                GameObject.Find("key_box").GetComponent<SpriteRenderer>().sortingOrder = 2;
                GameObject.Find("lock").SetActive(false);
                GameObject.Find("dot").SetActive(false);
            }
        }
    }
}
