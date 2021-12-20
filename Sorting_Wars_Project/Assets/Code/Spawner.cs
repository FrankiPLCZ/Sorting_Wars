using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    //=============================================================
    //Tworzy kostki i sortuje je w synchronizacji 
    //z ruchami postaci,dzwiek
    //============================================================
    //Reference to parent
    Parent parent;

    public GameObject obj;
    int comparison_count;
    public int amount;
    List<GameObject> lista;
    internal AudioSource audio;

    void Start()
    {
        parent = FindObjectOfType<Parent>();
        audio = FindObjectOfType<AudioSource>();
        //Przygotowanie zmiennych pod nowe sortowanie
        comparison_count = 0;
        parent.comparison_field.text = "Count: 00";
        parent.target.transform.position = new Vector3(-100, 0, 0);
        lista = new List<GameObject>();

        if (parent.dropdown.value == 0)
            StartCoroutine(BubbleSort());
        else if (parent.dropdown.value == 1)
            StartCoroutine(SelectionSort());
        else if (parent.dropdown.value == 2)
            StartCoroutine(InsertionSort());

        
    }

    private IEnumerator BubbleSort()
    {
        //Tworzymy kostki
        CreateObjects();
        //Centrujemy kamerê
        CenterCamera();

        GameObject x;
        Vector3 pos;
        for (int i = 0; i < lista.Count; i++)
        {
            LeanTween.color(lista[i], Color.red, .5f);
            for (int j = 0; j < lista.Count; j++)
            {
                if(i!=j)
                    LeanTween.color(lista[j], Color.blue, .5f);
                yield return new WaitForSeconds(1);
                if (int.Parse(lista[j].GetComponentInChildren<TextMeshPro>().text) > int.Parse(lista[i].GetComponentInChildren<TextMeshPro>().text))
                {
                    yield return Podejscie_do_celu(new Vector3((lista[i].transform.position.x + lista[j].transform.position.x) / 2 - 1.5f, lista[j].transform.position.y - 2, lista[j].transform.position.z));

                    x = lista[j];
                    pos = lista[j].transform.position;

                    LeanTween.moveLocalX(lista[j], lista[i].transform.position.x, 1);
                    LeanTween.moveLocalZ(lista[j], -3, .5f).setLoopPingPong(1);
                    LeanTween.moveLocalX(lista[i], pos.x, 1);
                    LeanTween.moveLocalZ(lista[i], 3, .5f).setLoopPingPong(1);
                    LeanTween.color(lista[j], Color.red, .5f);
                    LeanTween.color(lista[i], Color.black, .5f);

                    lista[j] = lista[i];
                    lista[i] = x;

                    yield return Powrot_na_miejsce();


                }
                else if(i!=j)
                    LeanTween.color(lista[j], Color.black, .5f);

                ComparisonAdd();
            }
            LeanTween.color(lista[i], Color.black, .5f);
        }

        Timer.finished = true;
    }

    private IEnumerator SelectionSort() {

        //Tworzymy kostki
        CreateObjects();
        //Centrujemy kamerê 
        CenterCamera();

        GameObject x;
        Vector3 pos;
        int min;
        for (int i = 0; i < lista.Count; i++) 
        {

            LeanTween.color(lista[i], Color.red, .5f);
            min = i;
            for (int j = i + 1; j < lista.Count; j++) {

                LeanTween.color(lista[j], Color.blue, .5f);
                yield return new WaitForSeconds(1);

                if (int.Parse(lista[j].GetComponentInChildren<TextMeshPro>().text) < int.Parse(lista[min].GetComponentInChildren<TextMeshPro>().text))
                {
                    if(min!=i)
                        LeanTween.color(lista[min], Color.black, .5f);

                    min = j;
                    LeanTween.color(lista[min], Color.green, .5f);

                }
                else
                    LeanTween.color(lista[j], Color.black, .5f);

                ComparisonAdd();
            }    

            if (min != i) {

                yield return Podejscie_do_celu(new Vector3((lista[i].transform.position.x + lista[min].transform.position.x) / 2 - 1.5f, lista[min].transform.position.y - 2, lista[min].transform.position.z));

                x = lista[i];
                pos = lista[min].transform.position;

                LeanTween.moveLocalX(lista[min], lista[i].transform.position.x, 1);
                LeanTween.moveLocalZ(lista[min], -3, .5f).setLoopPingPong(1);
                LeanTween.moveLocalX(lista[i], pos.x, 1);
                LeanTween.moveLocalZ(lista[i], 3, .5f).setLoopPingPong(1);
                LeanTween.color(lista[i], Color.black, .5f);

                lista[i] = lista[min];
                lista[min] = x;

                yield return Powrot_na_miejsce();
            }
            else
                LeanTween.color(lista[i], Color.green, .5f);
        }

        yield return new WaitForSeconds(1);
        Timer.finished = true;
    }

    private IEnumerator InsertionSort()
    {
        //Tworzymy kostki
        CreateObjects();
        //Centrujemy kamerê
        CenterCamera();

        GameObject x;
        Vector3 pos;
        bool zmiana;
        for (int i = 1; i < lista.Count; i++)
        {
            zmiana = false;
            x = lista[i];
            pos = x.transform.position;
            int j = i - 1;
            GameObject test = new GameObject("test");
            test.transform.SetParent(this.transform);

            LeanTween.color(lista[i], Color.red, .5f);

            yield return new WaitForSeconds(1);
            while (j >= 0 && int.Parse(lista[j].GetComponentInChildren<TextMeshPro>().text) > int.Parse(x.GetComponentInChildren<TextMeshPro>().text))
            {
                LeanTween.color(lista[j], Color.blue, .5f);
                yield return Podejscie_do_celu(new Vector3((lista[i].transform.position.x + lista[j].transform.position.x) / 2 - 1.5f, lista[j].transform.position.y - 2, lista[j].transform.position.z));
                pos = lista[j].transform.position;
                LeanTween.moveLocalX(lista[j], lista[j].transform.position.x + 1.5f, 1);
                LeanTween.moveY(lista[j], 6, 1);
                yield return new WaitForSeconds(1);
                LeanTween.color(lista[j], Color.black, .5f);

                lista[j + 1] = lista[j];

                lista[j].transform.SetParent(test.transform);
                j--;
                zmiana = true;

                yield return Powrot_na_miejsce();

                ComparisonAdd();

            }
            if (zmiana)

            {   //Animacja
                yield return Podejscie_do_celu(new Vector3((x.transform.position.x + lista[j + 1].transform.position.x) / 2 - 3, lista[j + 1].transform.position.y - 3, lista[j + 1].transform.position.z));

                LeanTween.moveLocalX(x, pos.x, 1);
                LeanTween.moveY(x, 6, 1);
                LeanTween.color(x, Color.black, .5f);

                yield return Powrot_na_miejsce();
                yield return Podejscie_do_celu(new Vector3((x.transform.position.x + lista[j + 1].transform.position.x) / 2 - 1.5f, lista[j + 1].transform.position.y - 3, lista[j + 1].transform.position.z));

                //Przesuniêcie grupy
                lista[j + 1] = x;
                x.transform.SetParent(test.transform);
                foreach (Transform child in test.GetComponentsInChildren<Transform>())
                    LeanTween.color(child.gameObject, Color.yellow, .5f);

                LeanTween.moveLocalY(test, -6, 1);
                yield return new WaitForSeconds(1);

                foreach (Transform child in test.GetComponentsInChildren<Transform>())
                    LeanTween.color(child.gameObject, Color.black, .5f);

                //Animacja
                yield return Powrot_na_miejsce();

            }
            else
            {
                LeanTween.color(x, Color.black, .5f);
            }
                

        }
        Timer.finished = true;
    }

    private void CreateObjects()
    {
        Vector3 temp = new Vector3(1.5f, 0, 0);
        Vector3 tempx = temp;

        for (int i = 0; i < amount; i++)
        {
            GameObject new_obj = Instantiate(obj);
            new_obj.transform.SetParent(gameObject.transform);
            new_obj.transform.localPosition = temp;
            temp = temp + tempx;
            new_obj.GetComponentInChildren<TextMeshPro>().text = Random.Range(0, 100).ToString();
            lista.Add(new_obj);

        }
    }

    private IEnumerator Powrot_na_miejsce()
    {
        //czeka na koniec animacji
        yield return new WaitUntil(() => !parent.ai_script.onpoint);

        //powrót na miejsce
        parent.target.transform.position = new Vector3(lista.Count / 2f + .95f, parent.cam.transform.position.y, parent.cam.transform.position.z + 40);
        yield return new WaitUntil(() => parent.ai_script.onpoint);

        //obrót w tyl
        parent.target.transform.position = new Vector3(lista.Count / 2f + .95f, parent.cam.transform.position.y, parent.cam.transform.position.z + 30);
        yield return new WaitUntil(() => parent.ai_script.onpoint);

        yield return new WaitForSeconds(1);


    }

    private IEnumerator Podejscie_do_celu(Vector3 vc3)
    {
        parent.target.transform.position = vc3;
        yield return new WaitUntil(() => parent.ai_script.onpoint);
        audio.Play();
    }

    private void ComparisonAdd() 
    {
        comparison_count++;
        if(comparison_count<10)
            parent.comparison_field.text = "Count: 0" + comparison_count.ToString();
        else
            parent.comparison_field.text = "Count: " + comparison_count.ToString();
    }

    private void CenterCamera()
    {
        parent.cam.transform.position = new Vector3(lista.Count * 1.5f / 2f - 1.5f, parent.cam.transform.position.y, parent.cam.transform.position.z);
    }
}
