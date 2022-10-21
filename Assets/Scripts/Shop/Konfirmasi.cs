using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class Konfirmasi : MonoBehaviour
{
    public Item item1;
    public Item item2;
    public Item item3;

    public GameObject limitItem1;
    public GameObject limitItem2;
    public GameObject limitItem3;

    private int itemTerpilih = 0;
    private bool isClickYes = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isClickYes){
            pilihan();

            isClickYes = true;
            itemTerpilih = 0;
        }
    }

    public void desicion(int value){
        itemTerpilih = value;
    }

    int first = 0;
    public void sudahDiklik(bool sudah){
        isClickYes = !isClickYes;
        if(first==0){
            pilihan();
            first = 1;
        }
    }

    void pilihan(){
        if(itemTerpilih==1){
                //Debug.Log("item1");

                limitItem1.GetComponent<Text>().text = "Limit Item: 0";
                InventoryManager.Instance.Add(item1);
            }
            else if(itemTerpilih==2){
                //Debug.Log("item2");
                limitItem2.GetComponent<Text>().text = "Limit Item: 0";
                InventoryManager.Instance.Add(item2);
            }
            else if(itemTerpilih==3){
                //Debug.Log("item3");
                limitItem3.GetComponent<Text>().text = "Limit Item: 0";
                InventoryManager.Instance.Add(item3);
            }
    }
}
