using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2
{
  public partial class StockList
  {
    //param        : NA
    //summary      : Calculate the value of each node by multiplying holdings with price, and returns the total value
    //return       : total value
    //return type  : decimal
    public decimal Value()
    {
      decimal value = 0.0m;
      StockNode temp = this.head;
      //Calculating the total value by multiplying number of holdings with cuttent value of share
      while (temp != null)
      {
             value = value + temp.StockHolding.Holdings * temp.StockHolding.CurrentPrice;
             temp = temp.Next;
      }
      return value;
    }

    //param  (StockList) listToCompare     : StockList which has to comared for similarity index
    //summary      : finds the similar number of nodes between two lists
    //return       : similarty index
    //return type  : int
    public int Similarity(StockList listToCompare)
    {
      int similarityIndex = 0;
      //Initializing two variables temp and temp1 to head of client 1 and 2 portfolio respectively 
      StockNode temp = head;
      StockNode temp1 = listToCompare.head;
      //Outer loop to traverse through client 1 portfoli0
      while (temp != null)
      {
                temp1 = listToCompare.head;
                //Inner loop to traverse through client 2 portfoli0
                while (temp1 != null)
                {
                    if (temp.StockHolding.Symbol == temp1.StockHolding.Symbol) 
                    {
                        similarityIndex++;
                    }
                    temp1 = temp1.Next;
                }
                temp = temp.Next;         
      }
      return similarityIndex;
    }

    //param        : NA
    //summary      : Print all the nodes present in the list
    //return       : NA
    //return type  : NA
    public void Print()
    {
            StockNode temp = this.head;
            //Displaying the client portfolios by calling ToString() method
            while (temp != null)
            {
                Console.WriteLine(temp.StockHolding.ToString());
                temp = temp.Next;
            }

        }
  }
}