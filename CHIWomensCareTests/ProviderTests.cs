using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FWPJ.ProviderServices;

namespace CHIWomensCareTests
{
    [TestClass]
    public class ProviderTests
    {
        private string biographyLong = "Marvelous justice derive god hatred oneself depths holiest revaluation strong evil ideal aversion oneself. Ultimate joy endless gains snare endless justice eternal-return hatred depths strong truth. Sea ideal reason good snare good hope decrepit of ideal faith holiest enlightenment evil. Superiority faithful faithful evil abstract spirit salvation free superiority superiority. Faith sea against play fearful intentions. <br/>Reason truth suicide sexuality eternal-return will eternal-return strong horror passion joy horror. Aversion abstract holiest passion ocean selfish love victorious society against. Marvelous morality spirit enlightenment zarathustra virtues inexpedient noble. Law grandeur dead society pious transvaluation battle war faithful sea disgust ascetic dead pinnacle.<br/>Madness hatred revaluation depths pious. Ascetic ocean superiority pinnacle enlightenment. Decrepit victorious faithful ultimate christian reason free.<br/>Spirit intentions salvation passion suicide burying ubermensch chaos grandeur. Intentions right love decieve convictions horror evil ideal noble holiest zarathustra.";
        private string biographyShort = "This is less than 100 characters.";
        private string biographyWithAnchor = "<p>This is a fragment that contains <a href=\"www.google.com\" target='_blank'>a link</a>";
        
        [TestMethod]
        public void FullNameReturnsFirstPlusLast()
        {
            // Arrange
            var p = new Provider()
            {
                FirstName = "Albert",
                LastName = "Einstein"
            };

            // Act
            var result = p.FullName;

            // Assert
            Assert.AreEqual("Albert Einstein", p.FullName);
        }

        [TestMethod]
        public void BiographyExcerptHTMLReturnsFragment()
        {
            // Arrange
            var p = new Provider()
            {
                BiographyHTML = this.biographyLong
            };
            var expectedValue = this.biographyLong.Substring(0, 100) + "...";

            // Act
            var result = p.BiographyExcerptHTML;

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void BiographyExcerptHTMLReturnsFragmentWithClosingParagraph()
        {
            // Arrange
            var p = new Provider()
            {
                BiographyHTML = "<p>" + this.biographyLong + "</p>"
            };
            var expectedValue = this.biographyLong.Substring(0, 100) + "...";

            // Act
            var result = p.BiographyExcerptHTML;

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void BiographyExcerptHtmlReturnsEmptyStringWhenBiographyIsNull()
        {
            // Arrange
            var p = new Provider()
            {
                BiographyHTML = null
            };

            // Act
            var result = p.BiographyExcerptHTML;

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void BiographyExcerptHtmlReturnsEmptyStringWhenBiographyIsEmptyString()
        {
            // Arrange
            var p = new Provider()
            {
                BiographyHTML = string.Empty
            };

            // Act
            var result = p.BiographyExcerptHTML;

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void BiographyExcerptHtmlReturnsEmptyStringWhenBiographyIsWhiteSpace()
        {
            // Arrange
            var p = new Provider()
            {
                BiographyHTML = "    "
            };

            // Act
            var result = p.BiographyExcerptHTML;

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void BiographyExcerptHtmlReturnsFullStringWhenUnder100Characters()
        {
            // Arrange
            var p = new Provider()
            {
                BiographyHTML = this.biographyShort
            };

            // Act
            var result = p.BiographyExcerptHTML;

            // Assert
            Assert.AreEqual(this.biographyShort, result);
        }

        [TestMethod]
        public void BiographyExcerptRemovesHTMLTags()
        {
            // Arrange
            var p = new Provider()
            {
                BiographyHTML = this.biographyWithAnchor
            };
            var expectedResult = "This is a fragment that contains a link";

            // Act
            var result = p.BiographyExcerptHTML;

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
