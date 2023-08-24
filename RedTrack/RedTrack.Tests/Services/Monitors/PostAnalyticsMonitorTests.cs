using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RedTrack.Models.Post;
using RedTrack.Services.Moniters;
using System;
using System.Threading;

namespace RedTrack.Services.Monitors.Tests
{
    [TestClass]
    public class PostAnalyticsMonitorTests
    {
        [TestMethod]
        public void StartMonitoring_Should_Set_IsMonitoring_To_True()
        {
            // Arrange
            var mockApiService = new Mock<IRedditApiService>();
            var monitor = new PostAnalyticsMonitor(mockApiService.Object, "testSubreddit");

            // Act
            monitor.StartMonitoring();

            // Assert
            Assert.IsTrue(monitor.IsMonitoring);
        }

        [TestMethod]
        public void StopMonitoring_Should_Set_IsMonitoring_To_False()
        {
            // Arrange
            var mockApiService = new Mock<IRedditApiService>();
            var monitor = new PostAnalyticsMonitor(mockApiService.Object, "testSubreddit");
            monitor.StartMonitoring();

            // Act
            monitor.StopMonitoring();

            // Assert
            Assert.IsFalse(monitor.IsMonitoring);
        }

        [TestMethod]
        public void CheckForNewPostsAsync_Should_Update_LastUpdated()
        {
            // Arrange
            var mockApiService = new Mock<IRedditApiService>();
            mockApiService.Setup(api => api.GetPostsAsync(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                          .ReturnsAsync(new List<Post> { new Post { Author = "user1", Ups = 10, Downs = 2 } });

            var monitor = new PostAnalyticsMonitor(mockApiService.Object, "testSubreddit");
            var initialLastUpdated = monitor.LastUpdated;

            // Act
            monitor.StartMonitoring();
            // Wait for some time to allow CheckForNewPostsAsync to run
            Thread.Sleep(2000);

            // Assert
            Assert.IsTrue(monitor.LastUpdated > initialLastUpdated);
        }

        // Add more tests for other scenarios, properties, and methods similarly.
    }
}
