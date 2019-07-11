using UnityEngine;
using UnityEngine.UI;

public class LockClickNumbers : GlobalMouseControl
{
    private static int number1, number2, number3;
    public Sprite sprite_Lock_open;
    public Sprite sprite_Locker_open;
    public Sprite sprite_Locker_Closeup_open;
    public Sprite[] sprite_Numbers;
    public override void Start()
    {
        base.Start();
        number1 = 0;
        number2 = 0;
        number3 = 0;
    }
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        if (IsMouseOverUI())
            return;
        gameObject.GetComponent<AudioSource>().Play();
        if (currentHover.StartsWith("number"))
        {
            string number = gameObject.GetComponent<SpriteRenderer>().sprite.name.Replace("numbers", "");
            if (int.TryParse(number, out int result))
            {
                result++;
                if (result > 9)
                    result = 0;
                GetComponent<SpriteRenderer>().sprite = sprite_Numbers[result];
                if (currentHover == "number1")
                    number1 = result;
                if (currentHover == "number2")
                    number2 = result;
                if (currentHover == "number3")
                    number3 = result;
            }
            if (number1 == 8 && number2 == 7 && number3 == 4)
            {
                GameObject.Find("detail").GetComponent<SpriteRenderer>().sprite = sprite_Lock_open;
                GameObject.Find("Locker_Closeup").GetComponent<SpriteRenderer>().sprite = sprite_Locker_Closeup_open;
                GameObject.Find("locker").GetComponent<SpriteRenderer>().sprite = sprite_Locker_open;
                GameObject.Find("key_box").GetComponent<SpriteRenderer>().sortingOrder = 2;
                GameObject.Find("lock").SetActive(false);
                GameObject.Find("dot").SetActive(false);
                GameObject dialog = GameObject.Find("dialog1 canvas");
                if (dialog != null)
                {
                    Text[] Texte = dialog.GetComponentsInChildren<Text>();
                    foreach (Text Tx in Texte)
                    {
                        if (Tx.name == "Text1 content")
                            Tx.text = "Oh, it's open!";
                    }
                }
                dialog = GameObject.Find("dialog canvas");
                if (dialog != null)
                {
                    Text[] Texte = dialog.GetComponentsInChildren<Text>();
                    foreach (Text Tx in Texte)
                    {
                        if (Tx.name == "Text content")
                            Tx.text = "It's Unlocked!";
                    }
                    GameManager.Room3.puzzleSoved = true;
                    GameObject.Find("InteractContainer_locker").GetComponent<AudioSource>().Play();
                }
            }
        }
    }
}
