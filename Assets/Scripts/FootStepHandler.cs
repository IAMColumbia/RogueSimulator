
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FootstepHandler : MonoBehaviour
{
    [System.Serializable]
    public class TileEffect
    {
        public TileBase tile;
        public ParticleSystem particles;
    }

    [Header("Tile Detection")]
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Transform footPosition;

    [Header("Footstep Effects")]
    [SerializeField] private List<TileEffect> tileEffects;

    /// <summary>
    /// Called by an Animation Event whenever a foot touches the ground.
    /// </summary>
    public void CreateFootstep()
    {
        Debug.Log("Footstep created at position: " + (footPosition != null ? footPosition.position : transform.position));
        Vector3 position = footPosition != null
            ? footPosition.position
            : transform.position;

        Vector3Int cellPosition =
            groundTilemap.WorldToCell(position);

        TileBase currentTile =
            groundTilemap.GetTile(cellPosition);

        if (currentTile == null) return;

        foreach (TileEffect effect in tileEffects)
        {
            if (effect.tile == currentTile)
            {
                if (effect.particles != null)
                {
                    ParticleSystem particles = Instantiate(
                        effect.particles,
                        position,
                        Quaternion.identity
                    );

                    particles.Play();
                }

                return;
            }
        }
    }
}
