using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ground : AbstactSceneController<Ground>
{
	[SerializeField] private Terrain _terrain;
	[SerializeField] private List<ParticleSystem> _plowingParticles;

	public void OnShow()
	{
		_plowingParticles.ForEach( a => a.emissionRate = 50 );
		Invoke("ParticlesSwitchOff", 20.0f);
		UpdateTerrainTexture(_terrain.terrainData,
		                     1,
		                     0,
		                     0,
		                     _terrain.terrainData.alphamapWidth,
		                     0,
		                     _terrain.terrainData.alphamapHeight);
	}

	public void OnHide()
	{
		if(IsInvoking("ParticlesSwitchOff"))
		{
			CancelInvoke("ParticlesSwitchOff");
		}
	}

	private void ParticlesSwitchOff()
	{
		_plowingParticles.ForEach( a => a.emissionRate = 0 );
	}

	public void Powling(Vector3 hitPoint, int thicknessX, int thicknessZ)
	{
		int startI = (int)((hitPoint.z / 45.15f) * 256);
		int startJ = (int)((hitPoint.x / 27.8f) * 256);

		UpdateTerrainTexture(_terrain.terrainData,
		                     0,
		                     1,
		                     Mathf.Clamp(startI - thicknessZ, 1, 256),
		                     Mathf.Clamp(startI + thicknessZ, 1, _terrain.terrainData.alphamapWidth),
		                     Mathf.Clamp(startJ - thicknessX, 1, 256),
		                     Mathf.Clamp(startJ + thicknessX, 1, _terrain.terrainData.alphamapHeight));
	}

	private void UpdateTerrainTexture(TerrainData terrainData, int textureNumberFrom, int textureNumberTo, int startI, int endI, int startJ, int endJ)
	{
		//get current paint mask
		float[, ,] alphas = terrainData.GetAlphamaps(0, 0, terrainData.alphamapWidth, terrainData.alphamapHeight);
		// make sure every grid on the terrain is modified
		for(int i = startI; i<endI; i++)
		{
			for(int j = startJ; j<endJ; j++)
			{
				//for each point of mask do:
				//paint all from old texture to new texture (saving already painted in new texture)
				alphas[i, j, textureNumberTo] = Mathf.Max(alphas[i, j, textureNumberFrom], alphas[i, j, textureNumberTo]);
				//set old texture mask to zero
				alphas[i, j, textureNumberFrom] = 0f;
			}
		}
		// apply the new alpha
		terrainData.SetAlphamaps(0, 0, alphas);
	}
}
