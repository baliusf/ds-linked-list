using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2
{
  public partial class StockList
  {
    //param   (StockList)listToMerge : second list to be merged 
    //summary      : merge two different list into a single result list
    //return       : merged list
    //return type  : StockList
    public StockList MergeList(StockList listToMerge)
    {
            // The Stock node objects first, current and previous are used to store the 
            // head node, active node and the prior node informations
            StockList resultList = new StockList();
            StockNode first = null, current = null, previous = null;
            StockNode priNode = this.head;
            StockNode secNode = listToMerge.head;
            // The below logic progressively iterates through both the lists and stores the nodes in
            // sorted order. For ideal nodes, the holdings attribute is summed
            // This while loop iterates until all the nodes in the primary list are encountered
            while (priNode != null)
            {
                if (secNode != null && priNode.StockHolding.Name.CompareTo(secNode.StockHolding.Name) == 0)
                {
                    decimal updateHoldings = priNode.StockHolding.Holdings + secNode.StockHolding.Holdings;
                    priNode.StockHolding.Holdings = updateHoldings;
                    current = priNode;
                    priNode = priNode.Next;
                    secNode = secNode.Next;
                }
                else if (secNode != null && priNode.StockHolding.Name.CompareTo(secNode.StockHolding.Name) > 0)
                {
                    current = secNode;
                    secNode = secNode.Next;
                }
                else
                {
                    current = priNode;
                    priNode = priNode.Next;
                }
                // 'first' is used to store the head node
                if (first == null)
                    first = current;
                // Except for the first iteration, 'previous' is used to store the prior node information
                if (previous != null)
                    previous.Next = current;
                previous = current;
            }
            // This while loop handles the uniterated nodes in the listToMerge
            while (secNode != null)
            {
                current = secNode;
                if (first == null)
                    first = current;
                if (previous != null)
                    previous.Next = current;
                secNode = secNode.Next;
            }
            resultList.head = first;
            return resultList;
        }

    //param        : NA
    //summary      : finds the stock with most number of holdings
    //return       : stock with most shares
    //return type  : Stock
    public Stock MostShares()
    {
      Stock mostShareStock = null;
      StockNode active = this.head;
            decimal highHoldings = 0;
            while (active != null)
            {
                if (active.StockHolding.Holdings > highHoldings)
                {
                    // Holdings count is compared with preious values and the highest value is retained
                    highHoldings = active.StockHolding.Holdings;
                    mostShareStock = active.StockHolding;
                }
                active = active.Next;
            }
      return mostShareStock;
    }

        //param        : NA
        //summary      : finds the number of nodes present in the list
        //return       : length of list
        //return type  : int
    public int Length()
    {
        int length = 0;
        StockNode temp = this.head;
        // For each iteration until a node is present in the StockNode, the count is increased by one
        while (temp != null)
        {
            length++;
            temp = temp.Next;
        }
        return length;
    }      
  }
}