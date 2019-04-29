using System;
using System.Collections.Generic;
using System.Linq;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes
{
    public class GameBoard<_Type> where  _Type : IAnimal
    {
        public GameBoard(IEnumerable<IAnimal> animals)
        {
            Animals = animals.ToList();
        }

        public List<IAnimal> Animals { get; set; }

        public string[] MoveAnimals()
        {
            List<string> result = new List<string>();
            foreach(var a in Animals)
            {
                result.Add(a.Move(Environment.Air));
                result.Add(a.Move(Environment.Land));
                result.Add(a.Move(Environment.Watery));
            }

            return result.ToArray();
        }
    }
}