/*
    Simple script to let player know if they have accomplished the grid correctly by pressing the 'Verify'
    button.

    Contributor: Diego Armando Ulibarri Hernández
*/
using UnityEngine;

public class ButtonActivator : MonoBehaviour
{

    // Call two of the main classes to check if player has a correct answer
    public void CheckWin()
    {
        // If player has won
        if (TileManager.instance.CheckWin())
        {
            // Set winning screen
            TechEndingScreen.instance.SetScreen();
        }
    }
}
