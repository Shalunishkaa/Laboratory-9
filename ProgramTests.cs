using Laboratory_9;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UnitTestProjectLab9
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void CalculateTotalEngagementEmptyArray()
        {
            // Arrange
            PostArray emptyArray = new PostArray();

            // Act
            double totalEngagement = Program.CalculateTotalEngagementRate(emptyArray);

            // Assert
            Assert.AreEqual(0, totalEngagement);
        }

        [TestMethod]
        public void CalculateTotalEngagementSinglePost()
        {
            // Arrange
            PostArray array = new PostArray(1);
            array[0] = new Post(500, 100, 50);
            double expectedEngagement = 65;

            // Act
            double totalEngagement = Program.CalculateTotalEngagementRate(array);

            // Assert
            Assert.AreEqual(expectedEngagement, totalEngagement);
        }

        [TestMethod]
        public void CalculateTotalEngagement100SinglePost()
        {
            // Arrange
            PostArray array = new PostArray(1);
            array[0] = new Post(1000, 100, 50);
            double expectedEngagement = 100;

            // Act
            double totalEngagement = Program.CalculateTotalEngagementRate(array);

            // Assert
            Assert.AreEqual(expectedEngagement, totalEngagement);
        }

        [TestMethod]
        public void CalculateTotalEngagementPosts()
        {
            // Arrange
            PostArray array = new PostArray(2);
            array[0] = new Post(500, 50, 25);  // Engagement = 57.5
            array[1] = new Post(250, 25, 10);  // Engagement = 28.5
            double expectedEngagement = 57.5 + 28.5; // 86

            // Act
            double totalEngagement = Program.CalculateTotalEngagementRate(array);

            // Assert
            Assert.AreEqual(expectedEngagement, totalEngagement);
        }
    }
}

