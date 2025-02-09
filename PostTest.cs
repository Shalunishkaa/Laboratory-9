using Laboratory_9;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UnitTestProjectLab9
{
    [TestClass]
    public class PostTest
    {
        [TestMethod]
        public void PostConstructorWithoutParameters()
        {
            // Arrange

            // Act
            Post post = new Post();

            // Assert
            Assert.AreEqual(0, post.NumViews);
            Assert.AreEqual(0, post.NumComments);
            Assert.AreEqual(0, post.NumReactions);
        }

        [TestMethod]
        public void PostConstructorWithParameters()
        {
            // Arrange
            int views = 100;
            int comments = 20;
            int reactions = 5;

            // Act
            Post post = new Post(views, comments, reactions);

            // Assert
            Assert.AreEqual(views, post.NumViews);
            Assert.AreEqual(comments, post.NumComments);
            Assert.AreEqual(reactions, post.NumReactions);
        }

        [TestMethod]
        public void CalculateEngagementRateStatic()
        {
            // Arrange
            Post post = new Post(500, 50, 25);
            double expectedEngagement = Math.Round((double)(500 + 50 + 25) / 1000 * 100, 2);

            // Act
            double actualEngagement = Post.CalculateEngagementRate(post, 1000);

            // Assert
            Assert.AreEqual(expectedEngagement, actualEngagement);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CalculateEngagementRateStaticWithZeroSubs()
        {
            Post post = new Post(500, 50, 25);
            double engagement = Post.CalculateEngagementRate(post, 0);
        }

        [TestMethod]
        public void CalculateEngagementRateMethod()
        {
            // Arrange
            Post post = new Post(500, 50, 25);
            double expectedEngagement = Math.Round((double)(500 + 50 + 25) / 1000 * 100, 2);

            // Act
            double actualEngagement = post.CalculateEngagementRate(1000);

            // Assert
            Assert.AreEqual(expectedEngagement, actualEngagement);
        }

        [TestMethod]
        public void Calculate100EngagementRateMethod()
        {
            // Arrange
            Post post = new Post(500, 50, 25);
            double expectedEngagement = 100;

            // Act
            double actualEngagement = post.CalculateEngagementRate(500);

            // Assert
            Assert.AreEqual(expectedEngagement, actualEngagement);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CalculateEngagementRateMethodWithZeroSubs()
        {
            Post post = new Post(500, 50, 25);
            double engagement = post.CalculateEngagementRate(0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CalculateEngagementRateMethodWithNegativeViews()
        {
            Post post = new Post(-500, 50, 25);
            double engagement = post.CalculateEngagementRate(1000);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CalculateEngagementRateMethodWithNegativeComments()
        {
            Post post = new Post(500, -50, 25);
            double engagement = post.CalculateEngagementRate(1000);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CalculateEngagementRateMethodWithNegativeReactions()
        {
            Post post = new Post(500, 50, -25);
            double engagement = post.CalculateEngagementRate(1000);
        }

        [TestMethod]
        public void EqualsEqualObjectsReturnsTrue()
        {
            // Arrange
            Post post1 = new Post(100, 20, 5);
            Post post2 = new Post(100, 20, 5);

            // Act
            bool result = post1.Equals(post2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EqualsDifferentObjectsReturnsFalse()
        {
            // Arrange
            Post post1 = new Post(100, 20, 5);
            Post post2 = new Post(50, 10, 2);

            // Act
            bool result = post1.Equals(post2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EqualsNullObjectReturnsFalse()
        {
            // Arrange
            Post post1 = new Post(100, 20, 5);

            // Act
            bool result = post1.Equals(null);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetHashCodeEqualObjectsReturnsSameHashCode()
        {
            // Arrange
            Post post1 = new Post(100, 20, 5);
            Post post2 = new Post(100, 20, 5);

            // Act
            int hashCode1 = post1.GetHashCode();
            int hashCode2 = post2.GetHashCode();

            // Assert
            Assert.AreEqual(hashCode1, hashCode2);
        }

        [TestMethod]
        public void GetHashCodeDifferentObjectsReturnsDifferentHashCode()
        {
            // Arrange
            Post post1 = new Post(100, 20, 5);
            Post post2 = new Post(50, 10, 2);

            // Act
            int hashCode1 = post1.GetHashCode();
            int hashCode2 = post2.GetHashCode();

            // Assert
            Assert.AreNotEqual(hashCode1, hashCode2);
        }

        [TestMethod]
        public void OperatorNotEqualsEqualObjectsReturnsFalse()
        {
            // Arrange
            Post post1 = new Post(100, 20, 5);
            Post post2 = new Post(100, 20, 5);

            // Act
            bool result = (post1 != post2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void OperatorNotEqualsDifferentObjectsReturnsTrue()
        {
            // Arrange
            Post post1 = new Post(100, 20, 5);
            Post post2 = new Post(50, 10, 2);

            // Act
            bool result = (post1 != post2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OperatorDenial()
        {
            // Arrange
            Post post1 = new Post(100, 20, 5);
            Post post2 = new Post(100, 20, 6);

            // Act
            post1 = !post1;

            // Assert
            Assert.AreEqual(post1, post2);
        }

        [TestMethod]
        public void OperatorIncrement()
        {
            // Arrange
            Post post1 = new Post(100, 20, 5);
            Post post2 = new Post(101, 20, 5);

            // Act
            post1 = ++post1;

            // Assert
            Assert.AreEqual(post1, post2);
        }
    }
}
