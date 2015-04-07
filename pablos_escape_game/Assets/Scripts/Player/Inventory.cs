using UnityEngine;
using System.Collections;

public static class Inventory {


    // Inventory Key flags
    public static bool whiteKey;
    public static bool redKey;
    public static bool blueKey;
    public static bool goldKey;




    // Method checks if player has any key, if he does triggers gui to show
    public static void manageKeys()
    {
        PlayerHUD.toggleWhiteKey(updateInventoryGUI(whiteKey));
        PlayerHUD.toggleRedKey(updateInventoryGUI(redKey));
        PlayerHUD.toggleBlueKey(updateInventoryGUI(blueKey));
        PlayerHUD.toggleGoldKey(updateInventoryGUI(goldKey));
    }




    public static bool updateInventoryGUI(bool inventoryItem)
    {
        if (inventoryItem == true)
            return true;
        else
            return false; 
    }


}

