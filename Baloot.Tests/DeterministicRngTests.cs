using System.Linq;
using Baloot.Core.Rng;
using Xunit;

namespace Baloot.Tests
{
    public class DeterministicRngTests
    {
        [Fact]
        public void Shuffle_WithSameSeed_ProducesExactSameOrder()
        {
            // Arrange
            ulong seed = 987654321UL;
            var rng1 = new DeterministicRng(seed);
            var rng2 = new DeterministicRng(seed);

            // مصفوفتان متطابقتان تمثلان ورق البلوت (32 ورقة)
            int[] deck1 = Enumerable.Range(1, 32).ToArray();
            int[] deck2 = Enumerable.Range(1, 32).ToArray();

            // Act
            rng1.Shuffle(deck1);
            rng2.Shuffle(deck2);

            // Assert: نثبت أن المصفوفتين تطابقتا تماماً في الترتيب بعد الخلط
            Assert.Equal(deck1, deck2);
        }
    }
}