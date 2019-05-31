using MyIListImplementation.Models;
using NUnit.Framework;
using Tests;

namespace MyIListImplementation.Tests
{
    public class MyListTestsStarter : MyListTests
    {
        [SetUp]
        public override void Setup()
        {
            base.intList = new MyList<int>();
        }
    }
}
