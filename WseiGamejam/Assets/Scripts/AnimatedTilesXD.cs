using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AnimatedTilesXD : MonoBehaviour
{
    [SerializeField] private List<Sprite> frames;
    [SerializeField] private Tilemap tilemap;

    private int _currentFrameIndex = 0;
    private AnimatorManager _animatorManager;
    private BoundsInt bounds;
    private TileBase[] allTiles;
    private void Start()
    {
        _animatorManager = FindObjectOfType<AnimatorManager>();
        _animatorManager.NewFrame += OnNewFrame;
        bounds = tilemap.cellBounds;
        allTiles = tilemap.GetTilesBlock(bounds);
    }
    
    private void OnDestroy()
    {
        _animatorManager.NewFrame -= OnNewFrame;
    }

    private void OnNewFrame()
    {
        if (frames.Count <= 1)
            return;
        
        _currentFrameIndex++;
        if (_currentFrameIndex >= frames.Count)
            _currentFrameIndex = 0;

        var newSprite = frames[_currentFrameIndex];

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null)
                {
                    Vector3Int localPlace = new Vector3Int(bounds.x + x, bounds.y + y, bounds.z);
                    tilemap.SetTile(localPlace, null); // Remove the old tile

                    Tile newTile = ScriptableObject.CreateInstance<Tile>();
                    newTile.sprite = newSprite;
                    tilemap.SetTile(localPlace, newTile);
                }
            }
        }
    }
}