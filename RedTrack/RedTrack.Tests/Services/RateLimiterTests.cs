using Microsoft.VisualStudio.TestTools.UnitTesting; // or your testing framework's equivalent
using Moq; // If you're using Moq for mocking
using RedTrack.Services;
namespace RedTrack.Services.Tests
{
    [TestClass]
    public class RateLimiterTests
    {
        [TestMethod]
        public async Task CanMakeRequestAsync_EnoughRemainingRequests_ReturnsTrue()
        {
            // Arrange
            int remainingRequests = 5;
            int resetTime = 60;
            IRateLimiter rateLimiter = new RateLimiter(remainingRequests, resetTime);

            // Act
            bool canMakeRequest = await rateLimiter.CanMakeRequestAsync();

            // Assert
            Assert.IsTrue(canMakeRequest);
        }

        [TestMethod]
        public async Task CanMakeRequestAsync_EnoughRemainingRequests_ReturnsFalse()
        {
            // Arrange
            int remainingRequests = 0;
            int resetTime = 60;
            IRateLimiter rateLimiter = new RateLimiter(remainingRequests, resetTime);

            // Act
            bool canMakeRequest = await rateLimiter.CanMakeRequestAsync();

            // Assert
            Assert.IsFalse(canMakeRequest);
        }

        [TestMethod]
        public async Task CanMakeRequestAsync_EnoughRemainingRequestsLowRatio_ReturnsFalse()
        {
            // Arrange
            int remainingRequests = 500;
            int resetTime = 100;
            IRateLimiter rateLimiter = new RateLimiter(remainingRequests, resetTime);
            rateLimiter.setRateLimiter(remainingRequests:1, resetTime:99);
            // Act
            bool canMakeRequest = await rateLimiter.CanMakeRequestAsync();

            // Assert
            Assert.IsFalse(canMakeRequest);
        }

        [TestMethod]
        public async Task CanMakeRequestAsync_NoRemainingRequests_ReturnsTrueAfterResetTime()
        {
            // Arrange
            int remainingRequests = 0;
            int resetTime = 5; // 5 seconds
            IRateLimiter rateLimiter = new RateLimiter(remainingRequests, resetTime);

            // Act
            bool canMakeRequestBeforeReset = await rateLimiter.CanMakeRequestAsync();

            // Simulate passage of time
            await Task.Delay(resetTime * 1000 + 100); // Wait for more than reset time

            bool canMakeRequestAfterReset = await rateLimiter.CanMakeRequestAsync();

            // Assert
            Assert.IsFalse(canMakeRequestBeforeReset);
            Assert.IsTrue(canMakeRequestAfterReset);
        }

        [TestMethod]
        public async Task RecordRequestAsync_UpdatesRemainingRequests()
        {
            // Arrange
            int initialRemainingRequests = 10;
            int newRemainingRequests = 5;
            int resetTime = 60;
            IRateLimiter rateLimiter = new RateLimiter(initialRemainingRequests, resetTime);

            // Act
            await rateLimiter.RecordRequestAsync(newRemainingRequests);
            bool canMakeRequest = await rateLimiter.CanMakeRequestAsync();

            // Assert
            Assert.IsTrue(canMakeRequest);
            Assert.AreEqual(newRemainingRequests, rateLimiter.RemainingRequests);
        }
    }
}