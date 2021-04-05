using System;
using FluentAssertions;
using Xunit;

namespace Queue.Test
{
    public class MyQueueTests
    {
        private readonly MyQueue myQueue;
        private const string firstValue = "5";

        public MyQueueTests()
        {
            myQueue = new MyQueue(firstValue);
        }

        [Fact]
        public void Init_ShouldCreateAQueueWithOneElement()
        {
            var testee = new MyQueue("5");

            testee.Count.Should().Be(1);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        public void Enqueue_ShouldIncreaseCountByOnePlusEnteredAmountOfElements(int amountOfElements)
        {
            for (int i = 0; i < amountOfElements; i++)
            {
                myQueue.Enqueue(i);
            }

            myQueue.Count.Should().Be(amountOfElements + 1);
        }

        [Fact]
        public void Dequeue_ShouldReturnFristElementAndRemoveIt()
        {
            var result = myQueue.Dequeue();
            var reducedQueueCount = myQueue.Count;

            reducedQueueCount.Should().Be(0);
            result.Should().BeEquivalentTo(firstValue);
        }

        [Fact]
        public void Dequeue_WhenQueueIsEmpty_ShouldThrowInvalidOperationException()
        {
            myQueue.Dequeue();

            myQueue.Invoking(_ => _.Dequeue()).Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Peek_ShouldReturnFirstElementButNotRemoveIt()
        {
            var result = myQueue.Peek();

            myQueue.Count.Should().Be(1);
            result.Should().BeEquivalentTo(firstValue);
        }

        [Fact]
        public void Peek_WhenQueueIsEmpty_ShouldThrowInvalidOperationException()
        {
            myQueue.Dequeue();

            myQueue.Invoking(_ => _.Peek()).Should().Throw<InvalidOperationException>();
        }
    }
}
