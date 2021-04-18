using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTileManager : MonoBehaviour
{
    // Public attributes
    public GameObject currTile;
    public int x, y;

    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (TileGridCreator.instance.finishedGrid)
        {
            // Get player position
            x = TechPlayerMovement.instance.x;
            y = TechPlayerMovement.instance.y;
            // Get current tile
            currTile = TileGridCreator.instance.tileMatrix[x][y];
            // Modify current tile if player presses space
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Activate or deactivate tile according to its current state
                if (currTile.GetComponent<TileModifier>().isActive)
                {
                    TileManager.instance.SetValueAt(x, y, 0);
                    currTile.GetComponent<TileModifier>().isActive = false;
                }
                else
                {
                    TileManager.instance.SetValueAt(x, y, 1);
                    currTile.GetComponent<TileModifier>().isActive = true;
                }
                // Update row text if tiles are correct
                if (TileManager.instance.CheckComplete(y, true))
                {
                    RowChecker.instance.texts[y].color = Color.yellow;
                }
                else
                {
                    RowChecker.instance.texts[y].color = new Color(1, 1, 1);
                }
                // Update column text if tiles are correct
                if (TileManager.instance.CheckComplete(x, false))
                {
                    ColumnChecker.instance.texts[x].color = Color.yellow;
                }
                else
                {
                    ColumnChecker.instance.texts[x].color = new Color(1, 1, 1);
                }
            }
        }
    }
}
