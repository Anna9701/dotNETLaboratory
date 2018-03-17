﻿using System;
using System.Collections.Generic;
using Laboratorium1.Exceptions;
using Laboratorium1.Implementations;
using Laboratorium1.Interfaces;
using Laboratorium1.Structs;

namespace Laboratorium1
{
    class Program
    {
        static void Main(string[] args)
        {
            uint maxToysNumber = 5;
            decimal maxToysValue = 5000000.50M;
            int incrementValue = 200;
            ToysSquareSample square = new ToysSquareSample(new ToysSquare(), maxToysNumber, maxToysValue);
            ICollection<IToy> toysList = GetOneExampleEachToyList();

            AddToysListToSquareSampleTest(square, toysList);
            SampleSquareTest(square);
            CreateAdditionalToysTest(square);
            IncrementPriceOfToysTest(toysList, incrementValue);

            Console.ReadKey();
            
        }

        static ICollection<IToy> GetOneExampleEachToyList()
        {
            ICollection<IToy> toysList = new LinkedList<IToy>();
            toysList.Add(Car.CreateSampleCar());
            toysList.Add(Plane.CreateSamplePlane());
            toysList.Add(Submarine.CreateSampleSubmarine());
            toysList.Add(Computer.CreateSampleComputer());

            return toysList;
        }

        static private void SampleSquareTest(ToysSquareSample square)
        {
            const int depth = 20;
            const int speed = 40;
            const int height = 30;
            square.PrintToysSquareState();
            square.ChangeToysParameters(depth, height, speed);
            square.PrintToysSquareState();
        }

        static private void AddToysListToSquareSampleTest(ToysSquareSample square, ICollection<IToy> toys)
        {
            foreach (IToy toy in toys)
            {
                square.AddToyToSquare(toy);
            }
        }

        static private void CreateAdditionalToysTest(ToysSquareSample square)
        {
            try
            {
                square.AddToyToSquare(Submarine.CreateSampleSubmarine());
                square.AddToyToSquare(Computer.CreateSampleComputer());
            } catch (ToysAmountExceedException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        static private void IncrementPriceOfToysTest(ICollection<IToy> toysList, decimal incrementValue)
        {
            try
            {
                foreach (IToy toy in toysList)
                {
                    toy.Value = GetNewValueIncrementedBy(toy.Value, incrementValue);
                }
            } catch (ValueExceedException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        static private Value GetNewValueIncrementedBy(Value currentValue, decimal incrementValue)
        {
            return new Value(currentValue.Price + incrementValue, currentValue.SentimentalPrice);
        }
    }

}



/*
 * struktura wartość, 2 pola (double, decimal), cena i wartośćSentymentalna, konstruktor, właściwości pozwalające na dostęp do pól i walidujące (przy zapisie) wartości: muszą byc nieujemne
 * 
 * klase bazową zabawka, mająca polew wartoscBazowa(typu Wartosc) oraz pole Wiek (typu double) z odpowiedniami metodami dostępowymi, a także pole WartoscAktualna, zwracającą wartosc wyliczona
 * na podsawie wartosci bazowej i wieku
 * 
 * w pokoju zabawek oraz klasie Zabawka utowrzyc zdarzenia, wywoływanie odpowiednio: w przypadku zwiększenia liczby zabawek w pokoju, w przypadku zwiekszenia wartosci. Użć zdarzen do
 * reagowania na sytuacje, gdy wartosc zabawek w pokoju przekroczy okresloną wartość
 * 
 * set in toy powinien sygnalizowac zdarzenie
 * add w toys square powinien sygnalziwoac zdarzenie
 * toys square powinien odbierac zdarzenie i reagowac na przekroczenie wartosci
 */