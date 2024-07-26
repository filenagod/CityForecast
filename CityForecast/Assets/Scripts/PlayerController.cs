using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameStarted;
    public bool dogru;
    public QuestionManager questionManager;

    public List<Sehir> redSehirs = new List<Sehir>();

    void Update()
    {
        if (gameStarted)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                Sehir sehir = hit.transform.GetComponent<Sehir>();
                if (Input.GetMouseButtonDown(0))
                {
                    if (dogru == false)
                    {
                        if (sehir == questionManager.randomSehir)
                        {
                            Material dogruMaterial = sehir.GetComponent<MeshRenderer>().material;
                            dogruMaterial.color = Color.green;
                            sehir.GetComponent<MeshRenderer>().material = dogruMaterial;
                            dogru = true;

                            if (redSehirs.Count > 0)
                            {
                                foreach (Sehir yanlisSehir in redSehirs)
                                {
                                    yanlisSehir.GetComponent<MeshRenderer>().material.color = Color.black;
                                }
                            }

                            questionManager.sehirler.Remove(sehir);
                            questionManager.sehirler.TrimExcess();
                            redSehirs.Clear();
                            redSehirs.TrimExcess();
                            Invoke(nameof(Delay), 1f);
                        }
                        else
                        {
                            if (sehir.GetComponent<MeshRenderer>().material.color != Color.green)
                            {
                                redSehirs.Add(sehir);
                                Material yanlisMaterial = sehir.GetComponent<MeshRenderer>().material;
                                yanlisMaterial.color = Color.red;
                                sehir.GetComponent<MeshRenderer>().material = yanlisMaterial;
                            }
                        }
                    }
                }
            }
        }
    }


    private void Delay()
    {
        questionManager.OpenQuestions();
    }
}
