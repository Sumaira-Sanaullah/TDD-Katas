using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Tree.Test
{
    public class MyTreeTests
    {
        public MyTreeTests()
        {
            myTree = new MyTree(FirstValue);
        }

        private readonly MyTree myTree;
        private const int FirstValue = 5;

        [Fact]
        public void Init_ShouldInitTreeWithOneValue()
        {
            myTree.Root.Value.Should().Be(FirstValue);
        }

        [Theory]
        [InlineData(3)]
        public void Insert_NumberSmallerThanFirstValue_ShouldSetLeftChild(int childValue)
        {
            myTree.Insert(childValue);

            myTree.Root.LeftChild.Value.Should().Be(childValue);
        }

        [Theory]
        [InlineData(7)]
        public void Insert_NumberGreaterThanFirstValue_ShouldSetRightChild(int childValue)
        {
            myTree.Insert(childValue);

            myTree.Root.RightChild.Value.Should().Be(childValue);
        }

        [Theory]
        [InlineData(new[] { 3, 1, 9, 7, 4, 8, 2 })]
        [InlineData(new[] { 4, 3, 2, 1, 6, 7, 8, 9, 10 })]
        public void Sort_ShoulReturnSortedList(int[] inputValues)
        {
            var output = new List<int>();

            foreach (var value in inputValues)
            {
                myTree.Insert(value);
            }

            MyTree.Sort(myTree.Root, output);

            output.Should().BeInAscendingOrder();
        }
    }
}