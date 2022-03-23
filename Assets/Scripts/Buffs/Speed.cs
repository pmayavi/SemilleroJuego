using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : StatusFather
{
    public override IEnumerator Debuff()
    {
        if (tag == "Buff")
        {
            GameObject.Find("GameManager").GetComponent<PlayerStats>().SetSpeed(number);
            yield return new WaitForSeconds(0);
        }
        else
        {
            GameObject.Find("GameManager").GetComponent<PlayerStats>().SetSpeed(number);
            player.color = sprite.color;
            yield return new WaitForSeconds(coolDown);
            player.color = new Color(255, 255, 255, 255);
            GameObject.Find("GameManager").GetComponent<PlayerStats>().SetSpeed(1 / number);
        }
    }
}
