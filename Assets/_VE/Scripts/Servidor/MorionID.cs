using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[AddComponentMenu("Morion Servidor/Morion ID")]
public class MorionID : MonoBehaviour
{
	public bool idPersonalizada = false;

	[ConditionalHide("idPersonalizada", true)]
	public string ID = "";


	private void OnIns()
	{
		
	}

	private void OnDrawGizmosSelected()
	{
		if ((ID.Equals("") && !idPersonalizada))
		{
			GenerarID();
		}
	}

	public void GenerarID()
	{
		ID = SceneManager.GetActiveScene().name.ToUpper() + "_" + Random.Range(10000, 99999).ToString();
	}
}
