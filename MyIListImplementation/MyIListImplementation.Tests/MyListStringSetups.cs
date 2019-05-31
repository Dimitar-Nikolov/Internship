using MyIListImplementation.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Tests;

namespace MyIListImplementation.Tests
{
    public class MyListStringSetups : MyListTests
    {

        [SetUp]
        public void Setup()  
        {
            base.intList = new MyList<int>();
        }
    }
}
