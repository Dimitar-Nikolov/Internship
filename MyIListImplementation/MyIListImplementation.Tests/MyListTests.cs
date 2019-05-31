using MyIListImplementation.Models;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Tests
{
    public class MyListTests
    {
        protected MyList<int> intList;

        // TODO
        // Reason testing stringList
        // Reason variables in test methods
        // Draw a line what is worth testing
        // Reason use of other test object methods inside test methods (Add in Remove method Tests)
        // Reason Testing methods based entirely on microsft or other tested libraries
        [SetUp]
        public void Setup()
        {
            this.intList = new MyList<int>();
        }

        [Test]
        public void Constructor_ListSizeIsZero_ListCountZero()
        {
            Assert.That(this.intList, Has.Count.EqualTo(0));
        }

        [Test]
        public void Setter_SetItemToNonexistentIndex_ThrowsMyListIndexException()
        {
            Assert.That(() => this.intList[1] = 5,
                Throws.Exception.With.Message.EqualTo("Index was outside the bounds of the MyList"));
        }

        [Test]
        public void Setter_SetItemToNegativeIndex_ThrowsMyListIndexException()
        {
            Assert.That(() => this.intList[1] = 5,
                Throws.Exception.With.Message.EqualTo("Index was outside the bounds of the MyList"));
        }

        [Test]
        public void Setter_SetItemToExistingIndex_ItemIsSet()
        {
            this.intList.Add(1);

            this.intList[0] = 5;

            Assert.That(this.intList[0], Is.EqualTo(5));
        }

        [Test]
        public void Getter_GetNonexistentIndexItem_ThrowsMyListIndexException()
        {
            Assert.That(() => this.intList[1],
                Throws.Exception.With.Message.EqualTo("Index was outside the bounds of the MyList"));
        }

        [Test]
        public void Getter_GetNegativeIndexItem_ThrowsMyListIndexException()
        {
            Assert.That(() => this.intList[1],
                Throws.Exception.With.Message.EqualTo("Index was outside the bounds of the MyList"));
        }

        [Test]
        public void Count_IncreaseSizeByOne_SizeIncreased()
        {
            var initialSize = this.intList.Count;

            this.intList.Add(0);

            Assert.That(intList.Count, Is.EqualTo(initialSize + 1));
        }

        [Test]
        public void Count_DecreaseSizeByTwo_CountDecreased()
        {
            this.intList.Add(0);
            this.intList.Add(1);

            var initialSize = this.intList.Count;

            this.intList.Remove(0);
            this.intList.Remove(1);


            Assert.That(intList.Count, Is.EqualTo(initialSize - 2));
        }

        [Test]
        public void Add_AddElementToList_ElementAtEndOfMyList()
        {
            int insertItem = 1;

            this.intList.Add(0);
            this.intList.Add(insertItem);

            Assert.That(this.intList[intList.Count - 1], Is.EqualTo(insertItem));
        }

        [Test]
        public void Clear_ClearMyListFromElements_MyListCountIsZero()
        {
            this.intList.Add(0);

            this.intList.Clear();

            Assert.That(this.intList.Count, Is.EqualTo(0));
        }

        [Test]
        public void Contains_CheckForExistingItem_ItemExists()
        {
            this.intList.Add(0);

            Assert.That(this.intList.Contains(0), Is.EqualTo(true));
        }

        [Test]
        public void Contains_CheckForExistingItem_ItemNotFound()
        {
            this.intList.Add(0);

            Assert.That(this.intList.Contains(1), Is.EqualTo(false));
        }

        [Test]
        public void CopyTo_CopyMyListToArray_Copied()
        {
            this.intList.Add(0);

            int[] ints = new int[this.intList.Count];

            this.intList.CopyTo(ints, 0);

            Assert.That(ints[0], Is.EqualTo(this.intList[0]));
        }

        [Test]
        public void CopyTo_CopyMyListToShorterArray_Exception()
        {
            this.intList.Add(0);

            int[] ints = new int[this.intList.Count - 1];

            Assert.That(() => this.intList.CopyTo(ints, 0),
                Throws.ArgumentException);
        }

        [Test]
        public void CopyTo_CopyMyListToInvalidArrayIndex_Exception()
        {
            this.intList.Add(0);
            this.intList.Add(0);

            int[] ints = new int[this.intList.Count];

            Assert.That(() => this.intList.CopyTo(ints, 1),
                    Throws.ArgumentException);
        }

        [Test]
        public void IndexOf_ExistingItem_IndexFound()
        {
            this.intList.Add(5);

            Assert.That(this.intList.IndexOf(5), Is.EqualTo(0));
        }

        [Test]
        public void IndexOf_ExistingItem_FirstIndexFound()
        {
            this.intList.Add(5);
            this.intList.Add(5);
            Assert.That(this.intList.IndexOf(5), Is.EqualTo(0));
        }

        [Test]
        public void IndexOf_NonexistentItem_IndexNotFound()
        {
            this.intList.Add(5);

            Assert.That(this.intList.IndexOf(3), Is.EqualTo(-1));
        }

        [Test]
        public void Insert_InsertToNonexistent_ThrowsException()
        {
            Assert.That(() => this.intList.Insert(0, 0)
            , Throws.Exception.With.Message
            .EqualTo("Index was outside the bounds of the MyList"));
        }

        [Test]
        public void Insert_InsertToValidIndex_ItemInsertedToCorrectIndex()
        {
            this.intList.Add(1);
            this.intList.Add(3);

            this.intList.Insert(0, 2);

            Assert.That(this.intList[0], Is.EqualTo(2));
        }

        [Test]
        public void Insert_InsertItem_NewListCorrectlyContainsTheItem()
        {
            this.intList.Add(0);
            this.intList.Add(2);

            this.intList.Insert(1, 1);

            bool isEqual = true;

            for (int i = 0; i < this.intList.Count; i++)
            {
                if (this.intList[i] != i)
                {
                    isEqual = false;
                }
            }

            Assert.IsTrue(isEqual);
        }

        [Test]
        public void Remove_RemoveNonexistentItem_False()
        {
            Assert.IsFalse(this.intList.Remove(0));
        }

        [Test]
        public void Remove_RemoveExistingItem_True()
        {
            this.intList.Add(0);

            Assert.IsTrue(this.intList.Remove(0));
        }
    }
}