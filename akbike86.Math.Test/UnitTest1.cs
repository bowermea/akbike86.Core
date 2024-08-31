using akbike86.Geometry;

namespace akbike86.Math.Test
{
    [TestFixture]
    public class EllipseFunctionsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(5,4,3,0.6,3.2)]
        [TestCase(25, 15, 20, 0.8, 9)]
        [TestCase(0.38709893, 0.3788265, 0.07959942, 0.20563069, 0.37073085)] // mercury

        public void TestEllipseFunctions(double a, double b, double c, double e, double l)
        {
            akbike86.Math.Constants.MERCURY.GM
            Assert.Multiple(() => {
                Assert.That(Ellipses.Functions.A.AFromBC(b, c), Is.EqualTo(a), $"Calculating a (={a}) from b ({b}) and c ({c}) failed.");
                Assert.That(Ellipses.Functions.A.AFromBE(b, e), Is.EqualTo(a), $"Calculating a (={a}) from b ({b}) and e ({e}) failed.");
                Assert.That(Ellipses.Functions.A.AFromCE(c, e), Is.EqualTo(a), $"Calculating a (={a}) from c ({c}) and e ({e}) failed.");
                Assert.That(Ellipses.Functions.A.AFromBL(b, l), Is.EqualTo(a), $"Calculating a (={a}) from b ({b}) and l ({l}) failed.");
                Assert.That(Ellipses.Functions.A.AFromCL(c, l), Is.EqualTo(a), $"Calculating a (={a}) from c ({c}) and l ({l}) failed.");
                Assert.That(Ellipses.Functions.A.AFromEL(e, l), Is.EqualTo(a), $"Calculating a (={a}) from e ({e}) and l ({l}) failed.");

                Assert.That(Ellipses.Functions.B.BFromAC(a, c), Is.EqualTo(b), $"Calculating b (={b}) from a ({a}) and c ({c}) failed.");
                Assert.That(Ellipses.Functions.B.BFromAE(a, e), Is.EqualTo(b), $"Calculating b (={b}) from a ({a}) and e ({e}) failed.");
                Assert.That(Ellipses.Functions.B.BFromCE(c, e), Is.EqualTo(b), $"Calculating b (={b}) from c ({c}) and e ({e}) failed.");
                Assert.That(Ellipses.Functions.B.BFromAL(a, l), Is.EqualTo(b), $"Calculating b (={b}) from a ({a}) and l ({l}) failed.");
                Assert.That(Ellipses.Functions.B.BFromCL(c, l), Is.EqualTo(b), $"Calculating b (={b}) from c ({c}) and l ({l}) failed.");
                Assert.That(Ellipses.Functions.B.BFromEL(e, l), Is.EqualTo(b), $"Calculating b (={b}) from e ({e}) and l ({l}) failed.");

                Assert.That(Ellipses.Functions.C.CFromAB(a, b), Is.EqualTo(c), $"Calculating c (={c}) from a ({a}) and b ({b}) failed.");
                Assert.That(Ellipses.Functions.C.CFromAE(a, e), Is.EqualTo(c), $"Calculating c (={c}) from a ({a}) and e ({e}) failed.");
                Assert.That(Ellipses.Functions.C.CFromBE(b, e), Is.EqualTo(c), $"Calculating c (={c}) from b ({b}) and e ({e}) failed.");
                Assert.That(Ellipses.Functions.C.CFromAL(a, l), Is.EqualTo(c), $"Calculating c (={c}) from a ({a}) and l ({l}) failed.");
                Assert.That(Ellipses.Functions.C.CFromBL(b, l), Is.EqualTo(c), $"Calculating c (={c}) from b ({b}) and l ({l}) failed.");
                Assert.That(Ellipses.Functions.C.CFromEL(e, l), Is.EqualTo(c), $"Calculating c (={c}) from e ({e}) and l ({l}) failed.");

                Assert.That(Ellipses.Functions.E.EFromAB(a, b), Is.EqualTo(e), $"Calculating e (={e}) from a ({a}) and b ({b}) failed.");
                Assert.That(Ellipses.Functions.E.EFromAC(a, c), Is.EqualTo(e), $"Calculating e (={e}) from a ({a}) and c ({c}) failed.");
                Assert.That(Ellipses.Functions.E.EFromBC(b, c), Is.EqualTo(e), $"Calculating e (={e}) from b ({b}) and c ({c}) failed.");
                Assert.That(Ellipses.Functions.E.EFromAL(a, l), Is.EqualTo(e), $"Calculating e (={e}) from a ({a}) and l ({l}) failed.");
                Assert.That(Ellipses.Functions.E.EFromBL(b, l), Is.EqualTo(e), $"Calculating e (={e}) from b ({b}) and l ({l}) failed.");
                Assert.That(Ellipses.Functions.E.EFromCL(c, l), Is.EqualTo(e), $"Calculating e (={e}) from c ({c}) and l ({l}) failed.");

                Assert.That(Ellipses.Functions.L.LFromAB(a, b), Is.EqualTo(l), $"Calculating l (={l}) from a ({a}) and b ({b}) failed.");
                Assert.That(Ellipses.Functions.L.LFromBC(a, c), Is.EqualTo(l), $"Calculating l (={l}) from a ({a}) and c ({c}) failed.");
                Assert.That(Ellipses.Functions.L.LFromBC(b, c), Is.EqualTo(l), $"Calculating l (={l}) from b ({b}) and c ({c}) failed.");
                Assert.That(Ellipses.Functions.L.LFromAE(a, e), Is.EqualTo(l), $"Calculating l (={l}) from a ({a}) and e ({e}) failed.");
                Assert.That(Ellipses.Functions.L.LFromBE(b, e), Is.EqualTo(l), $"Calculating l (={l}) from b ({b}) and e ({e}) failed.");
                Assert.That(Ellipses.Functions.L.LFromCE(c, e), Is.EqualTo(l), $"Calculating l (={l}) from c ({c}) and e ({e}) failed.");
            });

            Assert.Multiple(() =>
            {
                Assert.That(Ellipses.Functions.A.A2FromB2C2(b * b, c * c), Is.EqualTo(a * a), $"Calculating a² (={a * a}) from b² ({b * b}) and c² ({c * b}) failed.");
                Assert.That(Ellipses.Functions.A.A2FromB2E2(b * b, e * e), Is.EqualTo(a * a), $"Calculating a² (={a * a}) from b² ({b * b}) and e² ({e * b}) failed.");
                Assert.That(Ellipses.Functions.A.A2FromC2E2(c * c, e * e), Is.EqualTo(a * a), $"Calculating a² (={a * a}) from c² ({c * c}) and e² ({e * c}) failed.");
                Assert.That(Ellipses.Functions.A.A2FromB2L2(b * b, l * l), Is.EqualTo(a * a), $"Calculating a² (={a * a}) from b² ({b * b}) and l² ({l * b}) failed.");
                Assert.That(Ellipses.Functions.A.A2FromC2L2(c * c, l * l), Is.EqualTo(a * a), $"Calculating a² (={a * a}) from c² ({c * c}) and l² ({l * c}) failed.");
                Assert.That(Ellipses.Functions.A.A2FromE2L2(e * e, l * l), Is.EqualTo(a * a), $"Calculating a² (={a * a}) from e² ({e * e}) and l² ({l * e}) failed.");

                Assert.That(Ellipses.Functions.B.B2FromA2C2(a * a, c * c), Is.EqualTo(b * b), $"Calculating b² (={b * b}) from a² ({a * a}) and c² ({c * a}) failed.");
                Assert.That(Ellipses.Functions.B.B2FromA2E2(a * a, e * e), Is.EqualTo(b * b), $"Calculating b² (={b * b}) from a² ({a * a}) and e² ({e * a}) failed.");
                Assert.That(Ellipses.Functions.B.B2FromC2E2(c * c, e * e), Is.EqualTo(b * b), $"Calculating b² (={b * b}) from c² ({c * c}) and e² ({e * c}) failed.");
                Assert.That(Ellipses.Functions.B.B2FromA2L2(a * a, l * l), Is.EqualTo(b * b), $"Calculating b² (={b * b}) from a² ({a * a}) and l² ({l * a}) failed.");
                Assert.That(Ellipses.Functions.B.B2FromC2L2(c * c, l * l), Is.EqualTo(b * b), $"Calculating b² (={b * b}) from c² ({c * c}) and l² ({l * c}) failed.");
                Assert.That(Ellipses.Functions.B.B2FromE2L2(e * e, l * l), Is.EqualTo(b * b), $"Calculating b² (={b * b}) from e² ({e * e}) and l² ({l * e}) failed.");

                Assert.That(Ellipses.Functions.C.C2FromA2B2(a * a, b * b), Is.EqualTo(c * c), $"Calculating c² (={c * c}) from a² ({a * a}) and b² ({b * a}) failed.");
                Assert.That(Ellipses.Functions.C.C2FromA2E2(a * a, e * e), Is.EqualTo(c * c), $"Calculating c² (={c * c}) from a² ({a * a}) and e² ({e * a}) failed.");
                Assert.That(Ellipses.Functions.C.C2FromB2E2(b * b, e * e), Is.EqualTo(c * c), $"Calculating c² (={c * c}) from b² ({b * b}) and e² ({e * b}) failed.");
                Assert.That(Ellipses.Functions.C.C2FromA2L2(a * a, l * l), Is.EqualTo(c * c), $"Calculating c² (={c * c}) from a² ({a * a}) and l² ({l * a}) failed.");
                Assert.That(Ellipses.Functions.C.C2FromB2L2(b * b, l * l), Is.EqualTo(c * c), $"Calculating c² (={c * c}) from b² ({b * b}) and l² ({l * b}) failed.");
                Assert.That(Ellipses.Functions.C.C2FromE2L2(e * e, l * l), Is.EqualTo(c * c), $"Calculating c² (={c * c}) from e² ({e * e}) and l² ({l * e}) failed.");

                Assert.That(Ellipses.Functions.E.E2FromA2B2(a * a, b * b), Is.EqualTo(e * e), $"Calculating e² (={e * e}) from a² ({a * a}) and b² ({b * a}) failed.");
                Assert.That(Ellipses.Functions.E.E2FromA2C2(a * a, c * c), Is.EqualTo(e * e), $"Calculating e² (={e * e}) from a² ({a * a}) and c² ({c * a}) failed.");
                Assert.That(Ellipses.Functions.E.E2FromB2C2(b * b, c * c), Is.EqualTo(e * e), $"Calculating e² (={e * e}) from b² ({b * b}) and c² ({c * b}) failed.");
                Assert.That(Ellipses.Functions.E.E2FromA2L2(a * a, l * l), Is.EqualTo(e * e), $"Calculating e² (={e * e}) from a² ({a * a}) and l² ({l * a}) failed.");
                Assert.That(Ellipses.Functions.E.E2FromB2L2(b * b, l * l), Is.EqualTo(e * e), $"Calculating e² (={e * e}) from b² ({b * b}) and l² ({l * b}) failed.");
                Assert.That(Ellipses.Functions.E.E2FromC2L2(c * c, l * l), Is.EqualTo(e * e), $"Calculating e² (={e * e}) from c² ({c * c}) and l² ({l * c}) failed.");

                Assert.That(Ellipses.Functions.L.L2FromA2B2(a * a, b * b), Is.EqualTo(l * l), $"Calculating l² (={l * l}) from a² ({a * a}) and b² ({b * a}) failed.");
                Assert.That(Ellipses.Functions.L.L2FromB2C2(a * a, c * c), Is.EqualTo(l * l), $"Calculating l² (={l * l}) from a² ({a * a}) and c² ({c * a}) failed.");
                Assert.That(Ellipses.Functions.L.L2FromB2C2(b * b, c * c), Is.EqualTo(l * l), $"Calculating l² (={l * l}) from b² ({b * b}) and c² ({c * b}) failed.");
                Assert.That(Ellipses.Functions.L.L2FromA2E2(a * a, e * e), Is.EqualTo(l * l), $"Calculating l² (={l * l}) from a² ({a * a}) and e² ({e * a}) failed.");
                Assert.That(Ellipses.Functions.L.L2FromB2E2(b * b, e * e), Is.EqualTo(l * l), $"Calculating l² (={l * l}) from b² ({b * b}) and e² ({e * b}) failed.");
                Assert.That(Ellipses.Functions.L.L2FromC2E2(c * c, e * e), Is.EqualTo(l * l), $"Calculating l² (={l * l}) from c² ({c * c}) and e² ({e * c}) failed.");
            });

            Assert.Pass();
        }
    }
}