using Identifiable;

namespace TestIdentifiable
{
    public class Tests
    {
        public IdentifiableObject Id = new IdentifiableObject(new string[] { "STUDENT_ID", "FIRSTNAME", "LASTNAME"});

        [Test]
        public void TestAreYou()
        {
            Assert.That(Id.AreYou("FIRSTNAME"));
        }
        [Test]
        public void TestNotAreYou()
        {
            Assert.False(Id.AreYou("Touhou"));
        }
        [Test]
        public void TestCaseSensitive()
        {
            Assert.That(Id.AreYou("FIRSTNAME"));
        }
        [Test]
        public void TestFirstID()
        {
            Assert.That(Id.FirstId == "STUDENT_ID");
        }
        [Test]
        public void TestFirstIDWithNoIDs()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { });
            Assert.That(id.FirstId == "");
        }
        [Test]
        public void TestAddID()
        {
            Id.AddIdentifier("Testing!");
            Assert.That(Id.AreYou("Testing!"));
        }
        [Test]
        public void TestPrivilegeEscalation()
        {
            Id.PrivilegeEscalation("STUDENT_ID");
            Assert.That(Id.FirstId == "0007");
        }

    }
}