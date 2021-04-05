using System;
using FluentAssertions;
using Xunit;

namespace Stack.Test
{
    public class MyStackTests
    {
        public MyStackTests()
        {
            myStack = new MyStack(RootValue);
        }

        private MyStack myStack;
        private const int RootValue = 5;

        [Theory]
        [InlineData(5)]
        public void Init_ShouldSetCountToOne(int value)
        {
            myStack = new MyStack(value);

            myStack.Root.Value.Should().Be(value);
        }

        [Theory]
        [InlineData(2, 3)]
        public void Push_WithTwoElements_ShouldSetCountToThree(int firstNodeValue, int secondNodeValue)
        {
            myStack.Push(firstNodeValue);
            myStack.Push(secondNodeValue);

            myStack.Count.Should().Be(3);
        }

        [Theory]
        [InlineData(2, 3)]
        public void Peek_ShouldReturnLastElementWithoutRemovingIt(int firstNodeValue, int secondNodeValue)
        {
            myStack.Push(firstNodeValue);
            myStack.Push(secondNodeValue);

            var poppedElement = myStack.Peek();

            poppedElement.Value.Should().Be(secondNodeValue);
            myStack.Count.Should().Be(3);
        }

        [Fact]
        public void Peek_WithOnlyOneElementOnStack_ShouldNotChangeTheCount()
        {
            var result = myStack.Peek();

            result.Value.Should().Be(RootValue);
            myStack.Count.Should().Be(1);
        }

        [Fact]
        public void Peek_OnEmptyStack_ShouldThrowException()
        {
            myStack.Pop();
            myStack.Invoking(_ => _.Peek()).Should().Throw<InvalidOperationException>();
        }

        [Theory]
        [InlineData(2, 3)]
        public void Pop_ShouldReturnLastElementAndRemoveIt(int firstNodeValue, int secondNodeValue)
        {
            myStack.Push(firstNodeValue);
            myStack.Push(secondNodeValue);

            var poppedElement = myStack.Pop();

            poppedElement.Value.Should().Be(secondNodeValue);
            myStack.Count.Should().Be(2);
        }

        [Fact]
        public void Pop_WithOnlyOneElementOnStack_ShouldSetTheCountToZero()
        {
            var poppedElement = myStack.Pop();

            poppedElement.Value.Should().Be(RootValue);
            myStack.Count.Should().Be(0);
        }

        [Fact]
        public void Pop_OnEmptyStack_ShouldThrowException()
        {
            myStack.Pop();
            myStack.Invoking(_ => _.Pop()).Should().Throw<InvalidOperationException>();
        }
    }
}