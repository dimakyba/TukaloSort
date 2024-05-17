using System;
using System.Text;

namespace TukaloSort
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.OutputEncoding = UTF8Encoding.UTF8;
      Console.WriteLine("TukaloSort v0.01\n");
      int money = 1000;
      int krutkaCounter = 0;
      const double probability = 0.07;
      const int krutkaPrice = 50;
      Random rnd = new Random();
      Console.WriteLine("масів:");
      int[] massiv = [5, 6, 2, 5, 7, 1, -5, 2, 4, 9];
      PrintMassiv(massiv);

      while (money > 0)
      {
        Console.WriteLine($"осталось денег: {money}");
        Console.WriteLine($"количество сделаніх круток: {krutkaCounter}");
        Console.WriteLine($"ціна крутки: {krutkaPrice}");
        Console.WriteLine($"скільки ти проєбав на крутках: {krutkaCounter * krutkaPrice}");
        Console.WriteLine("шоб зробить крутку нажміть ентер");
        Console.ReadLine();
        money -= krutkaPrice;
        krutkaCounter++;
        double rndNumber = rnd.NextDouble();
        if (rndNumber < probability)
        {
          Console.WriteLine("Вітаю, ти виграв можливість відсортувати масив)) тримай!");
          OptimisedXrapovSort(ref massiv);
          PrintMassiv(massiv);
          Console.WriteLine();
        }
        else
        {
          Console.WriteLine("сорі невезуха, некст тайм повезе)\n");
        }
      }
      Console.WriteLine("у тебе кончились бабки, лошара. задонать і приходь ще))");
    }

    static void OptimisedXrapovSort(ref int[] massiv)
    {
      int[] poison = GetPoison(massiv);
      int[] poisonedMassiv = FoodPoisoning(massiv, poison);
      SoapSort(ref poisonedMassiv);
      massiv = FilterMassiv(poisonedMassiv, poison);
    }

    static int[] GetPoison(int[] massiv)
    {
      int min = GetMin(massiv);
      int max = GetMax(massiv);

      int[] poison = new int[massiv.Length];

      Random rnd = new Random();
      int counter = 0;

      while (counter < poison.Length)
      {
        int rndTemp = rnd.Next(min, max + 1);

        if (!massiv.Contains(rndTemp))
        {
          poison[counter] = rndTemp;
          counter++;
        }

      }

      return poison;
    }

    static int[] FoodPoisoning(int[] massiv, int[] shit)
    {
      Random rnd = new Random();

      int prob = 0;
      int cleanCounter = 0;
      int poisonCounter = 0;

      int[] poisonedmassiv = new int[massiv.Length * 2];
      for (int i = 0; i < poisonedmassiv.Length; i++)
      {
        prob = rnd.Next(0, 101);
        if (prob > 50)
        {

          poisonedmassiv[i] = massiv[cleanCounter];
          cleanCounter++;
          if (cleanCounter == 9)
          {
            cleanCounter = 0;
          }
        }
        else
        {

          poisonedmassiv[i] = shit[poisonCounter];
          poisonCounter++;

        }
        if (poisonCounter == 9)
        {
          poisonCounter = 0;
        }
      }
      // counter++;

      return poisonedmassiv;
    }


    static int[] FilterMassiv(int[] poisonedmassiv, int[] poison)
    {
      int[] filterredmassiv = new int[poisonedmassiv.Length / 2];
      int counter = 0;
      for (int i = 0; i < poisonedmassiv.Length; i++)
      {
        if (!poison.Contains(poisonedmassiv[i]))
        {
          filterredmassiv[counter] = poisonedmassiv[i];
          counter++;
        }
      }
      return filterredmassiv;
    }

    static void SoapSort(ref int[] arr)
    {
      int n = arr.Length;
      int i, j, temp;
      bool swapped;
      for (i = 0; i < n - 1; i++)
      {
        swapped = false;

        for (j = 0; j < n - i - 1; j++)
        {
          if (arr[j] > arr[j + 1])
          {
            temp = arr[j];
            arr[j] = arr[j + 1];
            arr[j + 1] = temp;
            swapped = true;
          }
        }

        if (swapped == false)
          break;
      }
    }
    static int GetMin(int[] massiv)
    {
      int min = int.MaxValue;
      foreach (int el in massiv)
      {
        if (el < min)
        {
          min = el;
        }
      }

      return min;
    }

    static int GetMax(int[] massiv)
    {
      int max = int.MinValue;
      foreach (int el in massiv)
      {
        if (el > max)
        {
          max = el;
        }
      }

      return max;
    }

    static void PrintMassiv(int[] massiv)
    {
      foreach (var el in massiv)
      {
        Console.Write($"{el} ");
      }
      Console.WriteLine();
    }

  }
}
