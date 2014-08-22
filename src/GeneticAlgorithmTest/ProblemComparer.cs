﻿using System.Collections.Generic;

namespace GeneticAlgorithmTest
{
    public class ProblemComparer : IEqualityComparer<Unit>
    {
        public bool Equals(Unit x, Unit y) {
            var result = true;
            for (var i = 0; i < x.ProblemList.Count; i++) {
                if (x.ProblemList[i].ID != y.ProblemList[i].ID) {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public int GetHashCode(Unit obj) {
            return obj.ToString().GetHashCode();
        }
    }
}