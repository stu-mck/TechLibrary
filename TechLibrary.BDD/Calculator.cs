using System;
using System.Collections.Generic;

namespace TechLibrary.BDD
{
    internal class Calculator
    {
        private Stack<int> _operands = new Stack<int>();
        private int _result;
        public Calculator()
        {
        }

        internal void Enter(int p0)
        {
            _operands.Push(p0);
        }

        internal void Add()
        {
            _result += _operands.Pop();
            _result += _operands.Pop();
        }

        internal int Result()
        {
            return _result;
        }
    }
}