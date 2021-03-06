﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class NoMatch : IMatch
    {
        private string current;
        private bool success = false;
        private int indexOfNoMatch;
        private string expected;

        public string Expected => expected;

        public bool Success => success;

        public int IndexOfNoMatch => indexOfNoMatch;

        public char CharOfNoMatch => current[indexOfNoMatch+1];


        public string Current
        {
            get => current;
            set => current = value;
        }

        public NoMatch(string noMatch = "", int index = 0) : this(noMatch, "", index) { }

        public NoMatch(string noMatch, string expected, int index)
        {
            Current = noMatch;
            indexOfNoMatch = index;
            this.expected = expected;
        }

        override public bool Equals(object toCompareWith)
        {
            NoMatch other = toCompareWith as NoMatch;

            if (other == null)
                return false;
            if (Current.ToString() == other.Current.ToString() && indexOfNoMatch == other.indexOfNoMatch)
                return true;

            return false;

        }

        public override string ToString()
        {
            return $"{current}<{indexOfNoMatch}>";
        }
    }
}
