using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileSpeed : StatusFather
{
    public override IEnumerator Debuff()
    {
        if (tag == "Buff")
        {
            GameObject.Find("GameManager").GetComponent<PlayerStats>().SetProyectileSpeed(number);
            yield return new WaitForSeconds(0);
        }
        else
        {
            GameObject.Find("GameManager").GetComponent<PlayerStats>().SetProyectileSpeed(number);
            player.color = sprite.color;
            yield return new WaitForSeconds(coolDown);
            player.color = new Color(255, 255, 255, 255);
            GameObject.Find("GameManager").GetComponent<PlayerStats>().SetProyectileSpeed(1 / number);
        }
    }
}
