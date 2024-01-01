using DataStructures.Implementations.DataStructures;

namespace Algorithms.Test
{
    public class UnitTest1
    {
        private readonly string valueA = "A";
        private readonly string valueB = "B";
        private readonly string valueC = "C";
        private CustomLinkedList<string> list;

        [Fact]
        public void List_Test_Clear() 
        {
            list = new CustomLinkedList<string>();

            list.Add(valueA);

            list.Clear();   

            Assert.Empty(list);
        }

		[Fact]
        public void List_MustBe_Empty()
        {
            this.list = new CustomLinkedList<string>();

            Assert.Empty(list);
        }

        [Theory]
        [InlineData("A", "B", "C")]
        [InlineData("2", "3", "2")]
        [InlineData("C", "C", "C")]
		public void List_MustHaveCorrectValues(params string[] elements)
		{
			this.list = new CustomLinkedList<string>();

            foreach (var element in elements) list.Add(element);

            Assert.True(list.Get(0) == elements[0] && list.Get(1) == elements[1]  && list.Get(2) == elements[2]);
		}

        [Theory]
        [InlineData("A", "B", "C")]
        public void List_Testing_Delete(params string[] elements) 
        {
			this.list = new CustomLinkedList<string>();

			foreach (var element in elements) list.Add(element);
		}
	}
}