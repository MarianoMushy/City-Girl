//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Attractor : MonoBehaviour
//{
//    public Rigidbody cuerpoRigido;

//    void FixedUpdate()
//    {
//        Attractor[] attractors = FindObjectsOfType<Attractor>();

//        foreach (Attractor attractor in attractors)
//        {
//            if (attractor != this)
//            {
//                Attract(attractor);
//            }
            
//        }
//    }

//    void Attract (Attractor objToAttract)
//    {
//        Rigidbody cuerpoRigidoToAttract = objToAttract.cuerpoRigido;
//        Vector3 direction = cuerpoRigido.position - cuerpoRigido.position;

//        float distance = direction.magnitude;
//        float forceMagnitude = (cuerpoRigido.mass * cuerpoRigido.mass) / Mathf.Pow(distance, 2);

//        Vector3 force = direction.normalized * forceMagnitude;

//        cuerpoRigidoToAttract.AddForce(force);
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {

	const float gravedad = 667.4f;

	public static List<Attractor> Attractors;

	public Rigidbody cuerpoRigido;

	void FixedUpdate ()
	{
		foreach (Attractor attractor in Attractors)
		{
			if (attractor != this)
				Attract(attractor);
		}
	}

	void OnEnable ()
	{
		if (Attractors == null)
			Attractors = new List<Attractor>();

		Attractors.Add(this);
	}

	void OnDisable ()
	{
		Attractors.Remove(this);
	}

	void Attract (Attractor objToAttract)
	{
		Rigidbody rbToAttract = objToAttract.cuerpoRigido;

		Vector3 direction = cuerpoRigido.position - rbToAttract.position;
		float distance = direction.magnitude;

		if (distance == 0f)
			return;

		float forceMagnitude = gravedad * (cuerpoRigido.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
		Vector3 force = direction.normalized * forceMagnitude;

		rbToAttract.AddForce(force);
	}

}
