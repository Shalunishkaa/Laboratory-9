using Laboratory_9;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProjectLab9
{
    [TestClass]
    public class PostArrayTest
    {
        [TestMethod]
        public void PostArrayConstructorWithoutParameters()
        {
            // Arrange

            // Act
            PostArray array = new PostArray();

            // Assert
            Assert.AreEqual(0, array.Length);
        }

        [TestMethod]
        public void PostArrayConstructorWithParameters()
        {
            // Arrange
            int size = 5;

            // Act
            PostArray array = new PostArray(size);

            // Assert
            Assert.AreEqual(size, array.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void IndexerGetIndexOutOfRangeThrowsException()
        {
            PostArray array = new PostArray(3);
            Post post = array[5]; // Выход за границы массива
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Indexer_Set_IndexOutOfRange_ThrowsException()
        {
            PostArray array = new PostArray(3);
            array[5] = new Post(); // Выход за границы массива
        }

        [TestMethod]
        public void IndexerGetValidIndexReturnsCorrectValue()
        {
            // Arrange
            PostArray array = new PostArray(3);
            Post expectedPost = new Post(100, 20, 5);
            array[0] = expectedPost;

            // Act
            Post actualPost = array[0];

            // Assert
            Assert.AreEqual(expectedPost, actualPost);
        }

        [TestMethod]
        public void DeepCopyModifyingOriginal()
        {
            // Arrange
            PostArray original = new PostArray(1);
            original[0] = new Post(100, 20, 5);
            PostArray copy = new PostArray(original);

            // Act
            original[0].NumViews = 500;

            // Assert
            Assert.AreNotEqual(original[0].NumViews, copy[0].NumViews);
        }
    }
}
