using System.Collections.Generic;
using UnityEngine;

public class CombinarMeshes : MonoBehaviour
{
    public List<GameObject> objetos;

    private void Start()
    {
        List<Mesh> meshes = null;
        foreach(GameObject objeto in objetos)
        {
            meshes.Add(objeto.GetComponent<Mesh>());
        }

        var mesh = CombineMeshes(meshes);
        GetComponent<MeshFilter>().mesh = mesh;
    }

    private Mesh CombineMeshes(List<Mesh> meshes)
    {
        var combine = new CombineInstance[meshes.Count];
        for (int i = 0; i < meshes.Count; i++)
        {
            combine[i].mesh = meshes[i];
            combine[i].transform = transform.localToWorldMatrix;
        }

        var mesh = new Mesh();
        mesh.CombineMeshes(combine);
        return mesh;
    }
}