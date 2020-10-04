using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteControlItem : InventoryItem
{
    private bool isOn = false;
    public override void UiUse()
    {
        base.UiUse();

        if (!TvGame.IsTvGame)
            return;

        isOn = !isOn;
        if (isOn)
        {
            TvGame.TurnOn();
        }
        else
        {
            TvGame.TurnOff();
        }
    }
}
