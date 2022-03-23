using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSize : StatusFather
{
    public override IEnumerator Debuff()
    {
        if (tag == "Buff")
        {
            GameObject.Find("GameManager").GetComponent<PlayerStats>().SetSwordSize(number);
            yield return new WaitForSeconds(0);
        }
        else
        {
            GameObject.Find("GameManager").GetComponent<PlayerStats>().SetSwordSize(number);
            player.color = sprite.color;
            yield return new WaitForSeconds(coolDown);
            player.color = new Color(255, 255, 255, 255);
            GameObject.Find("GameManager").GetComponent<PlayerStats>().SetSwordSize(1 / number);
        }
    }
}